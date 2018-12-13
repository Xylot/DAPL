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
    public partial class Home : Form
    {

        int mov, movX, movY;
        List<Panel> panelList = new List<Panel>();

        Form2 form2 = new Form2();
        Form3 form3 = new Form3();

        public Home()
        {
            InitializeComponent();
            form3.Show();
        }

        private void Home_Load(object sender, MouseEventArgs e)
        {
            
        }

        private void ControlPanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Button_MOSFET_N_Click(object sender, EventArgs e)
        {
            new Form2(3).Show();
            refreshBluetoothStatusForm("n-MOSFET");
        }

        private void Button_MOSFET_P_Click(object sender, EventArgs e)
        {
            refreshBluetoothStatusForm("p-MOSFET");
        }

        private void Button_BJT_N_Click(object sender, EventArgs e)
        {
            new Form2(2).Show();
            refreshBluetoothStatusForm("n-BJT");
        }

        private void Button_BJT_P_Click(object sender, EventArgs e)
        {
            refreshBluetoothStatusForm("p-BJT");
        }

        private void Button_JFET_N_Click(object sender, EventArgs e)
        {
            refreshBluetoothStatusForm("n-JFET");
        }

        private void Button_JFET_P_Click(object sender, EventArgs e)
        {
            refreshBluetoothStatusForm("p-JFET");
        }

        private void Button_Diode_Click(object sender, EventArgs e)
        {
            new Form2(1).Show();
            refreshBluetoothStatusForm("Diode");
        }

        private void Button_General_Data_Click(object sender, EventArgs e)
        {
            new Form2(3).Show();
            refreshBluetoothStatusForm("General Data");
        }

        private void ControlPanelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void ControlPanelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void refreshBluetoothStatusForm(string transistorChoice)
        {
            form3.changeTransistorLabel(transistorChoice);
            form3.Refresh();
            
        }


    }
}
