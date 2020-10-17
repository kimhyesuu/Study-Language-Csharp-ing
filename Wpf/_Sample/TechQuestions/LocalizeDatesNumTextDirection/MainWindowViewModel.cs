using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LocalizeDatesNumTextDirection
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DateTime _date = DateTime.Now;
        private double _double = 250.123;
        private string _string = "김혜수";

        public DateTime Date { get { return _date; } set { _date = value; RaisePropertyChanged(); } }
        public double Double { get { return _double; } set { _double = value; RaisePropertyChanged(); } }
        public string String { get => _string; set { _string = value; RaisePropertyChanged(); } }
        public string Direction { get => "RightToLeft"; }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
