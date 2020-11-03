using System;
using System.IO;
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
    /// Interaktionslogik für EXamulator.xaml
    /// </summary>
    public partial class EXamulator : Page
    {
        public EXamulator()
        {
            InitializeComponent();
        }

        int Rest;
        int NumberToDivide;
        string ValueForTBlock_002;
        int VvI = 1;
        int SearchedDecimalFigure;
        int DezimalParse;

        private void TB_001_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_001.Text = String.Empty;
            TB_002.Text = String.Empty;
        }

        private void TB_001_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                TBlock_001.Text = string.Empty;
                TBlock_002.Text = string.Empty;
            }

            if (e.Key == Key.Return)
            {

                if (int.TryParse(TB_001.Text, out NumberToDivide))
                {

                    string BinaryParse = Convert.ToString(NumberToDivide, 2);
                    TBlock_001.Text += BinaryParse + $"\n";
                        
                    TBlock_001.Text += $"\n\n";


                    
                    while (NumberToDivide != 0)
                    {
                        Rest = NumberToDivide % 2;

                        ValueForTBlock_002 += Rest.ToString();

                        if (NumberToDivide == 1)
                        {
                            NumberToDivide--;
                        }

                        NumberToDivide = NumberToDivide / 2;
                    }

                    char[] BinaryNumbers = new char[ValueForTBlock_002.Length];
                    using (StringReader sr = new StringReader(ValueForTBlock_002))
                    {
                        sr.Read(BinaryNumbers, 0, ValueForTBlock_002.Length);
                    }
                    Array.Reverse(BinaryNumbers);
                    foreach (var item in BinaryNumbers)
                    {
                        TBlock_002.Text += item;
                    }
                    TBlock_002.Text += $"\n";
                }

            }

        }

        private void TB_002_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                decimal value;
                if (Decimal.TryParse(TB_002.Text, out value))
                {
                    DezimalParse = Convert.ToInt32(TB_002.Text, 2);
                    TBlock_001.Text += DezimalParse + $"\n";

                    string StringLength = TB_002.Text;
                    char[] BinaryN2Array = new char[StringLength.Length];
                    using (StringReader sr = new StringReader(StringLength))
                    {
                        sr.Read(BinaryN2Array, 0, StringLength.Length);
                    }

                    for (int i = StringLength.Length -1; i >= 0; i--)
                    {
                        if (BinaryN2Array[i].ToString() == "1")
                        {
                            SearchedDecimalFigure += VvI;
                        }
                        VvI = VvI * 2;
                    }
                    TBlock_002.Text += SearchedDecimalFigure.ToString()+"\n";
                    StringLength = string.Empty;
                    SearchedDecimalFigure = 0;
                    VvI = 1;
                }
            }
        }
    }
}
