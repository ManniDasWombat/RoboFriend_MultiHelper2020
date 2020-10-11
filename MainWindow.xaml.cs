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

namespace RoboFriend_MultiHelper2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StoreWindow.Content = new StartPage();
        }


        private void BestBuddy_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new BestMathBuddy_01();
        }

        private void EX_NR1_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new ElectronicXAMuLator_01();
        }

        private void BWL_SPC_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new SalesPriceCaclculator_01();
        }


        private void Listaholic_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new Listaholic_01();
        }

        private void TPS_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new ThePossessedStoreman_01();
        }

        private void ListFan_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new ListFanatic01();
        }

        private void TRP_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new TheRestlessPrepper_01();
        }

        private void GamesCollection_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new GamesCollection_01();
        }

        private void VocMaster_Click(object sender, RoutedEventArgs e)
        {
            StoreWindow.Content = new Vocabulary_Master_01();
        }
    }
}
