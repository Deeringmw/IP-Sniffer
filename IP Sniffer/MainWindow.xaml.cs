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
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;

namespace IP_Sniffer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public void txtIP_GotFocus(object sender, RoutedEventArgs e)
        {
            txtIP.Text = "";
        }
        private void btnSniff_Click(object sender, RoutedEventArgs e)
        {
          
            using (WebClient wc = new WebClient())
            {
                var ip = txtIP.Text;
                var json = wc.DownloadString("http://ipinfo.io/" + ip + "/json");

                var ipData = JsonConvert.DeserializeObject<IP>(json);

                lstData.Visibility = Visibility.Visible;
                var lstDataItems = new List<string>();
                lstData.Items.Add(ipData.ip);
                lstData.Items.Add(ipData.hostname);
                lstData.Items.Add(ipData.city);
                lstData.Items.Add(ipData.region);
                lstData.Items.Add(ipData.country);
                lstData.Items.Add(ipData.loc);
                lstData.Items.Add(ipData.org);
                lstData.Items.Add(ipData.postal);
            }

        }
    }
}
