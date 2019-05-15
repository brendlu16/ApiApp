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
using System.Windows.Threading;

namespace ApiApp
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long NextLaunch;
        public MainWindow()
        {
            InitializeComponent();
            ZjistiNext();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(NastavitLabel);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            Frame1.NavigationService.Navigate(new Lety());
        }
        public void ZjistiNext()
        {
            string jsonNext = HttpManager.NacistNext();
            Dictionary<string, object> list = JsonConverter.DictionaryZJson(jsonNext);
            NextLaunch = int.Parse(list["launch_date_unix"].ToString());
            NazevLabel.Content = list["mission_name"].ToString();
            DetailyButton.Tag = list["flight_number"].ToString();
        }

        private void DetailyButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Frame1.NavigationService.Navigate(new Let(int.Parse(button.Tag.ToString())));
        }

        public void NastavitLabel(object sender, EventArgs e)
        {
            long ZbyvajiciCas = NextLaunch - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            TimeSpan time = TimeSpan.FromSeconds(ZbyvajiciCas);
            string str = time.ToString(@"ddd\:hh\:mm\:ss");
            OdpocetLabel.Content = str;
        }
    }
}
