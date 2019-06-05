using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlService.Repository;

namespace XmlService
{
    public class MusicXmlReader
    {
        public DataContext Read(string filePath)
        {
            DataContext dataContext = new DataContext();
            XElement xmlElement = XElement.Load(filePath);

            dataContext.Musicians = ReadMusicians(xmlElement);
            dataContext.Genres = ReadGenres(xmlElement);
            dataContext.Languages = ReadLanguages(xmlElement);
            dataContext.Distributors = ReadDistributors(xmlElement);
            dataContext.Cds = ConvertCdsFromXmlToCds(ReadCds(xmlElement), dataContext);

            return dataContext;
        }

        private MusicianRepository ReadMusicians(XElement xmlElement)
        {
            MusicianRepository musicianRepository = new MusicianRepository();

            IEnumerable<Musician> musicians = from musician in xmlElement.Descendants(MusicXmlConstants.MUSICIAN_NODE)
                                              select new Musician()
                                              {
                                                  Id = musician.Attribute(MusicXmlConstants.MUSICIAN_ID).Value,
                                                  Name = musician.Element(MusicXmlConstants.MUSICIAN_NAME).Value
                                              };

            foreach (Musician musician in musicians)
            {
                musicianRepository.Add(musician);
            }

            return musicianRepository;
        }

        private GenreRepository ReadGenres(XElement xmlElement)
        {
            GenreRepository genreRepository = new GenreRepository();

            IEnumerable<Genre> genres = from genre in xmlElement.Descendants(MusicXmlConstants.GENRE_NODE)
                                        select new Genre()
                                        {
                                            Id = genre.Attribute(MusicXmlConstants.GENRE_ID).Value,
                                            Name = genre.Attribute(MusicXmlConstants.GENRE_NAME).Value
                                        };

            foreach (Genre genre in genres)
            {
                genreRepository.Add(genre);
            }

            return genreRepository;
        }

        private LanguageRepository ReadLanguages(XElement xmlElement)
        {
            LanguageRepository languageRepository = new LanguageRepository();

            IEnumerable<Language> languages = from language in xmlElement.Descendants(MusicXmlConstants.LANGUAGE_NODE)
                                              select new Language()
                                              {
                                                  Id = language.Attribute(MusicXmlConstants.LANGUAGE_ID).Value,
                                                  Name = language.Value
                                              };

            foreach (Language language in languages)
            {
                languageRepository.Add(language);
            }

            return languageRepository;
        }

        private DistributorRepository ReadDistributors(XElement xmlElement)
        {
            DistributorRepository distributorRepository = new DistributorRepository();

            IEnumerable<Distributor> distributors = from distributor in xmlElement.Descendants(MusicXmlConstants.DISTRIBUTOR_NODE)
                                                    select new Distributor()
                                                    {
                                                        Id = distributor.Attribute(MusicXmlConstants.DISTRIBUTOR_ID).Value,
                                                        Name = distributor.Value
                                                    };

            foreach (Distributor distributor in distributors)
            {
                distributorRepository.Add(distributor);
            }

            return distributorRepository;
        }

        private List<CdXml> ReadCds(XElement xmlElement)
        {
            List<CdXml> cdsXml = new List<CdXml>();

            IEnumerable<CdXml> cdsFromXml = from catalog in xmlElement.Descendants(MusicXmlConstants.CD_NODE)
                                            select new CdXml
                                            {
                                                MusicianId = catalog.Element(MusicXmlConstants.CD_MUSICIAN_NODE).Attribute(MusicXmlConstants.MUSICIAN_ID).Value,
                                                Title = catalog.Element(MusicXmlConstants.CD_TITLE_NODE).Value,
                                                GenreId = catalog.Element(MusicXmlConstants.CD_GENRE_NODE).Attribute(MusicXmlConstants.GENRE_ID).Value,
                                                LanguageId = catalog.Element(MusicXmlConstants.CD_LANGUAGE_NODE).Attribute(MusicXmlConstants.LANGUAGE_ID).Value,
                                                PremiereDate = catalog.Element(MusicXmlConstants.CD_PREMIER_DATE_NODE).Value,
                                                NumberOfCds = catalog.Element(MusicXmlConstants.CD_NUMBER_OF_CDS_NODE).Value,
                                                PriceValue = catalog.Element(MusicXmlConstants.CD_PRICE_NODE).Value,
                                                PriceCurrency = catalog.Element(MusicXmlConstants.CD_PRICE_NODE).Attribute(MusicXmlConstants.CD_PRICE_CURRENCY_ATTRIBUTE).Value,
                                                DistributorId = catalog.Element(MusicXmlConstants.CD_DISTRIBUTOR_NODE).Attribute(MusicXmlConstants.DISTRIBUTOR_ID).Value
                                            };

            foreach (CdXml cdXml in cdsFromXml)
            {
                cdsXml.Add(cdXml);
            }

            return cdsXml;
        }

        private List<Cd> ConvertCdsFromXmlToCds(List<CdXml> cdsInXml, DataContext dataContext)
        {
            List<Cd> cds = new List<Cd>();

            Dictionary<string, Musician> musicians = dataContext.Musicians.Musicians;
            Dictionary<string, Language> languages = dataContext.Languages.Languages;
            Dictionary<string, Genre> genres = dataContext.Genres.Genres;
            Dictionary<string, Distributor> distributors = dataContext.Distributors.Distributors;

            foreach (CdXml cdXml in cdsInXml)
            {
                Cd cd = new Cd()
                {
                    Musician = musicians[cdXml.MusicianId],
                    Title = cdXml.Title,
                    Genre = genres[cdXml.GenreId],
                    Language = languages[cdXml.LanguageId],
                    PremiereDate = cdXml.PremiereDate,
                    NumberOfCds = int.Parse(cdXml.NumberOfCds),
                    Price = new Price()
                    {
                        Value = double.Parse(cdXml.PriceValue, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo),
                        Currency = cdXml.PriceCurrency
                    },
                    Distributor = distributors[cdXml.DistributorId]
                };

                cds.Add(cd);
            }

            return cds;
        }
    }
}
