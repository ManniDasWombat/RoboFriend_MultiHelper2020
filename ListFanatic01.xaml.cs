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




        private void TB_00_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TB_01_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TB_10_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TB_11_KeyDown(object sender, KeyEventArgs e)
        {

        }




        private void BT_01_Click(object sender, RoutedEventArgs e) //Laden Buttton
        {
            List<EnglishWords> NewList_English = ListFanatic02.ListFanRobo_M_EW();
            LV_1.ItemsSource = NewList_English;

            List<GermanWords> NewList_German = ListFanatic02.ListFanRobo_M_GW();
            DG_1.ItemsSource = NewList_German;


            Vocabulary NewObjectNeededForDiceRobotPickerMethod = new Vocabulary();
            EnglishWords CurrentRiddleWord = NewObjectNeededForDiceRobotPickerMethod.DiceRobotPicker(NewList_English);

            TB_00.Text = CurrentRiddleWord.EnglishWord1;
            TB_10.Text = "Hilfe: " + CurrentRiddleWord.EnglishWord2;

        }

        private void BT_11_Click(object sender, RoutedEventArgs e) //löschen Button
        {
            DG_1.Columns.Clear();
            LV_1.ItemsSource = string.Empty;
        }

       private void BT_10_Click(object sender, RoutedEventArgs e) //anzeigen Button
        {

        }
    }
}
