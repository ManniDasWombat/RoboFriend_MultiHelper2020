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
    /// Interaktionslogik für ListFanatic01.xaml
    /// </summary>
    public partial class ListFanatic01 : Page
    {
        public ListFanatic01()
        {
            InitializeComponent();
        }

        class DataAccess
        {

        }

        int IDtoCompare;
        List<EnglishWords> NewList_English = new List<EnglishWords>();
        List<GermanWords> NewList_German = new List<GermanWords>();


        private void TB_00_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TB_01_KeyDown(object sender, KeyEventArgs e) // Vergleichsbox Deutsche Übersetzung Vokabeleingabe
        {
            if (e.Key == Key.Return)
            {
                if (TB_01.Text == NewList_German[IDtoCompare].GermanWord1 || TB_01.Text == NewList_German[IDtoCompare].GermanWord2 || TB_01.Text == NewList_German[IDtoCompare].GermanWord3)
                {
                    TB_01.Background = System.Windows.Media.Brushes.GreenYellow;
                }
                else
                {
                    TB_01.Background = System.Windows.Media.Brushes.Red;
                }
            }
        }

        private void TB_10_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TB_11_KeyDown(object sender, KeyEventArgs e)
        {

        }




        private void BT_01_Click(object sender, RoutedEventArgs e) //Liste erzeugen Buttton
        {
            NewList_English = ListFanatic02.ListFanRobo_M_EW();
            LV_1.ItemsSource = NewList_English;

            NewList_German = ListFanatic02.ListFanRobo_M_GW();
            DG_1.ItemsSource = NewList_German;

        }

        private void BT_11_Click(object sender, RoutedEventArgs e) //löschen Button
        {
            DG_1.Columns.Clear();
            LV_1.ItemsSource = string.Empty;

            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FF05C9F5");
            TB_01.Background = brush;
        }

        private void BT_10_Click(object sender, RoutedEventArgs e) //Vokabel wählen Button
        {
            Vocabulary NewObjectNeededForDiceRobotPickerMethod = new Vocabulary();
            EnglishWords CurrentRiddleWord = NewObjectNeededForDiceRobotPickerMethod.DiceRobotPicker(NewList_English);

            TB_00.Text = CurrentRiddleWord.EnglishWord1;
            TB_10.Text = "Hilfe: " + CurrentRiddleWord.EnglishWord2;

            IDtoCompare = CurrentRiddleWord.Voc_ID;
            MessageBox.Show($"{IDtoCompare}");

        }
        private void BT_00_Click(object sender, RoutedEventArgs e) //speichern button
        {              
        }
    }  
}



