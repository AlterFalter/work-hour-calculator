using Microsoft.Win32;
using System.IO;
using System.Windows;
using WorkHourCalculator.Models;

namespace WorkHourCalculator.Windows
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        private Account account;

        private string Filepath
        {
            get
            {
                return Configuration.ReadField(nameof(Filepath));
            }
            set
            {
                Configuration.AddOrSetField(nameof(Filepath), value);
            }
        }

        public LoadingWindow()
        {
            InitializeComponent();
            account = new Account();
            DataContext = account;
        }

        private void OpenFileExplorer_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "work hour calculator files (*.whc)|*.whc|All files (*.*)|*.*";
            fileDialog.CheckFileExists = false;
            bool result = fileDialog.ShowDialog() == true;
            if (result)
            {
                string filepath = fileDialog.FileName;
                if (!File.Exists(filepath))
                {
                    ErrorLabel.Content = "Path doesn't exist yet or can't be accessed. Please specify a valid path or create a new account with the button underneath.";
                }
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            this.account.Profiles.Add(new Profile("Work"));
            SaveAccountFilepath();

            EditProfileWindow editProfileWindow = new EditProfileWindow();
            editProfileWindow.Show();

            this.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.account.Load();
                SaveAccountFilepath();
                
                MainWindow mainWindow = new MainWindow(this.account);
                mainWindow.Show();

                this.Close();
            }
            catch (FileLoadException ex)
            {
                ErrorLabel.Content = ex.Message;
            }
        }

        private void SaveAccountFilepath()
        {

        }
    }
}
