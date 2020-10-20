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

namespace RoboFriend_MultiHelper2020.FreeGames
{
    /// <summary>
    /// Interaktionslogik für FunfairShooter.xaml
    /// </summary>
    public partial class FunfairShooter : Window
    {
        private readonly DispatcherTimer animationstimer = new DispatcherTimer();

        private bool gehtnachrechts = true;
        private bool gehtnachunten = true;
        private bool fastmode = false;
        private int speed;
        private int zaehler;

        public FunfairShooter()
        {
            InitializeComponent();

            animationstimer.Interval = TimeSpan.FromMilliseconds(30);
            animationstimer.Tick += animetimerball_pos;
        }

        private void normalmodus_Checked(object sender, RoutedEventArgs e)
        {
            fastmode = false;
        }

        private void animetimerball_pos(object sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);

            if (fastmode == true)
            {
                speed = 14;
            }
            else
            {
                speed = 7;
            }

            if (gehtnachrechts)
            {
                Canvas.SetLeft(Ball, x + speed);
            }

            else
            {
                Canvas.SetLeft(Ball, x - speed);
            }

            if (x >= Spielfeld.ActualWidth - Ball.ActualWidth)

            {
                gehtnachrechts = false;
            }

            else if (x <= 0)
            {
                gehtnachrechts = true;
            }


            var y = Canvas.GetTop(Ball);

            if (gehtnachunten)

            {
                Canvas.SetTop(Ball, y + speed);
            }

            else
            {
                Canvas.SetTop(Ball, y - speed);
            }

            if (y >= Spielfeld.ActualHeight - Ball.ActualHeight)

            {
                gehtnachunten = false;
            }

            else if (y <= 0)
            {
                gehtnachunten = true;
            }
        }
        private void Ball_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (animationstimer.IsEnabled)
            {
                zaehler += 1;
                erstesLabel.Content = $"{zaehler} Clicks";
            }
        }

        private void Pionier_Click(object sender, RoutedEventArgs e)
        {

            if (animationstimer.IsEnabled)
            {
                animationstimer.Stop();
            }
            else
            {
                animationstimer.Start();
                zaehler = 0;
            }


            var mitteX = Spielfeld.ActualWidth / 2;
            var mitteY = Spielfeld.ActualHeight / 2;

            Canvas.SetLeft(Ball, mitteX);
            Canvas.SetTop(Ball, mitteY);
        }

        private void Speedleverage_Checked(object sender, RoutedEventArgs e)
        {
            fastmode = true;
        }
    }
}
