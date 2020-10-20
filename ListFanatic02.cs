using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFriend_MultiHelper2020
{
    public static class ListFanatic02   // Listen erstellen zum Test
    {
        public static List<EnglishWords> ListFanRobo_M_EW()
        {
            Random DiceRobot = new Random();
            List<EnglishWords> NewList_EW = new List<EnglishWords>();

            for (int i = 0; i <= 44; i++)
            {
                var RandomWordClass = WordClass.Verb;

                if (DiceRobot.Next(3) == 0)
                {
                    RandomWordClass = WordClass.Substantiv;
                }
                else if (DiceRobot.Next(3) == 1)
                {
                    RandomWordClass = WordClass.Verb;
                }
                else if (DiceRobot.Next(3) == 2)
                {
                    RandomWordClass = WordClass.Adjektiv;
                }

                NewList_EW.Add(new EnglishWords() { Voc_ID = i, EnglishWord1 = $"testvocabulary{DiceRobot.Next(1000)}", EnglishWord2 = $"altvocabulary{DiceRobot.Next(1000)}", EnglishWord3 = $"subaltvocabulary{DiceRobot.Next(1000)}", WordType = RandomWordClass });
            }         
            return NewList_EW;
        }

        public static List<GermanWords> ListFanRobo_M_GW()
        {
            Random DiceRobot = new Random();
            List<GermanWords> NewList_EW = new List<GermanWords>();
            for (int i = 0; i <= 44; i++)
            {
                var RandomWordClass = WordClass.Verb;

                if (DiceRobot.Next(3) == 0)
                {
                    RandomWordClass = WordClass.Substantiv;
                }
                else if (DiceRobot.Next(3) == 1)
                {
                    RandomWordClass = WordClass.Verb;
                }
                else if (DiceRobot.Next(3) == 2)
                {
                    RandomWordClass = WordClass.Adjektiv;
                }

                NewList_EW.Add(new GermanWords() { Voc_ID = i, GermanWord1 = $"testvocabulary{DiceRobot.Next(1000)}", GermanWord2 = $"altvocabulary{DiceRobot.Next(1000)}", GermanWord3 = $"subaltvocabulary{DiceRobot.Next(1000)}", WordType = RandomWordClass });
            }
            return NewList_EW;
        }
    }

    public class Vocabulary     // Wählt ein bereits mit Werten gefülltes EnglishWords Objekt aus vorher erzeugter Liste aus
    {
        Random DiceRobot = new Random();

        public EnglishWords DiceRobotPicker(List<EnglishWords> ExistingList_English)
        {
            EnglishWords Pick = ExistingList_English[DiceRobot.Next(ExistingList_English.Count)];
            return Pick;
        }

    }

    public enum WordClass { Verb, Substantiv, Adjektiv }

    public class EnglishWords
    {
        public int Voc_ID { get; set; }
        public string EnglishWord1 { get; set; }
        public string EnglishWord2 { get; set; }
        public string EnglishWord3 { get; set; }
        public WordClass WordType { get; set; }     // Bsp: = WordClass.Substantiv;

    }

    public class GermanWords
    {
        public int Voc_ID { get; set; }
        public string GermanWord1 { get; set; }
        public string GermanWord2 { get; set; }
        public string GermanWord3 { get; set; }
        public WordClass WordType { get; set; }     // Bsp: = WordClass.Substantiv;
    }
}
