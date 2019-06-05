using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlService.Repository;

namespace XmlService
{
    public class DataContext
    {
        public MusicianRepository Musicians { get; set; }
        public GenreRepository Genres { get; set; }
        public LanguageRepository Languages { get; set; }
        public DistributorRepository Distributors { get; set; }
        public List<Cd> Cds { get; set; }
    }
}
