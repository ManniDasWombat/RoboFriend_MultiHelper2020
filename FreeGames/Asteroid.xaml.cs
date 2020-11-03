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
using System.Windows.Shapes;

namespace RoboFriend_MultiHelper2020.FreeGames
{
    /// <summary>
    /// Interaktionslogik für Asteroid.xaml
    /// </summary>
    public partial class Asteroid : Window
    {
        public Asteroid()               // Die xaml Objekte werden hier erst aufgebaut, erst sobald diese Methode abgeschlossen ist, kann auf alle Eigenschaften der XAML Steuerelemente zugegeriffen werden, darum der Start button nötig als zweiter Schritt
        {
            InitializeComponent();          
        }

        private void BT_Start_Click(object sender, RoutedEventArgs e)
        {
            Meteor TestFelsen = new Meteor();
            TestFelsen.Object_Create(OuterSpace);
            TestFelsen.Object_Draw(OuterSpace);
            SpaceShip Babylon4 = new SpaceShip();
            Babylon4.Object_Create(OuterSpace);
            Babylon4.Object_Draw(OuterSpace);
        }
    }
}
