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
using System.Text.RegularExpressions;
using System.Diagnostics;

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

                StringBuilder builder = new StringBuilder(1000);
                while (serialPort.BytesToRead > 0)
                {
                    builder.Append(Convert.ToChar(serialPort.ReadChar()));
                    //builder.Append(serialPort.ReadChar());
                }
                string rawOutput = builder.ToString();
                rawOutput = SanatizeString(rawOutput);
                changeReceivedCommunicationText(rawOutput);
                builder.Clear();
                CreateIVArrays(rawOutput, "");
                break;
            }
        }

        public String[] SanatizeArray(String[] arr)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = digitsOnly.Replace(arr[i], "");
                //Debug.WriteLine(arr[i]);
            }
            arr = arr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            arr = arr.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            return arr;
        }

        public string SanatizeString(string str)
        {
            Regex digitsOnly = new Regex(@"[^\d,]");
            return digitsOnly.Replace(str, "");
        }

        public void printArray(String[] strArray)
        {
            Debug.Write("{");
            for (int i = 0; i < strArray.Length; i++)
            {
                Debug.Write(strArray[i] + ", ");
            }
            Debug.Write("}");
        }

        public void CreateIVArrays(string voltageData, string currentData)
        {
            String[] voltageStringArray = voltageData.Split(',');
            voltageStringArray = SanatizeArray(voltageStringArray);
            printArray(voltageStringArray);
            double[] voltageIntArray = Array.ConvertAll(voltageStringArray, double.Parse);
            double[] currentIntArray = new double[voltageIntArray.Length];
            for (int i = 0; i < voltageIntArray.Length; i++)
            {
                currentIntArray[i] = voltageIntArray[i] / 10;
            }

            new Form2(voltageIntArray, currentIntArray).Show();

        }

        private void BluetoothStatusLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
