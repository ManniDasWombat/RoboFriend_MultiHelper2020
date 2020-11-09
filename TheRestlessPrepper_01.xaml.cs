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
        List<Spieler> SpielerListeX = new List<Spieler>();


        Dictionary<string, string> Dict_Kennzeichen = new Dictionary<string, string>();
        string StadtName;

        public TheRestlessPrepper_01()
        {
            InitializeComponent();
        }


        private void BT_3_Load_Click(object sender, RoutedEventArgs e)         // csv Liste laden
        {
            PBar.Value++;

            string ProjektVerzeichnis = System.IO.Path.GetDirectoryName(        // Versuch um Problem mit relativem Pfad zu lösen funktioniert
            System.Reflection.Assembly.GetExecutingAssembly().Location);
            string DateipfadRelativ = ProjektVerzeichnis + @"\kfz-kennzeichen-2020.csv";



            // Lösung B mit zweidimensionalem Array
            // nur für größenzählung des [,]Arrays wird hier eine instanz streamreader erzeugt
            int ZaehlerArray = 0;          
            StreamReader StRd_ZX = new StreamReader(DateipfadRelativ, Encoding.UTF7);
            while (!StRd_ZX.EndOfStream)
            {
                string strLine = StRd_ZX.ReadLine();
                string[] strTeile = strLine.Split(';');
                string Kennzeichen = strTeile[0].Trim().ToUpper();
                string Stadt = strTeile[1].Trim();
                if (Kennzeichen.Length > 0)
                {
                    ZaehlerArray++;
                }
            }
            string[,] ARRAYLOESUNG2 = new string[ZaehlerArray, 2];




            int D1 = 0;

            StreamReader StRd_X = new StreamReader(DateipfadRelativ, Encoding.UTF7);
            while (!StRd_X.EndOfStream)                                                         
            {
                string strLine = StRd_X.ReadLine();
                string[] strTeile = strLine.Split(';');
                string Kennzeichen = strTeile[0].Trim().ToUpper();
                string Stadt = strTeile[1].Trim();
                if (Kennzeichen.Length > 0)
                {
                    Dict_Kennzeichen.Add(Kennzeichen, Stadt); // Lösung A

                    ARRAYLOESUNG2[D1, 0] = Kennzeichen;     // Lösung B (2dim Array)
                    ARRAYLOESUNG2[D1, 1] = Stadt;
                    D1++;
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
                
                
                if (Dict_Kennzeichen.TryGetValue(TB_2.Text, out StadtName))     // Lösung A 1
                {
                    PBar.Value++;

                    MessageBox.Show($"Das Kennzeichen existiert. Die Stadt heißt: {StadtName}");

                }
                else
                {
                    MessageBox.Show($"Das Kennzeichen existiert nicht.");
                }
                

                /*
                if (Dict_Kennzeichen.ContainsKey(TB_2.Text))            // Lösung A 2
                {
                    PBar.Value++;
                    MessageBox.Show(Dict_Kennzeichen[TB_2.Text]);
                }
                */

            }


        }

        private void TB_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

                string DateiPfadUndNameX = @"Versuch.txt";
                StreamWriter SW_X = new StreamWriter(DateiPfadUndNameX);
                SW_X.WriteLine(TB_2.Text);                                // Datei wird erstellt, aber kein Inhalt
                SW_X.Write(TB_2.Text);
                File.WriteAllText(@"Dateiname.txt", TB_2.Text);

                // will keine Inhalte einfüllen
            }
        }

        private void BT_1_Load_Click(object sender, RoutedEventArgs e)
        {
            PBar.Value++;

            string Zufallsvorname;
            string Zufallsnachname;
            int Zufallszahl;

            DiceManStuff ZufallsgenKlasse = new DiceManStuff();
            Zufallszahl = ZufallsgenKlasse.TestZahlGenerator.Next(0, 30);
            Zufallsvorname = ZufallsgenKlasse.ZufallszahlX(20);
            Zufallsnachname = ZufallsgenKlasse.ZufallszahlX(10);
            Spieler.VereinEnum Zufallsverein = ZufallsgenKlasse.ZuteilungVerein();

            SpielerListeX.Add(new Spieler { Spieler_ID = SpielerListeX.Count + 1, Vorname = Zufallsvorname, Name = Zufallsnachname, Verein = ZufallsgenKlasse.ZuteilungVerein(), Geburtsjahr = 2020 - Zufallszahl, Alter = Zufallszahl });

            DataG_1.Visibility = Visibility.Visible;
            DataG_1.ItemsSource = SpielerListeX;
            DataG_1.Items.Refresh();
        }

        private void BT_2_Save_Click(object sender, RoutedEventArgs e)
        {
            PBar.Value++;
        }
    }
}