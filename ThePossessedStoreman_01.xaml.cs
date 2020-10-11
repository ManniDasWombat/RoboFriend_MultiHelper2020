using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaktionslogik für ThePossessedStoreman_01.xaml
    /// </summary>
    public partial class ThePossessedStoreman_01 : Page
    {
        public ThePossessedStoreman_01()
        {
            InitializeComponent();
        }
        readonly string NewRow = Environment.NewLine;
        public int TestWert;
        string ComparisonVXZ;

        public List<VokabelListe> Complete_List = new List<VokabelListe>();
        public List<VokabelListe> RandomListToAdd_List = new List<VokabelListe>();

        public List<string> DeutscheVoks = new List<string>();
        public List<string> EnglischeVoks = new List<string>();

        private void BT_01_Click(object sender, RoutedEventArgs e) // speichern Button
        {
            Complete_List.Add(new VokabelListe() { English = TB_01.Text, Deutsch = TB_11.Text });   // Kurzform alle Elemente aus Klasse in eine Liste für Listview

            TBlock_1.Visibility = Visibility.Visible;
            TBlock_2.Visibility = Visibility.Visible;
            LV_1.Visibility = Visibility.Collapsed;
            LV_2.Visibility = Visibility.Collapsed;

            TBlock_1.Text += TB_01.Text + NewRow;
            TBlock_2.Text += TB_11.Text + NewRow;

            TB_01.Text = string.Empty;
            TB_11.Text = string.Empty;

            DeutscheVoks.Clear();                                   // Listen löschen vor erneutem Befüllen, falls speichern mehrfach betätigt wird
            EnglischeVoks.Clear();

            for (int i = 0; i < Complete_List.Count; i++)           // Elemente aus Klasse einzeln in Listen für Streamwriter/File WriteAllLines Befehl
            {
                DeutscheVoks.Add(Complete_List[i].Deutsch);
                EnglischeVoks.Add(Complete_List[i].English);
            }

            if (!Directory.Exists(@"SaveLists\"))
            {
                string pfaderstellen = @"SaveLists\";
                Directory.CreateDirectory(pfaderstellen);
            }

            File.WriteAllLines(@"SaveLists\VokabelnDsingle.txt", DeutscheVoks);
            File.WriteAllLines(@"SaveLists\VokabelnEsingle.txt", EnglischeVoks);
        }

        private void BT_02_Click(object sender, RoutedEventArgs e) // anzeigen Button
        {
            TBlock_1.Visibility = Visibility.Collapsed;
            TBlock_2.Visibility = Visibility.Collapsed;
            LV_1.Visibility = Visibility.Visible;
            LV_2.Visibility = Visibility.Visible;

            LV_1.ItemsSource = Complete_List;
            LV_2.ItemsSource = "";
        }

        public void BT_11_Click(object sender, RoutedEventArgs e)// laden Button
        {
            if (File.Exists(@"SaveLists\VokabelnEsingle.txt") && File.Exists(@"SaveLists\VokabelnDsingle.txt"))
            {
                string[] AlteListeEnglisch = File.ReadAllLines(@"SaveLists\VokabelnEsingle.txt");
                string[] AlteListeDeutsch = File.ReadAllLines(@"SaveLists\VokabelnDsingle.txt");

                for (int i = 0; i < AlteListeEnglisch.Length; i++)
                {
                    Complete_List.Add(new VokabelListe { English = AlteListeEnglisch[i], Deutsch = AlteListeDeutsch[i] });
                }
                Array.Clear(AlteListeDeutsch, 0, AlteListeDeutsch.Length);
                Array.Clear(AlteListeEnglisch, 0, AlteListeEnglisch.Length);
            }

            int Result = Complete_List.Count();
            int[] Resultlist = new int[1];
            Resultlist[0] = Result;
            LV_2.ItemsSource = Resultlist;
            LV_1.ItemsSource = Complete_List;
        }

        private void BT_12_Click(object sender, RoutedEventArgs e) // löschen Button
        {
            TB_01.Text = string.Empty;
            TB_11.Text = string.Empty;
            TB_02.Text = string.Empty;
            TB_12.Text = string.Empty;
            TBlock_1.Text = string.Empty;
            TBlock_2.Text = string.Empty;
            LV_1.ItemsSource = string.Empty;
            LV_2.ItemsSource = string.Empty;
            Complete_List.Clear();
        }

        private void TB_01_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && int.TryParse(TB_01.Text, out TestWert))
            {
                int AmountofRandom = Convert.ToInt32(TB_01.Text);

                TB_01.Text = string.Empty;

                VokabelListe CreateNewRandomListMethode = new VokabelListe();

                RandomListToAdd_List = CreateNewRandomListMethode.NewRandomList(AmountofRandom);        // alte und neue Liste addieren

                for (int i = 0; i < RandomListToAdd_List.Count; i++)
                {
                    Complete_List.Add(new VokabelListe() { English = RandomListToAdd_List[i].English, Deutsch = RandomListToAdd_List[i].Deutsch });    // alte und neue Liste addieren Ende
                }

                TBlock_1.Visibility = Visibility.Collapsed;
                TBlock_2.Visibility = Visibility.Collapsed;
                LV_1.Visibility = Visibility.Visible;
                LV_2.Visibility = Visibility.Visible;

                LV_1.ItemsSource = Complete_List;
                int Result = Complete_List.Count();
                int[] Resultlist = new int[1];
                Resultlist[0] = Result;
                LV_2.ItemsSource = Resultlist;

            }
        }
        private void TB_12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                VokabelListe CreateNewRandomList = new VokabelListe();
                string StudentAttempt = TB_12.Text;
                bool TestResult = CreateNewRandomList.SearchingTranslation(StudentAttempt, ComparisonVXZ, Complete_List);
                if (TestResult == true)
                {
                    TBlock_2.Visibility = Visibility.Visible;
                    LV_2.Visibility = Visibility.Collapsed;
                    TBlock_2.Text = string.Empty;
                    TBlock_2.Background = System.Windows.Media.Brushes.GreenYellow;
                    TestResult = false;
                }
                else if (TestResult == false)
                {
                    TBlock_2.Background = System.Windows.Media.Brushes.OrangeRed;
                }
            }
        }

        private void TB_02_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && TB_02.Text == string.Empty)
            {
                VokabelListe CreateNewRandomList = new VokabelListe();
                ComparisonVXZ = CreateNewRandomList.PickWord(Complete_List);
                TB_02.Text = ComparisonVXZ;
            }
        }
    }
}
