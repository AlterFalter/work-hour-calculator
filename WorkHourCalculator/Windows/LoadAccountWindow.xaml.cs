using Microsoft.Win32;
using System.IO;
using System.Windows;
using WorkHourCalculator.Models;

namespace WorkHourCalculator.Windows
{
    /// <summary>
    /// Interaction logic for LoadAccountWindow.xaml
    /// </summary>
    public partial class LoadAccountWindow : Window
    {
        public LoadAccountWindow()
        {
            InitializeComponent();
            this.Filepath.Text = WindowsUserConfiguration.Instance.LastUsedFilepath;
            this.LoadButton.IsEnabled = File.Exists(this.Filepath.Text);
        }

        private void OpenFileExplorer_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "work hour calculator files (*.whc)|*.whc|All files (*.*)|*.*";
            fileDialog.CheckFileExists = false;
            bool result = fileDialog.ShowDialog() == true;
            if (result)
            {
                this.Filepath.Text = fileDialog.FileName;
                if (!File.Exists(this.Filepath.Text))
                {
                    ErrorLabel.Content = "Path doesn't exist yet or can't be accessed. Please specify a valid path or create a new account with the button underneath.";
                }
                else
                {
                    LoadButton.IsEnabled = true;
                }
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow();
            createAccountWindow.Show();

            this.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account account = new Account(this.Filepath.Text);
                WindowsUserConfiguration.Instance.LastUsedFilepath = account.Filepath;

                MainWindow mainWindow = new MainWindow(account);
                mainWindow.Show();

                this.Close();
            }
            catch (FileLoadException ex)
            {
                ErrorLabel.Content = ex.Message;
            }
        }
    }
}
