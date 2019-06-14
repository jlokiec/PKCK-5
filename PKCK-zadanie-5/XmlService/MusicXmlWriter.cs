using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XmlService
{
    public class MusicXmlWriter
    {
        public static void Serialize(DataContext dataContext, string path)
        {
            XNamespace pkckNamespace = "pkck-zad2";
            XElement firstAuthor = new XElement(pkckNamespace + "author",
                    new XElement(pkckNamespace + "name", "Jakub"),
                    new XElement(pkckNamespace + "surname", "Łokieć"),
                    new XElement(pkckNamespace + "studentId", "210228"));
            XElement secondAuthor = new XElement(pkckNamespace + "author",
                new XElement(pkckNamespace + "name", "Maciej"),
                new XElement(pkckNamespace + "surname", "Cierpikowski"),
                new XElement(pkckNamespace + "studentId", "210153"));

            XElement header = new XElement(pkckNamespace + "header", new XElement(pkckNamespace + "authors",
            new XElement[]
            {
                firstAuthor, secondAuthor
            }),
            new XElement(pkckNamespace + "modificationDate", "2019-06-13"),
            new XElement(pkckNamespace + "description", "Katalog płyt CD z muzyką")
            );

            XElement musicians = new XElement(pkckNamespace + "musicians", dataContext.Musicians.Musicians.Select(d => new XElement(pkckNamespace + "musician",
                 new XAttribute("musicianId", d.Value.Id),
                 new XElement(pkckNamespace + "name", d.Value.Name))).ToArray());

            XElement genres = new XElement(pkckNamespace + "genres", dataContext.Genres.Genres.Select(d => new XElement(pkckNamespace + "genre",
               new XAttribute("genreId", d.Value.Id),
               new XAttribute("genreName", d.Value.Name))).ToArray());

            XElement languages = new XElement(pkckNamespace + "languages", dataContext.Languages.Languages.Select(d => new XElement(pkckNamespace + "language",
              new XAttribute("languageId", d.Value.Id), d.Value.Name)).ToArray());

            XElement distributors = new XElement(pkckNamespace + "distributors", dataContext.Distributors.Distributors.Select(d => new XElement(pkckNamespace + "distributor",
              new XAttribute("distributorId", d.Value.Id), d.Value.Name)).ToArray());

            XElement catalog = new XElement(pkckNamespace + "catalog", dataContext.Cds.Select(d => new XElement(pkckNamespace + "cd",
              new XElement(pkckNamespace + "cdMusician", new XAttribute("musicianId", d.Musician.Id)),
              new XElement(pkckNamespace + "title", d.Title),
              new XElement(pkckNamespace + "cdGenre", new XAttribute("genreId", d.Genre.Id)),
              new XElement(pkckNamespace + "cdLanguage", new XAttribute("languageId", d.Language.Id)),
              new XElement(pkckNamespace + "premiereDate", d.PremiereDate.ToString("dd.MM.yyyy")),
              new XElement(pkckNamespace + "numberOfCds", d.NumberOfCds),
              new XElement(pkckNamespace + "price", new XAttribute("currency", d.Price.Currency), d.Price.Value),
              new XElement(pkckNamespace + "cdDistributor", new XAttribute("distributorId", d.Distributor.Id)))).ToArray());


            XElement root = new XElement("document", header, musicians, genres, languages, distributors, catalog);
            XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", null), root);
            doc.Root.Name = pkckNamespace + doc.Root.Name.LocalName;

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, @"..\..\..\..\resources\schema.xsd");
            doc.Validate(schemaSet, (sender, args) => throw new XsdValidationException(args.Exception.Message));

            doc.Save(path);
        }
    }
}
