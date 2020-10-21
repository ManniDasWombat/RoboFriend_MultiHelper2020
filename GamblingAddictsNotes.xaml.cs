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


        public GamblingAddictsNotes()
        {
            InitializeComponent();
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
    }
}
