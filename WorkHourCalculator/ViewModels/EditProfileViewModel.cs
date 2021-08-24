using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WorkHourCalculator.Models;

namespace WorkHourCalculator.ViewModels
{
    public class EditProfileViewModel : INotifyPropertyChanged
    {
        private readonly int editingProfileIndex;
        private string newName;

        public event PropertyChangedEventHandler PropertyChanged;

        public Account Account { get; }

        public string NewName
        {
            get => newName;
            set
            {
                newName = value;
                NotifyPropertyChanged();
            }
        }

        public string CurrentName
        {
            get => this.Account.Profiles[this.editingProfileIndex].Name;
            private set
            {
                this.Account.Profiles[this.editingProfileIndex].Name = value;
                NotifyPropertyChanged();
            }
        }

        public EditProfileViewModel(Account account, int editingProfileIndex)
        {
            this.Account = account;
            this.editingProfileIndex = editingProfileIndex;
            this.NewName = this.CurrentName;
        }

        public EditProfileViewModel(Account account)
            : this(account, account.Profiles.IndexOf(account.CurrentProfile))
        {
        }

        public bool UpdateName()
        {
            if (this.Account.Profiles.All(p => p.Name != this.newName))
            {
                this.CurrentName = this.NewName;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// This method is called by the Set accessor of each property.
        /// The CallerMemberName attribute that is applied to the optional propertyName
        /// parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
