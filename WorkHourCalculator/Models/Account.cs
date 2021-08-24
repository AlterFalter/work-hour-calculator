using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WorkHourCalculator.Models
{
    public class Account : INotifyPropertyChanged
    {
        private Profile currentProfile;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Filepath { get; }

        public ObservableCollection<Profile> Profiles { get; }

        public Profile CurrentProfile
        {
            get
            {
                return currentProfile;
            }
            set
            {
                currentProfile = value;
                NotifyPropertyChanged();
            }
        }

        public Account(string filepath)
        {
            this.Filepath = filepath;
            this.Profiles = new ObservableCollection<Profile>();
            this.Profiles.CollectionChanged += Profiles_CollectionChanged;
            this.AddProfile();
            this.CurrentProfile = Profiles.First();
        }

        public bool Load()
        {
            return false;
        }

        public bool Save()
        {
            return false;
        }

        private bool IsProfileAlreadyUsed(string profileName)
        {
            return this.Profiles.Any(p => p.Name == profileName);
        }

        public void AddProfile(string profileName = "")
        {
            if (profileName == "")
            {
                profileName = "work";
            }
            if (!IsProfileAlreadyUsed(profileName))
            {
                for (int i = 2; i < int.MaxValue; i++)
                {
                    string possibleFreename = $"{profileName}_{i}";
                    if (!IsProfileAlreadyUsed(possibleFreename))
                    {
                        profileName = possibleFreename;
                        break;
                    }
                }
            }
            this.Profiles.Add(new Profile(profileName));
        }

        private void Profiles_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(this.Profiles));
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
