using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Cd
    {
        public Cd(Musician musician, string title, Genre genre, Language language, string premiereDate, int numberOfCds, Price price, Distributor distributor)
        {
            Musician = musician;
            Title = title;
            Genre = genre;
            Language = language;
            PremiereDate = premiereDate;
            NumberOfCds = numberOfCds;
            Price = price;
            Distributor = distributor;
        }
        public Cd()
        {

        }

        public Musician Musician { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        public string PremiereDate { get; set; }
        public int NumberOfCds { get; set; }
        public Price Price { get; set; }
        public Distributor Distributor { get; set; }
        

        public override string ToString()
        {
            return $"CD | {Musician.Name} | {Title} | {Genre.Name} | {Language.Name} | {PremiereDate} | {NumberOfCds} | {Price.Value} | {Price.Currency} | {Distributor.Name}";
        }
    }
}
