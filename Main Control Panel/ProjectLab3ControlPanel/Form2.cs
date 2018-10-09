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
using OxyPlot.WindowsForms;

namespace ProjectLab3ControlPanel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            this.InitializeComponent();
            var myModel = new PlotModel { Title = "I-V Curve" };

            double satCurrent = 10e-14;

            Func<double, double> diodeCurrent = (x) => satCurrent * (Math.Exp(x / .026));

            myModel.Series.Add(new FunctionSeries(diodeCurrent, 0, 1, 0.01));
            this.plot1.Model = myModel;
        }
    }
}
