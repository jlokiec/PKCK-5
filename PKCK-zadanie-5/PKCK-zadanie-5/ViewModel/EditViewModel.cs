using DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XmlService;
using XmlService.Repository;

namespace PKCK_zadanie_5.ViewModel
{
    class EditViewModel : INotifyPropertyChanged
    {
        private Cd _cd;
        private ObservableCollection<Musician> _musicians;
        private ObservableCollection<Genre> _genres;
        private ObservableCollection<Language> _languages;
        private ObservableCollection<Distributor> _distributors;


        public Cd Cd
        {
            get => _cd;
            set
            {
                _cd = value;
                OnPropertyChanged(nameof(Cd));
            }
        }
        public ObservableCollection<Musician> Musicians
        {
            get => _musicians;
            set
            {
                _musicians = value;
                OnPropertyChanged(nameof(Musicians));
            }
        }

        public ObservableCollection<Distributor> Distributors
        {
            get => _distributors;
            set
            {
                _distributors = value;
                OnPropertyChanged(nameof(Distributors));
            }
        }

        public ObservableCollection<Genre> Genres
        {
            get => _genres;
            set
            {
                _genres = value;
                OnPropertyChanged(nameof(Genres));
            }
        }
        public ObservableCollection<Language> Languages
        { get => _languages;
            set
            {
                _languages = value;
                OnPropertyChanged(nameof(Languages));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        virtual protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public EditViewModel(Cd cd, ObservableCollection<Musician> musicians, ObservableCollection<Language> languages, ObservableCollection<Distributor> distributors, ObservableCollection<Genre> genres)
        {
            Cd = cd;
            Musicians = musicians;
            Languages = languages;
            Genres = genres;
            Distributors = distributors;
        }

    }
}
