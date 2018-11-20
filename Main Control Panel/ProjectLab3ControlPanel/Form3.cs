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

        Form2 form2 = new Form2();

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

                StringBuilder builder = new StringBuilder(150);
                while (serialPort.BytesToRead > 0)
                {
                    builder.Append(Convert.ToChar(serialPort.ReadChar()));
                }
                string rawOutput = builder.ToString();
                changeReceivedCommunicationText(rawOutput);
                CreateIVArrays(rawOutput, "");
                break;
            }
        }

        public void CreateIVArrays(string voltageData, string currentData)
        {
            String[] voltageStringArray = voltageData.Split(',');
            voltageStringArray = voltageStringArray.Skip(1).ToArray();
            Array.Resize(ref voltageStringArray, voltageStringArray.Length - 1);
            double[] voltageIntArray = Array.ConvertAll(voltageStringArray, double.Parse);
            double[] currentIntArray = new double[voltageIntArray.Length];
            for (int i = 0; i < voltageIntArray.Length; i++)
            {
                currentIntArray[i] = voltageIntArray[i] / 10;
            }

            new Form2(voltageIntArray, currentIntArray).Show();

        }
    }
}
