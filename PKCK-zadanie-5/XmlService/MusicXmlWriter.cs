using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlService
{
    public class MusicXmlWriter
    {

        public static void Serialize(DataContext dataContext, string path)
        {
            XElement header = new XElement("header", new XElement("authors",
            new XElement[]
            {
                    new XElement("author",
                        new XElement("name", "Jakub"),
                        new XElement("surname", "Łokieć"),
                        new XElement("studentId", "210228")),
                   new XElement("author",
                        new XElement("name", "Maciej"),
                        new XElement("surname", "Cierpikowski"),
                        new XElement("studentId", "210153"))
            }),
            new XElement("description", "Katalog płyt CD z muzyką"),
            new XElement("modificationDate", "2019-06-13")
            );

            XElement musicians = new XElement("musicians", dataContext.Musicians.Musicians.Select(d => new XElement("musician",
               new XAttribute("musicianId", d.Value.Id),
               new XElement("name", d.Value.Name))).ToArray());

            XElement genres = new XElement("genres", dataContext.Genres.Genres.Select(d => new XElement("genre",
             new XAttribute("genreId", d.Value.Id),
             new XAttribute("genreName", d.Value.Name))).ToArray());

            XElement languages = new XElement("languages", dataContext.Languages.Languages.Select(d => new XElement("language",
            new XAttribute("languageId", d.Value.Id), d.Value.Name)).ToArray());

            XElement distributors = new XElement("distributors", dataContext.Distributors.Distributors.Select(d => new XElement("distributor",
            new XAttribute("distributorId", d.Value.Id), d.Value.Name)).ToArray());

            XElement catalog = new XElement("catalog", dataContext.Cds.Select(d => new XElement("cd",
            new XElement("cdMusician", new XAttribute("musicianId", d.Musician.Id)),
            new XElement("title", d.Title),
            new XElement("cdGenre", new XAttribute("genreId", d.Genre.Id)),
            new XElement("cdLanguage", new XAttribute("languageId", d.Language.Id)),
            new XElement("premiereDate", d.PremiereDate),
            new XElement("numberOfCds", d.NumberOfCds),
            new XElement("price", new XAttribute("currency", d.Price.Currency), d.Price.Value),
            new XElement("cdDistributor", new XAttribute("distributorId", d.Distributor.Id)))).ToArray());


            XElement root = new XElement("document", header, musicians, genres, languages, distributors, catalog);
            XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", null), root);

            doc.Save(path);
        }
    }
}
