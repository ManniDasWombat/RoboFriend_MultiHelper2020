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
    /// Interaktionslogik für SalesPriceCaclculator_01.xaml
    /// </summary>
    public partial class SalesPriceCaclculator_01 : Page
    {
        public SalesPriceCaclculator_01()
        {
            InitializeComponent();
        }
        public bool Plus_Minus = true;
        public bool Forwards = true;
        public TextBox[] AllTextBoxes = new TextBox[34];
        public int IJ = 0;

        public void BT_Calc_Click(object sender, RoutedEventArgs e)
        {
            if (TB_NettoEKP.Text == "€")
            {
                TB_NettoEKP.Text = "";
            }
            if (TB_ListeVKPBR.Text == "€")
            {
                TB_ListeVKPBR.Text = "";
            }

            if (TB_NettoEKP.Text != string.Empty && TB_ListeVKPBR.Text == string.Empty)
            {
                Forwards = true;
            }
            else if (TB_ListeVKPBR.Text != string.Empty && TB_NettoEKP.Text == string.Empty)
            {
                Forwards = false;
            }
            else
            {
                MessageBox.Show("Bitte Netto ODER Brutto Wert einsetzen.");
            }

            AllTextBoxes[0] = TB_NettoEKP;
            AllTextBoxes[1] = TB_ZielEKP;
            AllTextBoxes[2] = TB_BarEK;
            AllTextBoxes[3] = TB_BezugsP;
            AllTextBoxes[4] = TB_SelbstKP;
            AllTextBoxes[5] = TB_BarVK;
            AllTextBoxes[6] = TB_ZielVK;
            AllTextBoxes[7] = TB_ListeVKPNT;
            AllTextBoxes[8] = TB_ListeVKPBR;
            AllTextBoxes[9] = TB_NettoEKP_P;
            AllTextBoxes[10] = TB_ZielEKP_P;
            AllTextBoxes[11] = TB_BarEK_P;
            AllTextBoxes[12] = TB_BezugsP_P;
            AllTextBoxes[13] = TB_SelbstKP_P;
            AllTextBoxes[14] = TB_BarVK_P;
            AllTextBoxes[15] = TB_ZielVK_P;
            AllTextBoxes[16] = TB_ListeVKPNT_P;
            AllTextBoxes[17] = TB_ListeVKPBR_P;
            AllTextBoxes[18] = TB_LieferR;
            AllTextBoxes[19] = TB_LieferSKO;
            AllTextBoxes[20] = TB_BezugsK;
            AllTextBoxes[21] = TB_HdlusK;
            AllTextBoxes[22] = TB_GewinnAS;
            AllTextBoxes[23] = TB_KuSKOundVtrPROV;
            AllTextBoxes[24] = TB_KundenR;
            AllTextBoxes[25] = TB_MwST;
            AllTextBoxes[26] = TB_LieferR_P;
            AllTextBoxes[27] = TB_LieferSKO_P;
            AllTextBoxes[28] = TB_BezugsK_P;
            AllTextBoxes[29] = TB_HdlusK_P;
            AllTextBoxes[30] = TB_GewinnAS_P;
            AllTextBoxes[31] = TB_KuSKOundVtrPROV_P;
            AllTextBoxes[32] = TB_KundenR_P;
            AllTextBoxes[33] = TB_MwST_P;

            // Preise in absoluten Zahlen
            double NettoEKP = 77;
            if (Forwards == true)
            { NettoEKP = (Convert.ToDouble(TB_NettoEKP.Text)); }
            double ZielEKP = 77;
            double BarEK = 77;
            double BezugsP = 77;
            double SelbstKP = 77;
            double BarVK = 77;
            double ZielVK = 77;
            double ListeVKPNT = 77;
            double ListeVKPBR = 99;

            // Kostenfaktoren in Prozent
            double LieferR_P = Convert.ToDouble(TB_LieferR_P.Text);
            double LieferSKO_P = Convert.ToDouble(TB_LieferSKO_P.Text);
            double BezugsK_P = 77;
            double HdlusK_P = Convert.ToDouble(TB_HdlusK_P.Text);
            double GewinnAS_P = Convert.ToDouble(TB_GewinnAS_P.Text);
            double KuSKOundVtrPROV_P = Convert.ToDouble(TB_KuSKOundVtrPROV_P.Text);
            double KundenR_P = Convert.ToDouble(TB_KundenR_P.Text);
            double MwST_P = Convert.ToDouble(TB_MwST_P.Text);

            // Preise in Prozent vorwärts:
            double NettoEKP_P = 100;
            double ZielEKP_P = 100;
            double BarEK_P = 100;
            double BezugsP_P = 100;
            double SelbstKP_P = 100;
            double BarVK_P = 100 - KuSKOundVtrPROV_P;
            double ZielVK_P = 100 - KundenR_P;
            double ListeVKPNT_P = 100;
            double ListeVKPBR_P = 100 + MwST_P;

            // Kostenfaktoren in absoluten Zahlen
            double LieferR = 11;
            double LieferSKO = 11;
            double BezugsK = Convert.ToDouble(TB_BezugsK.Text);
            double HdlusK = 11;
            double GewinnAS = 11;
            double KuSKOundVtrPROV = 11;
            double KundenR = 11;
            double MwST = 11;

            if (Forwards == false)
            {
                NettoEKP = 99;
                ListeVKPBR = Convert.ToDouble(TB_ListeVKPBR.Text);
                ZielEKP_P = 100 - LieferR_P;
                BarEK_P = 100 - LieferSKO_P;
                SelbstKP_P = 100 + HdlusK_P;
                BarVK_P = 100 + GewinnAS_P;
                ZielVK_P = 100;
                ListeVKPBR_P = 100 + MwST_P;
            }


            double[] BruttoAll = new double[9];
            BruttoAll[0] = NettoEKP;
            BruttoAll[1] = ZielEKP;
            BruttoAll[2] = BarEK;
            BruttoAll[3] = BezugsP;
            BruttoAll[4] = SelbstKP;
            BruttoAll[5] = BarVK;
            BruttoAll[6] = ZielVK;
            BruttoAll[7] = ListeVKPNT;
            BruttoAll[8] = ListeVKPBR;

            double[] BruttoAll_P = new double[9];
            BruttoAll_P[0] = NettoEKP_P;
            BruttoAll_P[1] = ZielEKP_P;
            BruttoAll_P[2] = BarEK_P;
            BruttoAll_P[3] = BezugsP_P;
            BruttoAll_P[4] = SelbstKP_P;
            BruttoAll_P[5] = BarVK_P;
            BruttoAll_P[6] = ZielVK_P;
            BruttoAll_P[7] = ListeVKPNT_P;
            BruttoAll_P[8] = ListeVKPBR_P;

            double[] FaktorAll = new double[8];
            FaktorAll[0] = LieferR;
            FaktorAll[1] = LieferSKO;
            FaktorAll[2] = BezugsK;
            FaktorAll[3] = HdlusK;
            FaktorAll[4] = GewinnAS;
            FaktorAll[5] = KuSKOundVtrPROV;
            FaktorAll[6] = KundenR;
            FaktorAll[7] = MwST;

            double[] FaktorAll_P = new double[8];
            FaktorAll_P[0] = LieferR_P;
            FaktorAll_P[1] = LieferSKO_P;
            FaktorAll_P[2] = BezugsK_P;
            FaktorAll_P[3] = HdlusK_P;
            FaktorAll_P[4] = GewinnAS_P;
            FaktorAll_P[5] = KuSKOundVtrPROV_P;
            FaktorAll_P[6] = KundenR_P;
            FaktorAll_P[7] = MwST_P;

            if (Forwards == false)
            {

                for (int i = FaktorAll.Length; i > 0; i--)
                {
                    int j = i - 1;

                    if (i < 3)
                    {
                        Plus_Minus = false;
                    }
                    else
                    {
                        Plus_Minus = true;
                    }

                    if (i == 3)
                    {
                        FaktorAll_P[2] = FaktorAll[2] * 100 / BruttoAll[3];
                    }

                    FaktorAll[j] = Methode_Faktor(BruttoAll[i], BruttoAll_P[i], FaktorAll_P[j]);
                    BruttoAll[j] = Methode_Netto(BruttoAll[i], FaktorAll[j]);
                }

            }
            else
            {
                for (int i = 0; i < FaktorAll.Length; i++)
                {
                    int j = i + 1;

                    if (i > 1)
                    {
                        Plus_Minus = false;
                    }
                    else
                    {
                        Plus_Minus = true;
                    }

                    if (i == 2)     // hier wird der Nominalwert Bezugskosten in Prozente gewandelt (durch j = i+1 ist BruttoAll2 hier bereits bekannt)
                    {
                        FaktorAll_P[2] = FaktorAll[2] * 100 / BruttoAll[2];
                    }

                    FaktorAll[i] = Methode_Faktor(BruttoAll[i], BruttoAll_P[i], FaktorAll_P[i]);
                    BruttoAll[j] = Methode_Netto(BruttoAll[i], FaktorAll[i]);
                }
            }

            int AC1 = 0;
            int AC2 = 0;
            int AC3 = 0;
            int AC4 = 0;
            IJ = 0;

            foreach (TextBox i in AllTextBoxes)
            {
                if (IJ < 9)
                {
                    i.Text = Math.Round(BruttoAll[AC1], 2).ToString() + " €";
                    AC1 += 1;
                }
                else if (IJ < 18)
                {
                    i.Text = Math.Round(BruttoAll_P[AC2], 2).ToString() + " €";
                    AC2 += 1;
                }
                else if (IJ < 26)
                {
                    i.Text = Math.Round(FaktorAll[AC3], 2).ToString() + " €";
                    AC3 += 1;
                }
                else if (IJ < 34)
                {
                    i.Text = Math.Round(FaktorAll_P[AC4], 2).ToString() + " €";
                    AC4 += 1;
                }
                IJ += 1;
            }
        }


        public double Methode_Faktor(double Brutto, double Brutto_P, double Faktor_P)
        {
            double Faktor;
            Faktor = Brutto * (Faktor_P / Brutto_P);
            return Faktor;
        }

        public double Methode_Netto(double Brutto, double Faktor)
        {
            double Netto;
            if (Plus_Minus == true)
            {
                Netto = Math.Round(Brutto - Faktor, 2);
                return Netto;
            }
            else
            {
                Netto = Math.Round(Brutto + Faktor, 2);
                return Netto;
            }
        }

        private void BT_Erase_Click(object sender, RoutedEventArgs e)
        {
            if (IJ != 0)
            {
                foreach (TextBox i in AllTextBoxes)
                {
                    i.Text = String.Empty;
                }
            }
        }

        private void TB_NettoEKP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V)
            {
                TB_BezugsK.Text = "30,5";
                TB_NettoEKP.Text = String.Empty;
                TB_NettoEKP.Text = Convert.ToString(4000);

                TB_LieferR_P.Text = Convert.ToString(20);
                TB_LieferSKO_P.Text = Convert.ToString(3);
                TB_HdlusK_P.Text = Convert.ToString(30);
                TB_GewinnAS_P.Text = Convert.ToString(10);
                TB_KuSKOundVtrPROV_P.Text = Convert.ToString(2);
                TB_KundenR_P.Text = Convert.ToString(10);
                TB_MwST_P.Text = Convert.ToString(19);
            }
        }

        private void TB_ListeVKPBR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V)
            {
                TB_BezugsK.Text = "120";
                TB_ListeVKPBR.Text = String.Empty;
                TB_ListeVKPBR.Text = Convert.ToString(5000);

                TB_LieferR_P.Text = Convert.ToString(10);
                TB_LieferSKO_P.Text = Convert.ToString(3);
                TB_HdlusK_P.Text = Convert.ToString(65);
                TB_GewinnAS_P.Text = Convert.ToString(20);
                TB_KuSKOundVtrPROV_P.Text = Convert.ToString(2);
                TB_KundenR_P.Text = Convert.ToString(5);
                TB_MwST_P.Text = Convert.ToString(19);
            }
        }
    }
}