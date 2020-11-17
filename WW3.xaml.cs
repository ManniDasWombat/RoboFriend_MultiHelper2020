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
using System.Collections.ObjectModel;

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

        List<Kunde> TestListe_3 = new List<Kunde>();
        List<Kunde> TestListe_4 = new List<Kunde>();

        private void BT_1_3_Click(object sender, RoutedEventArgs e)         // Liste laden
        {
            DG_1.ItemsSource = null;

            DG_1.Items.Refresh();
            DG_2.Items.Refresh();

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
        private void DG_2_AddingNewItem(object sender, AddingNewItemEventArgs e)
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

        private void BT_2_4_Click(object sender, RoutedEventArgs e)
        {
            DG_2.ItemsSource = null;

            DG_1.Items.Refresh();
            DG_2.Items.Refresh();

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
                    string VorN = strTeile[0].Trim();
                    string NachN = strTeile[1].Trim();
                    string DateT = strTeile[2].Trim();
                    if (VorN.Length > 0)
                    {
                        if (sender == BT_1_4)
                        {
                            TestListe_3.Add(new Kunde(VorN, NachN, DateTime.Now ) { });
                        }
                        else if (sender == BT_2_4)
                        {
                            TestListe_4.Add(new Kunde(VorN, NachN, DateTime.Parse(DateT)) { });
                        }
                    }
                }
                if (sender == BT_1_4)
                {
                    DG_1.ItemsSource = TestListe_3;
                    LBox_1.Items.Add(".csv List in Itemssource geladen");
                    LabelBindingValues.ListHeading = FilePath;
                    LB_1.Content = LabelBindingValues.ListHeading;              //Binding braucht INotifyPropertyChanged, darum jetzt einfachere Variante
                    LBox_1.Items.Add(".Label Updated");
                }
                else if (sender == BT_2_4)
                {
                    DG_2.ItemsSource = TestListe_4;
                    LBox_2.Items.Add(".csv List in Itemssource geladen");
                    LabelBindingValues.ListHeading = FilePath;
                    LB_2.Content = LabelBindingValues.ListHeading;
                    LBox_2.Items.Add(".Label Updated");
                    Kunde Fritz = new Kunde("Fritz", "Meyer", DateTime.Now);
                    TestListe_4.Add(Fritz);
                    LBox_2.Items.Add("Kunde geadded");
                    DG_2.Items.Refresh();
                }

                // Datagrid veränderungen:  DG_2

                DataGridTextColumn NeueSpalte = new DataGridTextColumn();
                Binding NeuesBindingAttribut = new Binding("KundeID");
                //Set the properties on the new column
                NeueSpalte.Binding = NeuesBindingAttribut;
                NeueSpalte.Header = "Kundennummer:";
                //Add the column to the DataGrid
                DG_2.Columns.Add(NeueSpalte);

            }
        }

        private void CHB_11_Checked(object sender, RoutedEventArgs e)
        {
            DG_1.AutoGenerateColumns = true;

            ObservableCollection<DataGridColumn> SpaltenListe = DG_1.Columns;
            foreach (DataGridColumn VordefinSpalte in SpaltenListe)
            {
                VordefinSpalte.Visibility = Visibility.Collapsed;
                LBox_1.Items.Add(VordefinSpalte.Visibility.ToString());
            }
            

        }

        private void CHB_11_Unchecked(object sender, RoutedEventArgs e)
        {
            DG_1.AutoGenerateColumns = false;

            ObservableCollection<DataGridColumn> SpaltenListe = DG_1.Columns;
            foreach (DataGridColumn VordefinSpalte in SpaltenListe)
            {
                VordefinSpalte.Visibility = Visibility.Visible;
                LBox_1.Items.Add(VordefinSpalte.Visibility.ToString());
            }
        }

        private void DG_1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)      //falls checkbox aktiv, soll folgendes geprüft werden
        {

            LBox_1.Items.Add(e.Column.Header.ToString());       

            switch (e.Column.Header.ToString())                         // Header ist ja identisch mit Attributname auf standard, also sucht man gleichzeitig damit, ob in der QuellKlasse das Attribut enthalten ist
            {
                case "Verb":
                    e.Column.CanUserSort = false;
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Header = "SwitchÜberschrift1:";
                    break;
                case "Noun":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Header = "SwitchÜberschrift2:";
                    break;
                case "Vorname:":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Header = "SwitchÜberschrift3:";
                    break;
                case "Geburtstag":
                    e.Column.Visibility = Visibility.Visible;
                    e.Column.Header = "SwitchÜberschrift4:";
                    break;
                default:
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void BT_1_1_Click(object sender, RoutedEventArgs e)         // Alles löschen
        {
            if (LBox_1.HasItems)
            {
                LBox_1.Items.Clear();
            }
            if (DG_1.HasItems)
            {
                DG_1.ItemsSource = null;
            }
            if (DG_1.Items.NeedsRefresh)
            {
                DG_1.Items.Refresh();
                LBox_1.Items.Add("needed Refresh");
            }
        }

        private void BT_1_2_Click(object sender, RoutedEventArgs e)         // ObservativeCollection Versuche
        {

        }

        private void BT_2_1_Click(object sender, RoutedEventArgs e)         // DG 2 Test Spalten löschen
        {
            ObservableCollection<DataGridColumn> TestRemoveList = new ObservableCollection<DataGridColumn>();
            DG_2.Items.Refresh();
            foreach (DataGridColumn item in DG_2.Columns)
            {
                TestRemoveList.Add(item);
                DG_2.Columns.Remove(item);
            }
            foreach (var item in TestRemoveList)
            {

            }
            if (DG_2.Items.NeedsRefresh)
            {
                DG_2.Items.Refresh();
                LBox_2.Items.Add("needed Refresh");
            }
        }
    }

}
