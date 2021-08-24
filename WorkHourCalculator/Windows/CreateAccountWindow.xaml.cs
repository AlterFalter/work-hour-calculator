using Microsoft.Win32;
using System;
using System.Windows;
using WorkHourCalculator.Models;

namespace WorkHourCalculator.Windows
{
    /// <summary>
    /// Interaction logic for CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        private readonly SaveFileDialog saveFileDialog;
        public CreateAccountWindow()
        {
            InitializeComponent();
            this.saveFileDialog = new SaveFileDialog();
            this.saveFileDialog.FileName = "WorkHourCalculatorAccount";
            this.saveFileDialog.DefaultExt = ".whc";
            this.saveFileDialog.Filter = "work hour calculator files (*.whc)|*.whc|All files (*.*)|*.*";
        }

        private void CreateFileExplorer_Click(object sender, RoutedEventArgs e)
        {
            bool? result = saveFileDialog.ShowDialog();
            if (result == true && saveFileDialog.CheckPathExists)
            {
                this.FilepathTextBox.Text = saveFileDialog.FileName;
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account account = new Account(FilepathTextBox.Text);
                WindowsUserConfiguration.Instance.LastUsedFilepath = account.Filepath;
                account.Profiles.Add(new Profile("Work"));

                EditProfileWindow editProfileWindow = new EditProfileWindow(account);
                editProfileWindow.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                this.ErrorLabel.Content = $"Account couldn't be created. Check wheter the path is accessible and exists! {ex}";
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            LoadAccountWindow loadAccountWindow = new LoadAccountWindow();
            loadAccountWindow.Show();

            this.Close();
        }
    }
}
