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
            Spieler.VereinEnum XY_SV;
            XY_SV = Spieler.VereinEnum.BVB;
            switch (TestZahlGenerator.Next(0, 4))
            {
                case 1: XY_SV = Spieler.VereinEnum.BVB; break;
                case 2: XY_SV = Spieler.VereinEnum.Bayern; break;
                case 3: XY_SV = Spieler.VereinEnum.FC_Schalke_04; break;
            }
            return XY_SV;
        }
    }

    class Spieler
    {
        public enum VereinEnum { BVB, Bayern, FC_Schalke_04 }


        public int Spieler_ID { get; set; }
        public string Vorname { get; set; }
        public string Name { get; set; }
        public VereinEnum Verein { get; set; }
        public int Geburtsjahr { get; set; }
        public int Alter { get; set; }
    }
}
