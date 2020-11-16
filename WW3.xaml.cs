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
using System.IO;
using Microsoft.Win32;


namespace RoboFriend_MultiHelper2020
{
    public partial class WW3 : Page
    {
        public WW3()
        {
            InitializeComponent();
        }

        List<Vocable> TestListe_1 = new List<Vocable>();
        List<Vocable> TestListe_2 = new List<Vocable>();

        private void BT_1_3_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = null;
            OpenFileDialog FileDialogNameX = new OpenFileDialog();
            FileDialogNameX.RestoreDirectory = true;
            FileDialogNameX.Filter = "CSV Dateien Anzeigen (*.csv)|*.csv";
            if (FileDialogNameX.ShowDialog() == true)
            {
                FilePath = FileDialogNameX.FileName;
            }
            if (FilePath != null)
            {
                StreamReader SR_X = new StreamReader(FilePath);
                while (!SR_X.EndOfStream)
                {
                    string strLine = SR_X.ReadLine();
                    string[] strTeile = strLine.Split(';');
                    string VerbR = strTeile[0].Trim();
                    string NounR = strTeile[1].Trim();
                    string AdjectiveR = strTeile[2].Trim();
                    if (VerbR.Length > 0)
                    {
                        if (sender == BT_1_3)
                        {
                            TestListe_1.Add(new Vocable { Verb = VerbR, Noun = NounR, Adjective = AdjectiveR });
                        }
                        else if (sender == BT_2_3)
                        {
                            TestListe_2.Add(new Vocable { Verb = VerbR, Noun = NounR, Adjective = AdjectiveR });
                        }
                    }
                }
                DG_1.ItemsSource = TestListe_1;
                DG_2.ItemsSource = TestListe_2;
                LBox_1.Items.Add(".csv List in Itemssource geladen");
            }



        }

        private void DG_1_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            LBox_1.Items.Add("Neuen Datensatz hinzugfügt");
        }
    }
}
