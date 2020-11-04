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
    /// Interaktionslogik für Listaholic_01.xaml
    /// </summary>
    public partial class Listaholic_01 : Page
    {
        List<UserData> UserDataList = new List<UserData>();

        public Listaholic_01()
        {
            InitializeComponent();
        }

        private void BT_Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (UserData item in UserDataList)
            {
            }
        }

        private void B_register_Click(object sender, RoutedEventArgs e)
        {
            UserDataList.Add(new UserData { Name = TB_username.Text, Pwd = PB_password.Password, ID = UserDataList.Count + 1 , Mail_Verification = false});
            UserDataGrid_1.Items.Refresh();
        }

        private void BT_Show_Click(object sender, RoutedEventArgs e)
        {
            UserDataGrid_1.ItemsSource = UserDataList;
            LB_registeredusers.Content = UserDataList.Count;
        }

        private void BT_Delete_Click(object sender, RoutedEventArgs e)
        {
            UserDataList.Clear();
            LB_registeredusers.Content = string.Empty;
            UserDataGrid_1.ItemsSource = null;
        }
    }
}
