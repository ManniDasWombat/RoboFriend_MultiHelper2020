using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFriend_MultiHelper2020
{
    class ThePossessedStoreman_class_01
    {
    }

    public class VokabelListe
    {
        public string Deutsch { get; set; }
        public string English { get; set; }

        public List<VokabelListe> NewRandomList(int AmountofRandom)
        {
            Random Number88 = new Random();

            List<VokabelListe> TheList = new List<VokabelListe>();
            for (int i = 0; i < AmountofRandom; i++)
            {
                TheList.Add(new VokabelListe() { English = Number88.Next(10, 999999).ToString(), Deutsch = Number88.Next(10, 999999).ToString() });
            }
            return TheList;
        }

        public bool SearchingTranslation(string Attempt, string ComparisonV, List<VokabelListe> COMP_LIST)
        {
            bool Back = false;
            int i = 0;
            foreach (var item in COMP_LIST)
            {
                if (ComparisonV == COMP_LIST[i].Deutsch)
                {
                    if (Attempt == COMP_LIST[i].English)
                    {
                        Back = true;
                    }
                }
                else if (ComparisonV == COMP_LIST[i].English)
                {
                    if (Attempt == COMP_LIST[i].Deutsch)
                    {
                        Back = true;
                    }
                }
                i++;
            }
            return Back;
        }

        public string PickWord(List<VokabelListe> COMP_LIST)
        {
            Random LotteryWord = new Random();
            int Winner = LotteryWord.Next(0, COMP_LIST.Count);
            return COMP_LIST[Winner].English;
        }
    }
}
