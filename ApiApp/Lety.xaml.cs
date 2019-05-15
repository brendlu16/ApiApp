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
    /// Interakční logika pro Lety.xaml
    /// </summary>
    public partial class Lety : Page
    {
        private string letyJson;
        public Lety()
        {
            InitializeComponent();
            letyJson = HttpManager.NacistVse();
            //Generovat();
        }
        private void Generovat()
        {
            string jsonNext = HttpManager.NacistNext();
            Dictionary<string, object> list = JsonConverter.DictionaryZJson(jsonNext);
            int cisloNext = int.Parse(list["flight_number"].ToString());
            //Dictionary<string, object> letyList = JsonConverter.DictionaryZJson(letyJson);
            List<string> letyList = JsonConverter.ListZJson(letyJson);
            foreach (var item in letyList)
            {

            }
        }
        private void ItemClicked(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            NavigationService.Navigate(new Let(int.Parse(item.Tag.ToString())));
        }
    }
}
