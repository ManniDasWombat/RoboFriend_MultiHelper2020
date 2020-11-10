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
using Microsoft.Win32;

namespace RoboFriend_MultiHelper2020
{
    /// <summary>
    /// Interaktionslogik für RetardedFileTwit.xaml
    /// </summary>
    public partial class RetardedFileTwit : Page
    {
        public RetardedFileTwit()
        {
            InitializeComponent();
        }

        OpenFileDialog FileDialogNameX = new OpenFileDialog();

        SaveFileDialog SFD_X = new SaveFileDialog();

        string FilePath;
        string FileDestination;


        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (FileDialogNameX.ShowDialog() == true)
            {
                FilePath = FileDialogNameX.FileName;
            }
            
            TBlock_A.Text = File.ReadAllText(FilePath);
        }

        private void CloseFile_Click(object sender, RoutedEventArgs e)
        {
            TBlock_A.Text = string.Empty;
            FilePath = string.Empty;
            LB_Path.Content = string.Empty;
        }

        private void CopyFile_Click(object sender, RoutedEventArgs e)
        {
            FileDestination = TB_Path.Text;
            using (FileStream fs = File.Create(FileDestination))
            fs.Close();
            File.Copy(FilePath, FileDestination, true);
        }

        private void ShowFilePath_Click(object sender, RoutedEventArgs e)
        {
            LB_Path.Content = FilePath;
            TB_Path.Text = FilePath;
        }

        private void DelFile_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(FilePath);
        }

        private void Direktkopie_Click(object sender, RoutedEventArgs e)
        {
            
            if (SFD_X.ShowDialog() == true)
            {
                File.Copy(FilePath, SFD_X.FileName, true);
            }
                
        }
    }
}
