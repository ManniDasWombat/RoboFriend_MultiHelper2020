using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaktionslogik für TheRestlessPrepper_01.xaml
    /// </summary>
    public partial class TheRestlessPrepper_01 : Page
    {

        Dictionary<string, string> Dict_Kennzeichen = new Dictionary<string, string>();
        string StadtName;

        public TheRestlessPrepper_01()
        {
            InitializeComponent();
        }

        private void BT_1_Load_Click(object sender, RoutedEventArgs e)
        {
            PBar.Value++;
        }

        private void BT_2_Save_Click(object sender, RoutedEventArgs e)
        {
            PBar.Value++;
        }

        private void BT_3_Load_Click(object sender, RoutedEventArgs e)         // csv Liste laden
        {
            PBar.Value++;

            string ProjektVerzeichnis = System.IO.Path.GetDirectoryName(        // Versuch um Problem mit relativem Pfad zu lösen funktioniert
            System.Reflection.Assembly.GetExecutingAssembly().Location);
            string DateipfadRelativ = ProjektVerzeichnis + @"\kfz-kennzeichen-2020.csv";


            // Datei einlesen und Schlüssel-Wert-Paare in Dictionary speichern
            StreamReader StRd_X = new StreamReader(DateipfadRelativ, Encoding.UTF7);
            while (!StRd_X.EndOfStream)                                                         
            {
                string strLine = StRd_X.ReadLine();
                string[] strTeile = strLine.Split(';');
                string Kennzeichen = strTeile[0].Trim().ToUpper();
                string Stadt = strTeile[1].Trim();
                if (Kennzeichen.Length > 0)
                {
                    // Schlüssel-Wert-Paar zum Dictionary hinzufügen
                    Dict_Kennzeichen.Add(Kennzeichen, Stadt);
                }
            }
            DataG_2.Visibility = Visibility.Visible;
            DataG_2.ItemsSource = Dict_Kennzeichen;
            DataG_2.Items.Refresh();

        }

        private void BT_4_Save_Click(object sender, RoutedEventArgs e)
        {
            PBar.Value++;
        }

        private void TB_2_KeyDown(object sender, KeyEventArgs e)        // prüfen ob Key/=Kennzeichen in Liste ist und dann zugehörigen Value/=Stadt ausgeben
        {
            if (e.Key == Key.Return)
            {
                PBar.Value++;

                if (Dict_Kennzeichen.TryGetValue(TB_2.Text, out StadtName))     // Lösung 1
                {
                    PBar.Value++;

                    MessageBox.Show($"Das Kennzeichen existiert. Die Stadt heißt: {StadtName}");
                }
                else
                {
                    MessageBox.Show($"Das Kennzeichen existiert nicht.");
                }

                /*
                if (Dict_Kennzeichen.ContainsKey(TB_2.Text))            // Lösung 2 (Bube)
                {
                    PBar.Value++;

                    MessageBox.Show(Dict_Kennzeichen[TB_2.Text]);                  
                }
                */
            }


        }
    }
}