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

        bool GameStart = false;
        Meteor TestFelsen = new Meteor();           // dient momentan nur noch für die Menge der Felsen länge der for Schleife
        SpaceShip Babylon4 = new SpaceShip();

        List<Meteor> MeteorSwarm = new List<Meteor>();

        private void BT_Start_Click(object sender, RoutedEventArgs e)
        {
            if (!GameStart)
            {
                GameStart = true;

                Babylon4.Object_Create(OuterSpace);
                Babylon4.Object_Draw(OuterSpace);

                for (int i = 0; i < TestFelsen.Object_Amount; i++)
                {
                    // MessageBox.Show(TestFelsen.Object_Amount.ToString());        // Test MeteorAnzahl

                    MeteorSwarm.Add(new Meteor());
                }

                foreach (Meteor item in MeteorSwarm)
                {
                    item.Object_Create(OuterSpace);
                    item.Object_Draw(OuterSpace);
                }

                BT_Start.Content = "Restart";
            }
            else if (GameStart)
            {
            }



        }
    }
}
