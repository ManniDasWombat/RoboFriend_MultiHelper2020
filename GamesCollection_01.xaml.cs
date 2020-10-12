using RoboFriend_MultiHelper2020.FreeGames;
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
    /// Interaktionslogik für GamesCollection_01.xaml
    /// </summary>
    public partial class GamesCollection_01 : Page
    {
        public GamesCollection_01()
        {
            InitializeComponent();
            Button1.Content = "Göttisheimer\nThe Puzzle";
            Button2.Content = "Funfair Shooter";
        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ButtonPuzzle GoettisheimerTP = new ButtonPuzzle();
            GoettisheimerTP.Show();
        }
    }
}
