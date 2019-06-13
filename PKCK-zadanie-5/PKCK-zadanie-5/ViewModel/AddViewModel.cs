using DataModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using XmlService;

namespace PKCK_zadanie_5.ViewModel
{
    class AddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DataContext DataContext { get; set; }
        public string Title { get; set; }
        public string Musician { get; set; }
        public string Language { get; set; }
        public string Distributor { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public int NumberOfCds { get; set; }
        public DateTime PremiereDate { get; set; }
        public string Currency { get; set; }
        public ICommand AddCommand { get; set; }
        public ObservableCollection<Cd> Cds { get; set; }
        public AddViewModel(ObservableCollection<Cd> cds, DataContext dataContext)
        {
            PremiereDate = DateTime.Today;
            Cds = cds;
            AddCommand = new RelayCommand(pars => Add());
            DataContext = dataContext;
        }
        public void Add()
        {
            Musician musician = new Musician(Musician.Substring(0, 4).ToUpper(), Musician);
            DataContext.Musicians.Add(musician);
            Distributor distributor = new Distributor(Distributor.Substring(0, 4).ToUpper(), Distributor);
            DataContext.Distributors.Add(distributor);
            Genre genre = new Genre(Genre.Substring(0, 4).ToUpper(), Genre);
            DataContext.Genres.Add(genre);
            Language language = new Language(Language, Language);
            DataContext.Languages.Add(language);
            Price price = new Price(Price, Currency);

            Cd cd = new Cd(musician, Title, genre, language, PremiereDate.ToString("dd.MM.yyyy"), NumberOfCds, price, distributor);
            DataContext.Cds.Add(cd);
            Cds.Add(cd);
        }
    }
}
