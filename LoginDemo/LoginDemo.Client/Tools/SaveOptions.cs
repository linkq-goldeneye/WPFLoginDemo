using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDemo.Client.Tools
{
    [Serializable]
    public class SaveOptions : INotifyPropertyChanged
    {
        private bool _SaveUser = true;
        public bool SaveUser
        {
            get { return _SaveUser; }
            set
            {
                _SaveUser = value;
                OnPropertyChanged(nameof(SaveUser));
            }
        }

        private bool _AutoLogin = false;
        public bool AutoLogin
        {
            get { return _AutoLogin; }
            set
            {
                _AutoLogin = value;
                OnPropertyChanged(nameof(AutoLogin));
            }
        }

        private string _SaveLoginID;
        public string SaveLoginID
        {
            get { return _SaveLoginID; }
            set
            {
                _SaveLoginID = value;
                OnPropertyChanged(nameof(SaveLoginID));
            }
        }

        private string _SaveLoginPSW;
        public string SaveLoginPSW
        {
            get { return _SaveLoginPSW; }
            set
            {
                _SaveLoginPSW = value;
                OnPropertyChanged(nameof(SaveLoginPSW));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

