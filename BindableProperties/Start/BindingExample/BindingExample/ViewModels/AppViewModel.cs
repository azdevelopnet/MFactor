using System;
using System.ComponentModel;

namespace BindingExample.ViewModels
{
    public class AppViewModel: INotifyPropertyChanged
    {
        public AppViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
