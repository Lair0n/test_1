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
using test.Model;

namespace test.Pages
{
    /// <summary>
    /// Логика взаимодействия для Porte.xaml
    /// </summary>
    public partial class Porte : Page
    {
        public Porte(int id, string privetstvie)
        {
            InitializeComponent();
            lblPrivetstvie.Content = privetstvie;
            var rooms = Model1.GetContext().Rooms.ToList();
            listSotrudniki.ItemsSource = rooms;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPosetitel());
        }
    }
}