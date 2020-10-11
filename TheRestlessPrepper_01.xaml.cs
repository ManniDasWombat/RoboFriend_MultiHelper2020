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
    /// Interaktionslogik für TheRestlessPrepper_01.xaml
    /// </summary>
    public partial class TheRestlessPrepper_01 : Page
    {
        public TheRestlessPrepper_01()
        {
            InitializeComponent();
        }

        //Klasse
        class Auto
        {
            // Attribute
            public string Hersteller;
            public string Modell;

            // Methoden
            public string MethodeAusgabeWerte()
            {
                string back = $"Hersteller: {Hersteller}\nModell: {Modell}\n";
                return back;
            }
        }

        List<Auto> AutoListe = new List<Auto>();

        public void TESTBUTTON_Click(object sender, RoutedEventArgs e)
        {
            Auto NewAuto = new Auto();
            NewAuto.Hersteller = TB_Attribut1.Text;
            NewAuto.Modell = TB_Attribut2.Text;
            AutoListe.Add(NewAuto);
        }
        private void TESTBUTTON2_Click(object sender, RoutedEventArgs e)
        {
            int Nummer = 0;
            foreach (Auto item in AutoListe)
            {
                TB_TESTBLOCK.Text += $"{AutoListe[Nummer].MethodeAusgabeWerte()}\n";
                Nummer++;
            }
            TB_TESTBLOCK.Text += $"\n Anzahl Autos in AutoListe: {AutoListe.Count}";

        }
    }
}