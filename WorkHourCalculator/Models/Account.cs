using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WorkHourCalculator.Models
{
    public class Account : INotifyPropertyChanged
    {
        private string filePath;
        private IList<Profile> profiles;
        private Profile currentProfile;
        public event PropertyChangedEventHandler PropertyChanged;

        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                NotifyPropertyChanged();
            }
        }

        public IList<Profile> Profiles
        {
            get => profiles;
            set
            {
                profiles = value;
                NotifyPropertyChanged();
            }
        }


        public Profile CurrentProfile
        {
            get
            {
                if (currentProfile == null && Profiles.Any())
                {
                    currentProfile = Profiles.First();
                }
                return currentProfile;
            }
            set
            {
                currentProfile = value;
                NotifyPropertyChanged();
            }
        }

        public Account()
        {
            if (!this.Load())
            {
                this.Profiles = new List<Profile>();
            }
        }

        public bool Load()
        {
            return false;
        }

        public bool Save()
        {
            return false;
        }

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
