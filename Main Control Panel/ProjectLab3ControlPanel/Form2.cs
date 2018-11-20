using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;

namespace ProjectLab3ControlPanel
{
    public partial class Form2 : Form
    {

        double[] currentList = {0.00002,
0.00006,
0.00004,
0.0001,
0.00015,
0.00155,
0.00355,
0.0052,
0.0069,
0.0082,
0.01065,
0.0116,
0.01392,
0.01681,
0.01832,
0.0207,
0.0209,
0.02416,
0.0293,
0.03389,
0.04025,
0.05115,
0.0663};
        double[] voltageList = {0.208,
0.394,
0.526,
0.64,
0.83,
0.875,
0.895,
0.91,
0.92,
0.93,
0.935,
0.94,
0.948,
0.959,
0.968,
0.97,
0.97,
0.984,
0.99,
1.011,
1.025,
1.045,
1.07};

        public Form2()
        {
            this.InitializeComponent();
        }

        public Form2(int choice)
        {
            this.InitializeComponent();
            switch (choice)
            {
                case 1:
                    displayDiodeCurve();
                    break;
                case 2:
                    displayBJTCurve();
                    break;
                default:
                    displayData(currentList, voltageList);
                    break;
            }

        }

        public Form2(double[] voltageData, double[] currentData){
            this.InitializeComponent();
            displayData(currentData, voltageData);
        }

        private void displayDiodeCurve()
        {
            var model = new PlotModel { Title = "Diode I-V Curve" };

            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
            double satCurrent = 10e-12;
            for (double i = 0; i < 100; i++)
            {
                double x = i / 100;
                double y = satCurrent * (Math.Exp(x / .06));
                scatterSeries.Points.Add(new ScatterPoint(x, y, 1.5, 100));
            }

            model.Series.Add(scatterSeries);
            //model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(200) });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Right });
            //double satCurrent = 10e-14;

            //Func<double, double> diodeCurrent = (x) => satCurrent * (Math.Exp(x / .026));

            //myModel.Series.Add(new FunctionSeries(diodeCurrent, 0, 1, 0.01));
            this.plot1.Model = model;
        }

        private void displayBJTCurve()
        {
            var model = new PlotModel { Title = "BJT Saturation Curve" };
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

            double vBE = 0.7;
            double betaR = 0.1;
            double alphaR = betaR / (betaR + 1);
            double satCurrent = 10e-14;
            double thermalVoltage = 0.025;

            for (double i = -700; i < 700; i++)
            {
                double vCB = i / 1000;
                double vBC = -vCB;

                for (int j = 0; j < 5; j++)
                {
                    double forwardExpression = satCurrent * (Math.Exp((vBE - (j * 0.01)) / thermalVoltage) - 1);
                    double reverseExpression = (satCurrent / alphaR) * (Math.Exp(vBC / thermalVoltage) - 1);
                    double collectorCurrent = forwardExpression - reverseExpression;
                    scatterSeries.Points.Add(new ScatterPoint(vCB+0.61, collectorCurrent, 1.5, j*200));

                }
            }

            model.Series.Add(scatterSeries);
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Right, Minimum = 0, Maximum = 0.2 });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = -0.7, Maximum = 1 });

            this.plot1.Model = model;
        }

        private void displayData(double[] voltage, double[] current)
        {
            var model = new PlotModel { Title = "General Data Curve" };
            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

            for (int i = 0; i < current.Length; i++)
            {
                scatterSeries.Points.Add(new ScatterPoint(voltage[i], current[i], 1.5, 100));
            }
            model.Series.Add(scatterSeries);
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Right});
            this.plot1.Model = model;
        }

    }
}

