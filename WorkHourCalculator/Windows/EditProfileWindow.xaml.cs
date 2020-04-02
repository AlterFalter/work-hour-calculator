using System.Linq;
using System.Windows;
using WorkHourCalculator.Models;

namespace WorkHourCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private Account account;

        public EditProfileWindow()
        {
            InitializeComponent();
            account = Account.Load();
        }

        private void AddNewProfile_Click(object sender, RoutedEventArgs e)
        {
            string freename = "work";
            if (!IsProfileNameFree(freename))
            {
                for (int i = 2; i < int.MaxValue; i++)
                {
                    string possibleFreename = $"{freename}_{i}";
                    if (IsProfileNameFree(possibleFreename))
                    {
                        freename = possibleFreename;
                        break;
                    }
                }
            }
            this.account.Profiles.Add(new Profile(freename));
        }

        private bool IsProfileNameFree(string profilename)
        {
            return this.account.Profiles.Any(p => p.Name == profilename);
        }

        private void SelectAccount_Click(object sender, RoutedEventArgs e)
        {
            this.account.Save();
            LoadingWindow loadingWindow = new LoadingWindow();
            loadingWindow.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.account.Save();
        }
    }
}
