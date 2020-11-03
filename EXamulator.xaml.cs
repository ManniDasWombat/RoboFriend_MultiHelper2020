using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaktionslogik für EXamulator.xaml
    /// </summary>
    public partial class EXamulator : Page
    {
        public EXamulator()
        {
            InitializeComponent();
        }

        private void TB_001_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_001.Text = String.Empty;
        }


    }
}
