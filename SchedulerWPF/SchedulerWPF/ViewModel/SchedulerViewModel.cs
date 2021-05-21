using System;
using Syncfusion.UI.Xaml.Scheduler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfScheduler
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private ScheduleAppointmentCollection scheduleAppointmentCollection;
        public SchedulerViewModel()
        {
            this.ScheduleAppointmentCollection = new ScheduleAppointmentCollection();
            var scheduleAppointment = new ScheduleAppointment()
            {
                Id = 1,
                StartTime = DateTime.Today.AddHours(11),
                EndTime = DateTime.Today.AddHours(12),
                Subject = "Occurs Yearly on June 16th",
            };
            scheduleAppointment.RecurrenceRule ="FREQ=YEARLY;BYMONTHDAY=16;BYMONTH=6;INTERVAL=1;COUNT=10";
            ScheduleAppointmentCollection.Add(scheduleAppointment);
        }
        public ScheduleAppointmentCollection ScheduleAppointmentCollection
        {
            get
            {
                return this.scheduleAppointmentCollection;
            }
            set
            {
                this.scheduleAppointmentCollection = value;
                this.RaiseOnPropertyChanged("ScheduleAppointmentCollection");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
   