using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RoboFriend_MultiHelper2020.FreeGames
{
    
    class Asteroid_GameObjects      // Mutterklasse         // wird noch auf abstract gesetzt, weil es nie eine direkte Instanz von GameObjects geben wird, denn von dieser Klasse wird nur geerbt
    {
        public double Object_Position_X { get; set; }       // Die Kindelemente erben nur das leere Attribut (Wert=0) Object_Position_X mit Schreibrechten(wegen set;), aber was sie dann hineinschreiben, wird nicht aufs Elternelement/Basisklasse übertragen. Der Wert der Basisklasse bleibt immer so, wie hier festgelegt/bzw nicht festgelegt, also Null
        public double Object_Position_Y { get; set; }
        public double Object_Speed_X;                       // Geschwindigkeit benötigt auch die Info, wohin denn bewegt wird, darum 2 Werte
        public double Object_Speed_Y;
        public double Object_Size;

        static Random DiceMan = new Random();

        public void Object_Create(Canvas BattleGround)                 
        {   
            Object_Position_X = DiceMan.NextDouble() * BattleGround.ActualWidth;
            Object_Position_Y = DiceMan.NextDouble() * BattleGround.ActualHeight;
        }

        public virtual void Object_Draw(Canvas BattleGround)
        {
        }

    }


    class Meteor : Asteroid_GameObjects
    {

        public void Object_Create()         // hier muss Canvas im Parameter fehlen, sonst übernimmt er es nicht von der Basisklasse. Ebenso Virtual musste raus
        {
        }

        public override void Object_Draw(Canvas BattleGround)
        {
            Ellipse ELPS = new Ellipse();
            ELPS.Width = 20.0;
            ELPS.Height = 20.0;
            Canvas.SetLeft(ELPS, Object_Position_X);         // Besonderheit: Hier wird nicht die Instanz sondern die statische Methode der gesamten Klasse Canvas angesprochen
            Canvas.SetTop(ELPS, Object_Position_Y);
            ELPS.Fill = Brushes.Gray;
            BattleGround.Children.Add(ELPS);
        }
    }


    class SpaceShip : Asteroid_GameObjects
    {
        public void Object_Create()
        {
        }

        public override void Object_Draw(Canvas BattleGround)
        {
            Ellipse ELPS_2 = new Ellipse();
            ELPS_2.Width = 10.0;
            ELPS_2.Height = 10.0;
            Canvas.SetLeft(ELPS_2, Object_Position_X);         // Besonderheit: Hier wird nicht die Instanz sondern die statische Methode der gesamten Klasse Canvas angesprochen
            Canvas.SetTop(ELPS_2, Object_Position_Y);
            ELPS_2.Fill = Brushes.White;
            BattleGround.Children.Add(ELPS_2);
        }
    }


    class Weapon_A1 : Asteroid_GameObjects
    {
        public string Weapon_Name;
    }

}
