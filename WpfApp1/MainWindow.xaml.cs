using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double h;
        double w;
        double t;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            h = double.Parse(height.Text);
            w = double.Parse(weight.Text);
            t = (w / h/h) * 703;

            BMI.Text = Convert.ToString(Convert.ToInt32(t));
            


            if (t < 18.5)
            {
                M.Text = " According to CDC.gov BMI CALCUlator you have a Under Weight.";
            }
            else if(t >= 18.5 && t <= 24.9)
            {
                M.Text = "According to CDC.gov BMI CALCUlator you have a  Normal weight.";
            }
            else if(t >= 25.0 && t <= 29.9)
            {
                M.Text = "According to CDC.gov BMI CALCUlator you have a Overweight.";
            }
            else
            {
                M.Text = "According to CDC.gov BMI CALCUlator you have a Obese.";
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            LN.Text = "";
            FN.Text = "";
            PN.Text = "";
            height.Text = "";
            weight.Text = "";
            BMI.Text = "";
            M.Text = "";
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
