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
            for (int i = 1; i <= 44; i++)
            {
                NewList_EW.Add(new EnglishWords() { Voc_ID = i, EnglishWord1 = $"testvocabulary{DiceRobot.Next(1000)}", EnglishWord2 = $"altvocabulary{DiceRobot.Next(1000)}", EnglishWord3 = $"subaltvocabulary{DiceRobot.Next(1000)}" });
            }         
            return NewList_EW;
        }

        public static List<GermanWords> ListFanRobo_M_GW()
        {
            Random DiceRobot = new Random();
            List<GermanWords> NewList_EW = new List<GermanWords>();
            for (int i = 1; i <= 44; i++)
            {
                NewList_EW.Add(new GermanWords() { Voc_ID = i, GermanWord1 = $"testvocabulary{DiceRobot.Next(1000)}", GermanWord2 = $"altvocabulary{DiceRobot.Next(1000)}", GermanWord3 = $"subaltvocabulary{DiceRobot.Next(1000)}" });
            }
            return NewList_EW;
        }
    }

    public class Vocabulary
    {
        Random DiceRobot = new Random();

        public EnglishWords DiceRobotPicker(List<EnglishWords> ExistingList_English)
        {
            EnglishWords Pick = ExistingList_English[DiceRobot.Next(ExistingList_English.Count)];
            return Pick;
        }

    }

    public class EnglishWords
    {
        public int Voc_ID { get; set; }
        public string EnglishWord1 { get; set; }
        public string EnglishWord2 { get; set; }
        public string EnglishWord3 { get; set; }
    }

    public class GermanWords
    {
        public int Voc_ID { get; set; }
        public string GermanWord1 { get; set; }
        public string GermanWord2 { get; set; }
        public string GermanWord3 { get; set; }
    }
}
