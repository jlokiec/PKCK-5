using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlService;

namespace PKCK_zadanie_5.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        MusicXmlReader xmlReader = new MusicXmlReader();
        public List<Cd> Cds { get; set; }
        
        public MainViewModel()
        {
            DataContext dataContext = xmlReader.Read(@"..\..\..\..\resources\music.xml");
            Cds = dataContext.Cds;
           

        }
     
    }
}
