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
    /// Interaktionslogik für Fibot.xaml
    /// </summary>
    public partial class Fibot : Page
    {

        List<Number> ListOfAllNumbers = new List<Number>();
        int AmountofNumbers;
        int A;
        int B;
        int C;
        bool Even;

        public Fibot()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (int.TryParse(TB_Insert.Text, out AmountofNumbers))
                {
                    A = 0;
                    B = 1;

                    for (int i = 0; i < AmountofNumbers; i++)
                    {     
                        C = A + B;
                        A = B;
                        B = C;

                        if (C % 2 == 0)
                        {
                            Even = true;
                        }
                        else
                        {
                            Even = false;
                        }

                        ListOfAllNumbers.Add(new Number { N_ID = i + 1, N_A = A, N_B = B, N_C = C, N_Q = Math.Round((double)C / (double)A , 10), G_N = Math.Round(1.618 - (double)C / (double)A , 10), N_Even = Even});
                    }

                    DG_1.ItemsSource = ListOfAllNumbers;
                }
            }
        }
    }
}
