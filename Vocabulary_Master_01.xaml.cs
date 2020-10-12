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
    }
}
