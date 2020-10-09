using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DishSysManager.Data
{
    public class FrameDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _ProductName;
        /// <summary>
        /// 系统名称
        /// </summary>
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName = value;
                SetPropertyChanged("ProductName");
            }
        }

        private string _CurrentTime;

        public string CurrentTime
        {
            get { return _CurrentTime; }
            set { _CurrentTime = value;
                SetPropertyChanged("CurrentTime");
            }
        }



        void SetPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
