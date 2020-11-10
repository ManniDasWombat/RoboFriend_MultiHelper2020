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

        Meteor TestFelsen = new Meteor();
        SpaceShip Babylon4 = new SpaceShip();

        private void BT_Start_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < length; i++)
            {

            }
            
            TestFelsen.Object_Create(OuterSpace);
            TestFelsen.Object_Draw(OuterSpace);
            
            Babylon4.Object_Create(OuterSpace);
            Babylon4.Object_Draw(OuterSpace);
        }
    }
}
