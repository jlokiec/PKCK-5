using DataModel;
using PKCK_zadanie_5.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XmlService;

namespace PKCK_zadanie_5.ViewModel
{
    class AddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DataContext DataContext { get; set; }
        public String Title { get; set; }
        public String Musician { get; set; }
        public String Language { get; set; }
        public String Distributor { get; set; }
        public String Genre { get; set; }
        public double Price { get; set; }
        public int NumberOfCds { get; set; }
        public String PremiereDate { get; set; }
        public String Currency { get; set; }
        public ICommand AddCommand { get; set; }
        MusicXmlReader xmlReader = new MusicXmlReader();
        public ObservableCollection<Cd> Cds { get; set; }
        public AddViewModel(ObservableCollection<Cd> cds, DataContext dataContext)
        {
            Cds = cds;
            AddCommand = new RelayCommand(pars => Add());
            DataContext = dataContext;
        }
        public void Add()
        {
            Musician musician = new Musician(Musician.Substring(0,2), Musician);
            DataContext.Musicians.Add(musician);
            Distributor distributor = new Distributor(Distributor.Substring(0,2), Distributor);
            DataContext.Distributors.Add(distributor);
            Genre genre = new Genre(Genre.Substring(0,2), Genre);
            DataContext.Genres.Add(genre);
            Language language = new Language(Language.Substring(0,2), Language);
            DataContext.Languages.Add(language);
            Price price = new Price(Price, Currency);
        
            Cd cd = new Cd(musician, Title, genre, language, PremiereDate.ToString(), NumberOfCds, price, distributor);
            DataContext.Cds.Add(cd);
            Cds.Add(cd);
        
           
        }
    }
}
