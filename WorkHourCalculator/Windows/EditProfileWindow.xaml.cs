using System.Linq;
using System.Windows;
using WorkHourCalculator.Models;
using WorkHourCalculator.ViewModels;

namespace WorkHourCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private readonly EditProfileViewModel editProfileViewModel;

        public EditProfileWindow(Account account)
        {
            InitializeComponent();
            this.editProfileViewModel = new EditProfileViewModel(account);
            DataContext = this.editProfileViewModel;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.ShowProfileOverviewWindow();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (this.editProfileViewModel.UpdateName())
            {
                this.editProfileViewModel.Account.Save();
                this.ShowProfileOverviewWindow();
            }
            else
            {
                MessageBox.Show("This name already exists!", "Every name can only exist once per account", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowProfileOverviewWindow()
        {
            ProfileOverviewWindow profileOverviewWindow = new ProfileOverviewWindow(this.editProfileViewModel.Account, this.editProfileViewModel.Account.CurrentProfile);
            profileOverviewWindow.Show();

            this.Close();
        }
    }
}
