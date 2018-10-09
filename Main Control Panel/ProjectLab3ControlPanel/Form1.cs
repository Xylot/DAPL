using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace ProjectLab3ControlPanel
{
    public partial class Home : Form
    {

        int mov, movX, movY;
        int index;
        List<Panel> panelList = new List<Panel>();



        public Home()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
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


    }
}
