using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace ProjectLab3ControlPanel
{
    public partial class Form3 : Form
    {

        SerialPort serialPort = new SerialPort();

        public Form3()
        {
            InitializeComponent();
            InitializeSerialConnection();
        }

        public void InitializeSerialConnection()
        {
            serialPort.BaudRate = 115200;
            serialPort.PortName = "COM7";
            serialPort.Open();
        }

        public Form3(string currentTransistor)
        {
            InitializeComponent();
            CurrentTransistorLabel.Text = currentTransistor;
        }

        

        public void changeTransistorLabel(string currentTransistor)
        {
            CurrentTransistorLabel.Text = currentTransistor;
        }

        public void changeReceivedCommunicationText(string data)
        {
            TextBox_ReceivedCommunication.Text = data;
        }

        public string getMessageToSend()
        {
            return SerialCommunicationMessage.Text;
        }

        public void Button_SendSerialMessage_Click(object sender, EventArgs e)
        {
            Communicate();
        }

        public void Communicate()
        {
            while (serialPort.IsOpen)
            {
                string messageToSend = getMessageToSend();
                serialPort.WriteLine(messageToSend);
                Thread.Sleep(500);

                StringBuilder builder = new StringBuilder(100);
                while (serialPort.BytesToRead > 0)
                {
                    builder.Append(Convert.ToChar(serialPort.ReadChar()));
                }
                changeReceivedCommunicationText(builder.ToString());
                break;
            }
        }
    }
}
