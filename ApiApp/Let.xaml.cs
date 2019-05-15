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

namespace ApiApp
{
    /// <summary>
    /// Interakční logika pro Let.xaml
    /// </summary>
    public partial class Let : Page
    {
        private int idletu;
        private string letJson;
        public Let(int cisloletu)
        {
            InitializeComponent();
            idletu = cisloletu;
            letJson = HttpManager.NacistID(idletu);
            Nastavit();
        }
        private void Nastavit()
        {
            Dictionary<string, object> list = JsonConverter.DictionaryZJson(letJson);
            Nazev.Content = list["mission_name"].ToString();
        }

        private void Zpet_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Lety());
        }
    }
}
