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
    /// Interaktionslogik für Vocabulary_Master_01.xaml
    /// </summary>
    public partial class Vocabulary_Master_01 : Page
    {

        string NewEnglishVoc;
        string NewGermanVoc;

        public Vocabulary_Master_01()
        {
            InitializeComponent();
            brush.ImageSource = new BitmapImage(new Uri(@".\Images\Vocabulary\E_To_D.png", UriKind.Relative));
            BT_Switch.Background = brush;

        }

        readonly ImageBrush brush = new ImageBrush();
        int ModuloSwitchButton = 1;

        private void BT_Switch_Click(object sender, RoutedEventArgs e)
        {
            if (ModuloSwitchButton % 2 == 0)
            {
                brush.ImageSource = new BitmapImage(new Uri(@".\Images\Vocabulary\E_To_D.png", UriKind.Relative));
                BT_Switch.Background = brush;
                ModuloSwitchButton++;
            }
            else if (ModuloSwitchButton % 2 != 0)
            {
                brush.ImageSource = new BitmapImage(new Uri(@".\Images\Vocabulary\D_To_E.png", UriKind.Relative));
                BT_Switch.Background = brush;
                ModuloSwitchButton++;
            }
        }

        private void BTN_Start_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            if (TB_E.Text != string.Empty && TB_D.Text != string.Empty)
            {
                var FollowUpQuestion = MessageBox.Show("Die Vokabel wirklich zur Liste hinzufügen?", "Bitte um Bestätigung", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (FollowUpQuestion == MessageBoxResult.Yes)
                {
                    NewEnglishVoc = TB_E.Text;
                    NewGermanVoc = TB_D.Text;

                    TB_E.Text = string.Empty;
                    TB_D.Text = string.Empty;
                }
                else if (FollowUpQuestion == MessageBoxResult.No)
                {
                    TB_E.Text = string.Empty;
                    TB_D.Text = string.Empty;
                }
            }
        }

        private void BTN_Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
