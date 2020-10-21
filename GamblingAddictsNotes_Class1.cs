using System;
using System.Collections.Generic;
using System.Text;

namespace RoboFriend_MultiHelper2020
{
    class GamblingAddictsNotes_Class1
    {
    }

    class DiceData
    {
        public int ID { get; set; }
        public int Eyes { get; set; }
        public int ThrowsCounter { get; set; }

    }

    class DiceMan
    {
        Random DiceRobot = new Random();

        public int CreateThrowDiceResult()
        {
            int Result = DiceRobot.Next(1, 7);
            return Result;
        }

        public List<DiceData> CreateStatsList()
        {
            List<DiceData> DiceDataList = new List<DiceData>();
            for (int i = 0; i < 6; i++)
            {
                DiceDataList.Add(new DiceData { ID = i, Eyes = i + 1, ThrowsCounter = 0 });
            }
            return DiceDataList;
        }
    }
}
