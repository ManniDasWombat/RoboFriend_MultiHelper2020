using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace RoboFriend_MultiHelper2020.FreeGames
{
    /// <summary>
    /// Interaktionslogik für ButtonPuzzle.xaml
    /// </summary>
    public partial class ButtonPuzzle : Window
    {
        public ButtonPuzzle()
        {
            InitializeComponent();
            Stopwatch.Tick += new EventHandler(Stopwatch_StartEvent);
            Stopwatch.Interval = new TimeSpan(0, 0, 1);
        }

        public class PuzzlePlayer
        {
            public string Name;
        }


        int TimerZahl = 0;
        public void Stopwatch_StartEvent(object sender, EventArgs e)
        {
            TimerZahl++;
            if (TimerZahl >= 6)
            {
                LB_Timer.Visibility = Visibility.Visible;
                LB_Timer.Content = (TimerZahl - 5).ToString();
            }
            else if (TimerZahl == 1)
            {
                LB_Level1Display.Visibility = Visibility.Visible;
                LB_Level1Display.Content = $"Level 1";
            }
            else if (TimerZahl == 2 || TimerZahl == 3)
            {
                string Xneuezeile = Environment.NewLine;
                LB_Level1Display.Content = $"Let's go{Xneuezeile}{PlayerList[0].Name}";
            }
            else if (TimerZahl == 4)
            {
                LB_Level1Display.Content = $"Fight!!!";
            }
            else if (TimerZahl == 5)
            {
                LB_Level1Display.Content = $"";
                LB_Level1Display.Visibility = Visibility.Collapsed;
                b16.IsEnabled = false;

                for (int i = 0; i <= Allbuttons.Length - 2; i++)
                {
                    int ButtonToMixB = RandomGEN.Next(0, Allbuttons.Length - 2);

                    while (i == ButtonToMixB)
                    {
                        ButtonToMixB = RandomGEN.Next(0, Allbuttons.Length - 2);
                    }

                    int ButtonToMixA_Row = Grid.GetRow(Allbuttons[i]);
                    int ButtonToMixA_Column = Grid.GetColumn(Allbuttons[i]);
                    int ButtonToMixB_Row = Grid.GetRow(Allbuttons[ButtonToMixB]);
                    int ButtonToMixB_Column = Grid.GetColumn(Allbuttons[ButtonToMixB]);

                    Grid.SetRow(Allbuttons[i], ButtonToMixB_Row);
                    Grid.SetColumn(Allbuttons[i], ButtonToMixB_Column);
                    Grid.SetRow(Allbuttons[ButtonToMixB], ButtonToMixA_Row);
                    Grid.SetColumn(Allbuttons[ButtonToMixB], ButtonToMixA_Column);
                }
            }

        }

        public List<PuzzlePlayer> PlayerList = new List<PuzzlePlayer>();

        public DispatcherTimer Stopwatch = new DispatcherTimer();

        public int NowPressed_BT;
        public int Deactivated_BT;

        public Button[] Allbuttons = new Button[16];

        public int Status_XY = 0;
        public int Completion_Q = 0;

        public Random RandomGEN = new Random();

        public List<int> BT_Start_Rows = new List<int>();
        public List<int> BT_Start_Columns = new List<int>();
        public List<int> BT_Start_Rows_Check = new List<int>();
        public List<int> BT_Start_Columns_Check = new List<int>();


        public void All_btns_click(object sender, RoutedEventArgs e)
        {
            if (BT_Start01 == sender)
            {
                Allbuttons[0] = b01;
                Allbuttons[1] = b02;
                Allbuttons[2] = b03;
                Allbuttons[3] = b04;
                Allbuttons[4] = b05;
                Allbuttons[5] = b06;
                Allbuttons[6] = b07;
                Allbuttons[7] = b08;
                Allbuttons[8] = b09;
                Allbuttons[9] = b10;
                Allbuttons[10] = b11;
                Allbuttons[11] = b12;
                Allbuttons[12] = b13;
                Allbuttons[13] = b14;
                Allbuttons[14] = b15;
                Allbuttons[15] = b16;

                BT_Start01.Visibility = Visibility.Collapsed;
                Startlabeltext.Visibility = Visibility.Collapsed;
                CA_StartPopup01.Visibility = Visibility.Collapsed;

                var SpielerX = new PuzzlePlayer { Name = TB_Player.Text };
                PlayerList.Add(SpielerX);

                foreach (Button B in Allbuttons)
                {
                    int GET_Gridpositions_Zeile = Grid.GetRow(B);
                    int GET_Gridpositions_Spalte = Grid.GetColumn(B);

                    BT_Start_Rows.Add(GET_Gridpositions_Zeile);
                    BT_Start_Columns.Add(GET_Gridpositions_Spalte);
                }
                Stopwatch.Start();
            }

            else if (BT_Start01 != sender)
            {
                for (int i = 0; i < Allbuttons.Length; i++)
                {
                    if (Allbuttons[i] == sender)
                    {
                        NowPressed_BT = i;
                    }
                    if (Allbuttons[i].IsEnabled == false)
                    {
                        Deactivated_BT = i;
                    }
                }

                int NowPressed_BT_Zeile = Grid.GetRow(Allbuttons[NowPressed_BT]);
                int NowPressed_BT_Spalte = Grid.GetColumn(Allbuttons[NowPressed_BT]);

                int Deactivated_BT_Zeile = Grid.GetRow(Allbuttons[Deactivated_BT]);
                int Deactivated_BT_Spalte = Grid.GetColumn(Allbuttons[Deactivated_BT]);

                if (((NowPressed_BT_Zeile == Deactivated_BT_Zeile - 1 || NowPressed_BT_Zeile == Deactivated_BT_Zeile + 1) && NowPressed_BT_Spalte == Deactivated_BT_Spalte)
                    || ((NowPressed_BT_Spalte == Deactivated_BT_Spalte - 1 || NowPressed_BT_Spalte == Deactivated_BT_Spalte + 1) && NowPressed_BT_Zeile == Deactivated_BT_Zeile))
                {
                    Grid.SetRow(Allbuttons[NowPressed_BT], Deactivated_BT_Zeile);
                    Grid.SetColumn(Allbuttons[NowPressed_BT], Deactivated_BT_Spalte);

                    Grid.SetRow(Allbuttons[Deactivated_BT], NowPressed_BT_Zeile);
                    Grid.SetColumn(Allbuttons[Deactivated_BT], NowPressed_BT_Spalte);
                }

                foreach (Button B in Allbuttons)
                {
                    int GET_Gridpositions_Zeile = Grid.GetRow(B);
                    int GET_Gridpositions_Spalte = Grid.GetColumn(B);

                    BT_Start_Rows_Check.Add(GET_Gridpositions_Zeile);
                    BT_Start_Columns_Check.Add(GET_Gridpositions_Spalte);

                    if (BT_Start_Rows[Status_XY] == BT_Start_Rows_Check[Status_XY] && BT_Start_Columns[Status_XY] == BT_Start_Columns_Check[Status_XY])
                    {
                        Completion_Q++;
                    }
                    Status_XY++;
                }

                if (Completion_Q == 16)
                {
                    MessageBox.Show($"Wunderbar! Du hast es gelöst! Du hast {TimerZahl} Sekunden gebraucht.");
                    Stopwatch.Stop();
                    BT_Start_Rows.Clear();
                    BT_Start_Columns.Clear();
                    BT_Start_Rows_Check.Clear();
                    BT_Start_Columns_Check.Clear();
                }
                Status_XY = 0;
                Completion_Q = 0;
                BT_Start_Rows_Check.Clear();
                BT_Start_Columns_Check.Clear();
            }
        }

        private void TB_Player_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Player.Text = string.Empty;
        }
    }
}
