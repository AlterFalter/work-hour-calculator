using System.Windows;
using WorkHourCalculator.Models;

namespace WorkHourCalculator.Windows
{
    /// <summary>
    /// Interaction logic for ProfileOverviewWindow.xaml
    /// </summary>
    public partial class ProfileOverviewWindow : Window
    {
        private readonly Account account;

        public ProfileOverviewWindow(Account account, Profile editingProfile)
        {
            InitializeComponent();
            this.account = account;
            DataContext = this.account;
        }

        private void AddNewProfile_Click(object sender, RoutedEventArgs e)
        {
            this.account.AddProfile();
        }

        private void EditSelectedProfile_Click(object sender, RoutedEventArgs e)
        {
            EditProfileWindow editProfileWindow = new EditProfileWindow(this.account);
            editProfileWindow.Show();

            this.Close();
        }

        private void SelectProfile_Click(object sender, RoutedEventArgs e)
        {
            this.account.Save();

            MainWindow mainWindow = new MainWindow(this.account);
            mainWindow.Show();

            this.Close();
        }
    }
}
