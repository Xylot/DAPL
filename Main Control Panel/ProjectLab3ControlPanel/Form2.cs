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
using OxyPlot.Series;
using OxyPlot.Axes;

namespace ProjectLab3ControlPanel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            this.InitializeComponent();
            //displayDiodeCurve();
            displayBJTCurve();
            
        }

        private void displayDiodeCurve()
        {
            var model = new PlotModel { Title = "Diode I-V Curve" };

            var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };
            var r = new Random(314);
            double satCurrent = 10e-12;
            for (double i = 0; i < 100; i++)
            {
                double x = i / 100;
                double y = satCurrent * (Math.Exp(x / .1));
                //var colorValue = r.Next(100, 1000);
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

            for (double i = -700; i < -100; i++)
            {
                double vCB = i / 1000;
                double vBC = -vCB;

                for (int j = 0; j < 5; j++)
                {
                    double forwardExpression = satCurrent * (Math.Exp((vBE - (j * 0.01)) / thermalVoltage) - 1);
                    double reverseExpression = (satCurrent / alphaR) * (Math.Exp(vBC / thermalVoltage) - 1);
                    double collectorCurrent = forwardExpression - reverseExpression;
                    scatterSeries.Points.Add(new ScatterPoint(vCB, collectorCurrent, 1.5, 100));

                }
            }

            model.Series.Add(scatterSeries);
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Right });

            this.plot1.Model = model;
        }
    }
}
