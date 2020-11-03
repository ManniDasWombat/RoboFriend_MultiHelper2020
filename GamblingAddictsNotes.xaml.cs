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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RoboFriend_MultiHelper2020
{
    /// <summary>
    /// Interaktionslogik für GamblingAddictsNotes.xaml
    /// </summary>
    public partial class GamblingAddictsNotes : Page
    {

        int DiceRepeats;
        List<DiceData> DiceDataList = new List<DiceData>(); 
        List<int> DiceRolls_NumberAndResults = new List<int>();
        int Counter;
        Random DiceRobotX = new Random();
        public DispatcherTimer StopWatchX = new DispatcherTimer();
        int ThrownR;

        List<Label> LBS_DiceResults = new List<Label>();
        int I = 0;

        public GamblingAddictsNotes()
        {
            InitializeComponent();
            StopWatchX.Tick += new EventHandler(StopWatchX_StartEvent);
            StopWatchX.Interval = TimeSpan.FromMilliseconds(77);
            LBS_DiceResults.Add(LB_Number1);
            LBS_DiceResults.Add(LB_Number2);
            LBS_DiceResults.Add(LB_Number3);
            LBS_DiceResults.Add(LB_Number4);
            LBS_DiceResults.Add(LB_Number5);
            LBS_DiceResults.Add(LB_Number6);
            LBS_DiceResults.Add(LB_Number7);
            LBS_DiceResults.Add(LB_Number8);
        }

        public void StopWatchX_StartEvent(object sender, EventArgs e)
        {
            ThrownR = DiceRobotX.Next(1, 7);
            switch (ThrownR)
            {
                case 1:
                    DiceImage.Source = new BitmapImage(new Uri(@"./Images/DicesImages/1.jpg", UriKind.Relative));
                    break;
                case 2:
                    DiceImage.Source = new BitmapImage(new Uri(@"./Images/DicesImages/2.jpg", UriKind.Relative));
                    break;
                case 3:
                    DiceImage.Source = new BitmapImage(new Uri(@"./Images/DicesImages/3.jpg", UriKind.Relative));
                    break;
                case 4:
                    DiceImage.Source = new BitmapImage(new Uri(@"./Images/DicesImages/4.jpg", UriKind.Relative));
                    break;
                case 5:
                    DiceImage.Source = new BitmapImage(new Uri(@"./Images/DicesImages/5.jpg", UriKind.Relative));
                    break;
                case 6:
                    DiceImage.Source = new BitmapImage(new Uri(@"./Images/DicesImages/6.jpg", UriKind.Relative));
                    break;
                default:
                    MessageBox.Show($"An unexpected value ({ThrownR}) has been rolled, how is it possible?!");
                    break;                 
            }

            LBS_DiceResults[I].Content = ThrownR;
            I++;
            if (I == 7)
            {
                I = 0;
            }


            PR_Bar.Value += 10;
            if (PR_Bar.Value == 100)
            {
                PR_Bar.Value = 0;
            }
        }

        private void TB_1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                if (int.TryParse(TB_1.Text, out DiceRepeats))
                {
                    DiceMan NewGuy = new DiceMan();
                    DiceDataList = NewGuy.CreateStatsList();

                    for (int i = 0; i < DiceRepeats; i++)
                    {
                        DiceRolls_NumberAndResults.Add(NewGuy.CreateThrowDiceResult());
                    }

                    TextBlock_01.Visibility = Visibility.Visible;
                    DiceBulletin.Visibility = Visibility.Collapsed;

                    foreach (int item in DiceRolls_NumberAndResults)
                    {
                        TextBlock_01.Text += item.ToString()+"  ";
                    }

                    foreach (int item in DiceRolls_NumberAndResults)
                    {
                        Counter = 0;

                        if (item == 1)
                        {
                            foreach (DiceData Item in DiceDataList)
                            {                             
                                if (Item.Eyes == 1)
                                {
                                    DiceDataList[Counter].ThrowsCounter++;
                                }
                                Counter++;
                            }                           
                        }

                        else if (item == 2)
                        {
                            foreach (DiceData Item in DiceDataList)
                            {
                                if (Item.Eyes == 2)
                                {
                                    DiceDataList[Counter].ThrowsCounter++;
                                }
                                Counter++;
                            }
                        }

                        else if (item == 3)
                        {
                            foreach (DiceData Item in DiceDataList)
                            {
                                if (Item.Eyes == 3)
                                {
                                    DiceDataList[Counter].ThrowsCounter++;
                                }
                                Counter++;
                            }
                        }

                        else if (item == 4)
                        {
                            foreach (DiceData Item in DiceDataList)
                            {
                                if (Item.Eyes == 4)
                                {
                                    DiceDataList[Counter].ThrowsCounter++;
                                }
                                Counter++;
                            }
                        }

                        else if (item == 5)
                        {
                            foreach (DiceData Item in DiceDataList)
                            {
                                if (Item.Eyes == 5)
                                {
                                    DiceDataList[Counter].ThrowsCounter++;
                                }
                                Counter++;
                            }
                        }

                        else if (item == 6)
                        {
                            foreach (DiceData Item in DiceDataList)
                            {
                                if (Item.Eyes == 6)
                                {
                                    DiceDataList[Counter].ThrowsCounter++;
                                }
                                Counter++;
                            }
                        }
                    }

                } 
            }
            else if (e.Key == Key.D)
            {
                TextBlock_01.Text = string.Empty;
                DiceBulletin.Columns.Clear();
                DiceRolls_NumberAndResults.Clear();
                DiceDataList.Clear();
                TB_1.Text = string.Empty;
                DiceRepeats = 0;
            }
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_01.Visibility = Visibility.Collapsed;
            DiceBulletin.Visibility = Visibility.Visible;
            DiceBulletin.ItemsSource = DiceDataList;
        }

        private void RollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!StopWatchX.IsEnabled)
            {
                RollDiceButton.Content = "S T O P";
                StopWatchX.Start();
            }
            else if (StopWatchX.IsEnabled)
            {    
                RollDiceButton.Content = "P L A Y";
                StopWatchX.Stop();
            }
        }
    } 
}
