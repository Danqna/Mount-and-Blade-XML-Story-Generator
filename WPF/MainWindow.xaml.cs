using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

namespace StoryGenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> ItemList { get; set; } = new List<string>();
        public List<string> IdList { get; set; } = new List<string>();

        public string SaveLocation
        {
            get => saveLocation;
            set
            {
                saveLocation = value;
                OnPropertyChanged();
            }
        }

        private string saveLocation { get; set; } = "";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _ = new TaskFactory().StartNew(() =>
              {
                  var lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Resources\Items.txt");
                  foreach (var line in lines)
                  {
                      var item = line.Split('\t')[0];
                      var id = line.Split('\t')[1];
                      ItemList.Add(item);
                      IdList.Add(id);
                  }
              });
            SaveLocation = Properties.Settings.Default.SaveLocation;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mountandblade.fandom.com/wiki/Bannerlord_item_names_and_IDs");
        }

        private void ButtonLocatePath_Click(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog diag = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if(diag.ShowDialog() ?? false)
            {
                SaveLocation = diag.SelectedPath;
                Properties.Settings.Default.SaveLocation = SaveLocation;
                Properties.Settings.Default.Save();
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Add saving
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
