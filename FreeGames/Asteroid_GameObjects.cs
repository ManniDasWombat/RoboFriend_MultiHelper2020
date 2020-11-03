using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFriend_MultiHelper2020.FreeGames
{
    class Asteroid_GameObjects      // Mutterklasse         // wird noch auf abstract gesetzt, weil es nie eine direkte Instanz von GameObjects geben wird, denn von dieser Klasse wird nur geerbt
    {
        public double ObjectSpeed;
        public double ObjectSize;
    }

    class Meteor : Asteroid_GameObjects
    {

    }

    class SpaceShip : Asteroid_GameObjects
    {

    }

    class Weapon_A1 : Asteroid_GameObjects
    {
        public string Weapon_Name;
    }

}
