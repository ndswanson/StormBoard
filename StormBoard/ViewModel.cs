using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace StormBoard
{
    class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        

        #endregion

        #region Contstructor



        #endregion

        #region Properties



        #endregion

        #region Methods



        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
