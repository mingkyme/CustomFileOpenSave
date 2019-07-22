using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
namespace CustomFileOpenSave
{
    
    public partial class MainWindow : Window
    {
        // 파일 확장자 이름
        const string FILETYPE = "hof";

        string folderPath = @".\zip";
        string openFolderPath = @".\open";
        string zipFilePath = @".\result." + FILETYPE;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void XAML_OpenProject_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "HOF file (*.hof)|*.hof";

            if (openFileDialog.ShowDialog() == true)
            {
                ZipFile.ExtractToDirectory(openFileDialog.FileName, openFolderPath);
            }

        }

        private void XAML_SaveProject_Click(object sender, RoutedEventArgs e)
        {
            

            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }
            ZipFile.CreateFromDirectory(folderPath, zipFilePath);
        }

        private void XAML_NewProject_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "FBX file (*.fbx)|*.fbx";

            if (openFileDialog.ShowDialog() == true)
            {
                File.Copy(openFileDialog.FileName, folderPath + @"\model.fbx");
            }



        }
    }
}
