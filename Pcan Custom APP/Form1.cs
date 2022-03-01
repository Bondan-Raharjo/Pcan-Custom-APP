using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;
namespace Pcan_Custom_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeBasicComponents();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            TPCANStatus stsResult;
                stsResult = PCANBasic.Initialize(
                    m_PcanHandle,
                    m_Baudrate,
                    m_HwType,
                    Convert.ToUInt32("0100", 16),
                    Convert.ToUInt16("3"));

            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                if (stsResult != TPCANStatus.PCAN_ERROR_CAUTION)
                    MessageBox.Show(GetFormatedError(stsResult));
                else
                {
                    stsResult = TPCANStatus.PCAN_ERROR_OK;
                }
            else
            {
                ConfigureTraceFile();
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = true;
                button3.Enabled = true;
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            // Releases a current connected PCAN-Basic channel
            //
            PCANBasic.Uninitialize(m_PcanHandle);
            button4.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            // tmrRead.Enabled = false;
            if (m_ReadThread != null)
            {
                m_ReadThread.Abort();
                m_ReadThread.Join();
                m_ReadThread = null;
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            TPCANStatus stsResult;
            uint iChannelsCount;
            bool bIsFD;

            // Clears the Channel comboBox and fill it again with 
            // the PCAN-Basic handles for no-Plug&Play hardware and
            // the detected Plug&Play hardware
            //
            comboBox1.Items.Clear();
            try
            {
                // Includes all no-Plug&Play Handles
                for (int i = 0; i < m_NonPnPHandles.Length; i++)
                    comboBox1.Items.Add(FormatChannelName(m_NonPnPHandles[i]));

                // Checks for available Plug&Play channels
                //
                stsResult = PCANBasic.GetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_ATTACHED_CHANNELS_COUNT, out iChannelsCount, sizeof(uint));
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                {
                    TPCANChannelInformation[] info = new TPCANChannelInformation[iChannelsCount];

                    stsResult = PCANBasic.GetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_ATTACHED_CHANNELS, info);
                    if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                        // Include only connectable channels
                        //
                        foreach (TPCANChannelInformation channel in info)
                            if ((channel.channel_condition & PCANBasic.PCAN_CHANNEL_AVAILABLE) == PCANBasic.PCAN_CHANNEL_AVAILABLE)
                            {
                                bIsFD = (channel.device_features & PCANBasic.FEATURE_FD_CAPABLE) == PCANBasic.FEATURE_FD_CAPABLE;
                                comboBox1.Items.Add(FormatChannelName(channel.channel_handle, bIsFD));
                            }
                }

                comboBox1.SelectedIndex = comboBox1.Items.Count - 1;

                if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                    MessageBox.Show(GetFormatedError(stsResult));
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Unable to find the library: PCANBasic.dll !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            TPCANStatus stsResult;

            // We execute the "Read" function of the PCANBasic                
            //
            stsResult = m_IsFD ? ReadMessageFD() : ReadMessage();
            if (stsResult != TPCANStatus.PCAN_ERROR_OK) {  Console.WriteLine(GetFormatedError(stsResult));}
            // Abort Read Thread if it exists
            //
            if (m_ReadThread != null)
            {
                m_ReadThread.Abort();
                m_ReadThread.Join();
                m_ReadThread = null;
            }

            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            lock (m_LastMsgsList.SyncRoot)
            {
                m_LastMsgsList.Clear();
                lstMessages.Items.Clear();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TPCANStatus stsResult;

            // Send the message
            //
            stsResult = m_IsFD ? WriteFrameFD() : WriteFrame();

            // The message was successfully sent
            //
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
            {
                Console.WriteLine("Message was successfully SENT");
                label6.Text = "Message was successfully SENT";
            }
            // An error occurred.  We show the error.
            //			
            else
                MessageBox.Show(GetFormatedError(stsResult)); label6.Text = "Message was Failled ";

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int maxdata = 8;
            if (textBox1.Text == null || textBox1.Text == "")
            {
                textBox1.Text = "00";
            }
            else
            {
                int limitdata = int.Parse(textBox1.Text);
                if (limitdata >= maxdata)
                    textBox1.Text = "0" + maxdata;

                TextBox txtbCurrentTextBox;

                txtbCurrentTextBox = txtData0;

                for (int i = 0; i <= maxdata; i++)
                {
                    txtbCurrentTextBox.Enabled = i <= limitdata;
                    if (i < maxdata)
                        txtbCurrentTextBox = (TextBox)this.Controls.Find("txtData" + i.ToString(), true)[0];
                }


            }



        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ReadMessages();

        }
        #region libary
        public static int GetLengthFromDLC(int dlc, bool isSTD)
        {
            if (dlc <= 8)
                return dlc;

            if (isSTD)
                return 8;

            switch (dlc)
            {
                case 9: return 12;
                case 10: return 16;
                case 11: return 20;
                case 12: return 24;
                case 13: return 32;
                case 14: return 48;
                case 15: return 64;
                default: return dlc;
            }
        }
        private string FormatChannelName(TPCANHandle handle, bool isFD)
        {
            TPCANDevice devDevice;
            byte byChannel;

            // Gets the owner device and channel for a 
            // PCAN-Basic handle
            //
            if (handle < 0x100)
            {
                devDevice = (TPCANDevice)(handle >> 4);
                byChannel = (byte)(handle & 0xF);
            }
            else
            {
                devDevice = (TPCANDevice)(handle >> 8);
                byChannel = (byte)(handle & 0xFF);
            }

            // Constructs the PCAN-Basic Channel name and return it
            //
            if (isFD)
                return string.Format("{0}:FD {1} ({2:X2}h)", devDevice, byChannel, handle);
            else
                return string.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle);
        }
        private string FormatChannelName(TPCANHandle handle)
        {
            return FormatChannelName(handle, false);
        }
        private string GetFormatedError(TPCANStatus error)
        {
            StringBuilder strTemp;

            // Creates a buffer big enough for a error-text
            //
            strTemp = new StringBuilder(256);
            // Gets the text using the GetErrorText API function
            // If the function success, the translated error is returned. If it fails,
            // a text describing the current error is returned.
            //
            if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
                return string.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);
            else
                return strTemp.ToString();
        }
        private void InitializeBasicComponents()
        {
           
            m_LastMsgsList = new System.Collections.ArrayList();
            //m_ReadDelegate = new ReadDelegateHandler(ReadMessages);
            // m_ReceiveEvent = new System.Threading.AutoResetEvent(false);
            m_NonPnPHandles = new TPCANHandle[]
            {
                PCANBasic.PCAN_ISABUS1,
                PCANBasic.PCAN_ISABUS2,
                PCANBasic.PCAN_ISABUS3,
                PCANBasic.PCAN_ISABUS4,
                PCANBasic.PCAN_ISABUS5,
                PCANBasic.PCAN_ISABUS6,
                PCANBasic.PCAN_ISABUS7,
                PCANBasic.PCAN_ISABUS8,
                PCANBasic.PCAN_DNGBUS1
            };

            FillComboBoxData();

        }
        private void FillComboBoxData()
        {

            button2_Click(this, new EventArgs());
            comboBox2.SelectedIndex = 2; 

        }
        private void InsertMsgEntry(TPCANMsgFD newMsg, TPCANTimestampFD timeStamp)
        {
            MessageStatus msgStsCurrentMsg;
            ListViewItem lviCurrentItem;

            lock (m_LastMsgsList.SyncRoot)
            {
                // We add this status in the last message list
                //
                msgStsCurrentMsg = new MessageStatus(newMsg, timeStamp, lstMessages.Items.Count);
                msgStsCurrentMsg.ShowingPeriod = true;
                m_LastMsgsList.Add(msgStsCurrentMsg);

                // Add the new ListView Item with the Type of the message
                //	
                lviCurrentItem = lstMessages.Items.Add(msgStsCurrentMsg.TypeString);
                // We set the ID of the message
                //
                lviCurrentItem.SubItems.Add(msgStsCurrentMsg.IdString);
                // We set the length of the Message
                //
                lviCurrentItem.SubItems.Add(GetLengthFromDLC(newMsg.DLC, (newMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_FD) == 0).ToString());
                // we set the message count message (this is the First, so count is 1)            
                //
                lviCurrentItem.SubItems.Add(msgStsCurrentMsg.Count.ToString());
                // Add time stamp information if needed
                //
                lviCurrentItem.SubItems.Add(msgStsCurrentMsg.TimeString);
                // We set the data of the message. 	
                //
                lviCurrentItem.SubItems.Add(msgStsCurrentMsg.DataString);
            }
        }
        private void ProcessMessage(TPCANMsgFD theMsg, TPCANTimestampFD itsTimeStamp)
        {
            // We search if a message (Same ID and Type) is 
            // already received or if this is a new message
            //
            lock (m_LastMsgsList.SyncRoot)
            {
                foreach (MessageStatus msg in m_LastMsgsList)
                {
                    if ((msg.CANMsg.ID == theMsg.ID) && (msg.CANMsg.MSGTYPE == theMsg.MSGTYPE))
                    {
                        // Modify the message and exit
                        //
                        msg.Update(theMsg, itsTimeStamp);
                        return;
                    }
                }
                // Message not found. It will created
                //
                InsertMsgEntry(theMsg, itsTimeStamp);
            }
        }
        private void ConfigureTraceFile()
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;


            iBuffer = 5;
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_SIZE, ref iBuffer, sizeof(UInt32));
            iBuffer = PCANBasic.TRACE_FILE_SINGLE | PCANBasic.TRACE_FILE_OVERWRITE;
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_CONFIGURE, ref iBuffer, sizeof(UInt32));
        }
        private void ProcessMessage(TPCANMsg theMsg, TPCANTimestamp itsTimeStamp)
        {
            TPCANMsgFD newMsg;
            TPCANTimestampFD newTimestamp;

            newMsg = new TPCANMsgFD();
            newMsg.DATA = new byte[64];
            newMsg.ID = theMsg.ID;
            newMsg.DLC = theMsg.LEN;
            for (int i = 0; i < ((theMsg.LEN > 8) ? 8 : theMsg.LEN); i++)
                newMsg.DATA[i] = theMsg.DATA[i];
            newMsg.MSGTYPE = theMsg.MSGTYPE;

            newTimestamp = Convert.ToUInt64(itsTimeStamp.micros + 1000 * itsTimeStamp.millis + 0x100000000 * 1000 * itsTimeStamp.millis_overflow);
            ProcessMessage(newMsg, newTimestamp);
        }
        private void ReadMessages()
        {
            TPCANStatus stsResult;

            // We read at least one time the queue looking for messages.
            // If a message is found, we look again trying to find more.
            // If the queue is empty or an error occurr, we get out from
            // the dowhile statement.
            //			
            do
            {
                stsResult = m_IsFD ? ReadMessageFD() : ReadMessage();
                if (stsResult == TPCANStatus.PCAN_ERROR_ILLOPERATION)
                    break;
            } while (button1.Enabled && (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY)));
        }

        private bool m_IsFD;

        private TPCANHandle m_PcanHandle;

        private TPCANHandle[] m_NonPnPHandles;

        private TPCANBaudrate m_Baudrate;

        private TPCANType m_HwType;
        private TPCANStatus ReadMessageFD()
        {
            TPCANMsgFD CANMsg;
            TPCANTimestampFD CANTimeStamp;
            TPCANStatus stsResult;

            // We execute the "Read" function of the PCANBasic                
            //
            stsResult = PCANBasic.ReadFD(m_PcanHandle, out CANMsg, out CANTimeStamp);
            if (stsResult != TPCANStatus.PCAN_ERROR_QRCVEMPTY)
                // We process the received message
                //
                ProcessMessage(CANMsg, CANTimeStamp);

            return stsResult;
        }
        private TPCANStatus ReadMessage()
        {
            TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;

            // We execute the "Read" function of the PCANBasic                
            //
            stsResult = PCANBasic.Read(m_PcanHandle, out CANMsg, out CANTimeStamp);
            if (stsResult != TPCANStatus.PCAN_ERROR_QRCVEMPTY)
                // We process the received message
                //

                ProcessMessage(CANMsg, CANTimeStamp);

            return stsResult;
        }
        private TPCANStatus WriteFrame()
        {
            TPCANMsg CANMsg;
            TextBox txtbCurrentTextBox;

            // We create a TPCANMsg message structure 
            //
            CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];

            // We configurate the Message.  The ID,
            // Length of the Data, Message Type
            // and the data
            //
            CANMsg.ID = Convert.ToUInt32(txtID.Text, 16);
            CANMsg.LEN = Convert.ToByte(int.Parse(textBox1.Text));
            CANMsg.MSGTYPE = (false) ? TPCANMessageType.PCAN_MESSAGE_EXTENDED : TPCANMessageType.PCAN_MESSAGE_STANDARD;
            // If a remote frame will be sent, the data bytes are not important.
            //

            // We get so much data as the Len of the message
            //
            for (int i = 0; i < GetLengthFromDLC(CANMsg.LEN, true); i++)
            {
                txtbCurrentTextBox = (TextBox)this.Controls.Find("txtData" + i.ToString(), true)[0];
                CANMsg.DATA[i] = Convert.ToByte(txtbCurrentTextBox.Text, 16);
            }


            // The message is sent to the configured hardware
            //
            return PCANBasic.Write(m_PcanHandle, ref CANMsg);
        }
        private TPCANStatus WriteFrameFD()
        {
            TPCANMsgFD CANMsg;
            TextBox txtbCurrentTextBox;
            int iLength;

            // We create a TPCANMsgFD message structure 
            //
            CANMsg = new TPCANMsgFD();
            CANMsg.DATA = new byte[64];

            // We configurate the Message.  The ID,
            // Length of the Data, Message Type 
            // and the data
            //
            CANMsg.ID = Convert.ToUInt32(txtID.Text, 16);
            CANMsg.DLC = Convert.ToByte(int.Parse(textBox1.Text));
            CANMsg.MSGTYPE = (false) ? TPCANMessageType.PCAN_MESSAGE_EXTENDED : TPCANMessageType.PCAN_MESSAGE_STANDARD;
            CANMsg.MSGTYPE |= (false) ? TPCANMessageType.PCAN_MESSAGE_FD : TPCANMessageType.PCAN_MESSAGE_STANDARD;
            CANMsg.MSGTYPE |= (false) ? TPCANMessageType.PCAN_MESSAGE_BRS : TPCANMessageType.PCAN_MESSAGE_STANDARD;

            iLength = GetLengthFromDLC(CANMsg.DLC, (CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_FD) == 0);
            for (int i = 0; i < iLength; i++)
            {
                txtbCurrentTextBox = (TextBox)this.Controls.Find("txtData" + i.ToString(), true)[0];
                CANMsg.DATA[i] = Convert.ToByte(txtbCurrentTextBox.Text, 16);
            }

            return PCANBasic.WriteFD(m_PcanHandle, ref CANMsg);
        }
        private System.Collections.ArrayList m_LastMsgsList;
        private System.Threading.Thread m_ReadThread;

      
        #endregion

        #region Class LLibary
        private class MessageStatus
        {
            private TPCANMsgFD m_Msg;
            private TPCANTimestampFD m_TimeStamp;
            private TPCANTimestampFD m_oldTimeStamp;
            private int m_iIndex;
            private int m_Count;
            private bool m_bShowPeriod;
            private bool m_bWasChanged;

            public MessageStatus(TPCANMsgFD canMsg, TPCANTimestampFD canTimestamp, int listIndex)
            {
                m_Msg = canMsg;
                m_TimeStamp = canTimestamp;
                m_oldTimeStamp = canTimestamp;
                m_iIndex = listIndex;
                m_Count = 1;
                m_bShowPeriod = true;
                m_bWasChanged = false;
            }

            public void Update(TPCANMsgFD canMsg, TPCANTimestampFD canTimestamp)
            {
                m_Msg = canMsg;
                m_oldTimeStamp = m_TimeStamp;
                m_TimeStamp = canTimestamp;
                m_bWasChanged = true;
                m_Count += 1;
            }

            public TPCANMsgFD CANMsg
            {
                get { return m_Msg; }
            }

            public TPCANTimestampFD Timestamp
            {
                get { return m_TimeStamp; }
            }

            public int Position
            {
                get { return m_iIndex; }
            }

            public string TypeString
            {
                get { return GetMsgTypeString(); }
            }

            public string IdString
            {
                get { return GetIdString(); }
            }

            public string DataString
            {
                get { return GetDataString(); }
            }

            public int Count
            {
                get { return m_Count; }
            }

            public bool ShowingPeriod
            {
                get { return m_bShowPeriod; }
                set
                {
                    if (m_bShowPeriod ^ value)
                    {
                        m_bShowPeriod = value;
                        m_bWasChanged = true;
                    }
                }
            }

            public bool MarkedAsUpdated
            {
                get { return m_bWasChanged; }
                set { m_bWasChanged = value; }
            }

            public string TimeString
            {
                get { return GetTimeString(); }
            }

            private string GetTimeString()
            {
                double fTime;

                fTime = (m_TimeStamp / 1000.0);
                if (m_bShowPeriod)
                    fTime -= (m_oldTimeStamp / 1000.0);
                return fTime.ToString("F1");
            }

            private string GetDataString()
            {
                string strTemp;

                strTemp = "";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                    return "Remote Request";
                else
                    for (int i = 0; i < Form1.GetLengthFromDLC(m_Msg.DLC, (m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_FD) == 0); i++)
                        strTemp += string.Format("{0:X2} ", m_Msg.DATA[i]);

                return strTemp;
            }

            private string GetIdString()
            {
                // We format the ID of the message and show it
                //
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                    return string.Format("{0:X8}h", m_Msg.ID);
                else
                    return string.Format("{0:X3}h", m_Msg.ID);
            }

            private string GetMsgTypeString()
            {
                string strTemp;
                bool isEcho = (m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_ECHO) == TPCANMessageType.PCAN_MESSAGE_ECHO;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_STATUS) == TPCANMessageType.PCAN_MESSAGE_STATUS)
                    return "STATUS";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_ERRFRAME) == TPCANMessageType.PCAN_MESSAGE_ERRFRAME)
                    return "ERROR";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                    strTemp = "EXT";
                else
                    strTemp = "STD";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                    strTemp += isEcho ? "/RTR [ ECHO ]" : "/RTR";
                else
                {
                    if ((int)m_Msg.MSGTYPE > (int)TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                    {
                        if (isEcho)
                            strTemp += " [ ECHO";
                        else
                            strTemp += " [ ";
                        if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_FD) == TPCANMessageType.PCAN_MESSAGE_FD)
                            strTemp += " FD";
                        if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_BRS) == TPCANMessageType.PCAN_MESSAGE_BRS)
                            strTemp += " BRS";
                        if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_ESI) == TPCANMessageType.PCAN_MESSAGE_ESI)
                            strTemp += " ESI";
                        strTemp += " ]";
                    }
                }

                return strTemp;
            }

        }

        #endregion

        
    }
}
