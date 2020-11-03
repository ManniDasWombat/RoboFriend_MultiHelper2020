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
            Button1.Content = "GöttisheimER\nThe Puzzle";
            Button2.Content = "Funfair Shooter";
            Button3.Content = "Game Of Life";
            Button4.Content = "Asteroid";
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ButtonPuzzle GoettisheimerTP = new ButtonPuzzle();
            GoettisheimerTP.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            FunfairShooter FunFairShoot = new FunfairShooter();
            FunFairShoot.Show();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            GameOfLife SimpleLife = new GameOfLife();
            SimpleLife.Show();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Asteroid AsteroidGame = new Asteroid();
            AsteroidGame.Show();
        }
    }
}
