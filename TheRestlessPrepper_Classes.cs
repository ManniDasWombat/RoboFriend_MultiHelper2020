using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFriend_MultiHelper2020
{
    class TheRestlessPrepper_Classes
    {
    }

    class DiceManStuff
    {
        public Random TestZahlGenerator = new Random();

        public string ZufallszahlX(int AnzahlCHARS)
        {
            string Zufallsname = "";
            for (int i = 0; i < AnzahlCHARS; i++)
            {
                char ZufallsZeichen = (char)(TestZahlGenerator.Next(65, 122));
                Zufallsname += ZufallsZeichen;
            }
            return Zufallsname;
        }
        
        public Spieler.VereinEnum ZuteilungVerein()
        {
            switch (TestZahlGenerator.Next(1, 4))
            {
                case 1: return Spieler.VereinEnum.BVB;
                case 2: return Spieler.VereinEnum.Bayern;
                case 3: return Spieler.VereinEnum.FC_Schalke_04;
                default: return Spieler.VereinEnum.Kein_Verein;
            }
        }
    }

    class Spieler
    {
        public enum VereinEnum { BVB, Bayern, FC_Schalke_04, Kein_Verein }


        public int Spieler_ID { get; set; }
        public string Vorname { get; set; }
        public string Name { get; set; }
        public VereinEnum Verein { get; set; }
        public int Geburtsjahr { get; set; }
        public int Alter { get; set; }
    }
}
