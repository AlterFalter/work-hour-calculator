using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WorkHourCalculator.Models
{
    public class Profile : INotifyPropertyChanged
    {
        private string name;
        private IList<Stamp> stamps;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public IList<Stamp> Stamps
        {
            get => stamps;
            set
            {
                stamps = value;
                NotifyPropertyChanged();
            }
        }

        public Profile(string name)
        {
            this.Name = name;
            this.Stamps = new List<Stamp>();
        }

        public TimeSpan CalculateWorkTimeOnDate(DateTime date)
        {
            IList<Stamp> stampsFromDay = GetStampsFromDay(date);
            bool isDateToday = date.Date == DateTime.Now.Date;
            bool evenNumberOfStamps = stampsFromDay.Count % 2 == 0;
            if (evenNumberOfStamps || isDateToday)
            {
                if (!evenNumberOfStamps && isDateToday)
                {
                    stampsFromDay.Add(new Stamp(DateTime.Now));
                }

                stampsFromDay.OrderBy(s => s.DateTime);
                TimeSpan workTime = new TimeSpan(0, 0, 0);
                for (int i = 0; i < stampsFromDay.Count; i+=2)
                {
                    workTime.Add(stampsFromDay[i].DateTime.Subtract(stampsFromDay[i + 1].DateTime));
                }
                return workTime;
            }
            else
            {
                throw new InvalidOperationException($"Not enough stamps for this day ({date.Date}) available");
            }
        }

        private IList<Stamp> GetStampsFromDay(DateTime date)
        {
            return Stamps
                .Where(s => s.DateTime.Date == date.Date)
                .ToList();
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
