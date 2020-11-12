using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    [XmlRoot("BMI Calc", Namespace = "www.bmicalc.ninja")]
    public partial class MainWindow : Window
    {
       
        double h;
        double w;
        double t;
        public string FilePath = "C:\\Users\\medley_jamagiae\\Documents\\";
        public string FileName = "Ninja.xml";
        
        public MainWindow()
        {
            InitializeComponent();
            OnLoadStats();
        }
        public class Customer
        {
            [XmlAttribute("Last Name")]
            public string lastName { get; set; }
            [XmlAttribute("First Name")]
            public string firstName { get; set; }
            [XmlAttribute("Phone Number")]
            public string phoneNumber { get; set; }
            [XmlAttribute("Height")]
            public int heightInches { get; set; }
            [XmlAttribute("Weight")]
            public int weightLbs { get; set; }
            [XmlAttribute("Customer BMI")]
            public int custBMI { get; set; }
            [XmlAttribute("Status")]
            public string statusTitle { get; set; }

            

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            Customer customer1 = new Customer();

            customer1.lastName = LN.Text;
            customer1.firstName = FN.Text;
            customer1.phoneNumber = PN.Text;
            //customer1.heightInches = Convert.ToInt32(height.Text);
            //customer1.weightLbs = Convert.ToInt32(weight.Text);

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

            TextWriter writer = new StreamWriter(FilePath + FileName);

            //Actual Part for Serialization
            XmlSerializer ser = new XmlSerializer(typeof(Customer));

            //get the writer stream and the instance of the class we have... below
            ser.Serialize(writer, customer1);
            writer.Close();

          
        }


        private void OnLoadStats()
        {
            Customer cust = new Customer();

            XmlSerializer des = new XmlSerializer(typeof(Customer));
            using (XmlReader reader = XmlReader.Create(FilePath + FileName))
            {
                cust = (Customer)des.Deserialize(reader);

                LN.Text = cust.lastName;
                FN.Text = cust.firstName;
                PN.Text = cust.phoneNumber;
                height.Text = Convert.ToString(cust.heightInches);
                weight.Text = Convert.ToString(cust.weightLbs);


            }
            DataSet xmlData = new DataSet();
            xmlData.ReadXml(FilePath + FileName, XmlReadMode.Auto);
            xDataGrid.ItemsSource = xmlData.Tables[0].DefaultView;
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

        private void xDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
