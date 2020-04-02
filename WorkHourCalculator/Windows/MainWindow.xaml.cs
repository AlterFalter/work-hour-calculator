using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkHourCalculator.Models;

namespace WorkHourCalculator.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Account account;
        public MainWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
            DataContext = this.account;
        }

        public void OpenAboutWindow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This program was created by (c) 2020 Yannis Krämer",
                "(c) 2020 Yannis Krämer",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public void ExitProgram_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditProfiles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectAccount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
