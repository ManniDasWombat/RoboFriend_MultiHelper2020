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

        string FilePath = "Noch keine Liste geladen";
        public WW3_Classes LabelBindingValues = new WW3_Classes();

        public List<Vocable> TestListe_1 = new List<Vocable>();
        public List<Vocable> TestListe_2 = new List<Vocable>();

        public List<string> Sprachen = new List<string>
        {
            "English", "German"
        };

        private void BT_1_3_Click(object sender, RoutedEventArgs e)         // Liste laden
        {
            FilePath = null;
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
                            TestListe_1.Add(new Vocable { Verb = VerbR, Noun = NounR, Adjective = AdjectiveR, ThisVocsLanguage = "English", Language = Sprachen });
                        }
                        else if (sender == BT_2_3)
                        {
                            TestListe_2.Add(new Vocable { Verb = VerbR, Noun = NounR, Adjective = AdjectiveR, ThisVocsLanguage = "German", Language = Sprachen });
                        }
                    }
                }
                if (sender == BT_1_3)
                {
                    DG_1.ItemsSource = TestListe_1;
                    LBox_1.Items.Add(".csv List in Itemssource geladen");
                    LabelBindingValues.ListHeading = FilePath;                  
                    LB_1.Content = LabelBindingValues.ListHeading;              //Binding braucht INotifyPropertyChanged, darum jetzt einfachere Variante
                    LBox_1.Items.Add(".Label Updated");
                }
                else if (sender == BT_2_3)
                {
                    DG_2.ItemsSource = TestListe_2;
                    LBox_2.Items.Add(".csv List in Itemssource geladen");
                    LabelBindingValues.ListHeading = FilePath;
                    LB_2.Content = LabelBindingValues.ListHeading;
                    LBox_2.Items.Add(".Label Updated");
                }

            }

        }

        private void DG_1_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            LBox_1.Items.Add("Neuen Datensatz hinzugfügt");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)      // Page wird geladen
        {
            LabelBindingValues.ListHeading = FilePath;

            Binding NewBindingX = new Binding();
            NewBindingX.Source = LabelBindingValues.ListHeading;
            NewBindingX.Mode = BindingMode.OneWay;
            NewBindingX.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            LB_1.SetBinding(Label.ContentProperty, NewBindingX);
            LB_2.SetBinding(Label.ContentProperty, NewBindingX);                    //Binding funktioniert, aber will sich nicht updaten
        }
    }
}
