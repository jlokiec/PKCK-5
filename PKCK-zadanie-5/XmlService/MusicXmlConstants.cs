using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlService
{
    class MusicXmlConstants
    {
        // musician
        public const string MUSICIAN_NODE = "musician";
        public const string MUSICIAN_ID = "musicianId";
        public const string MUSICIAN_NAME = "name";

        // genre
        public const string GENRE_NODE = "genre";
        public const string GENRE_ID = "genreId";
        public const string GENRE_NAME = "genreName";

        // language
        public const string LANGUAGE_NODE = "language";
        public const string LANGUAGE_ID = "languageId";

        // distributors
        public const string DISTRIBUTOR_NODE = "distributor";
        public const string DISTRIBUTOR_ID = "distributorId";

        // catalog
        public const string CD_NODE = "cd";
        public const string CD_MUSICIAN_NODE = "cdMusician";
        public const string CD_TITLE_NODE = "title";
        public const string CD_GENRE_NODE = "cdGenre";
        public const string CD_LANGUAGE_NODE = "cdLanguage";
        public const string CD_PREMIER_DATE_NODE = "premiereDate";
        public const string CD_NUMBER_OF_CDS_NODE = "numberOfCds";
        public const string CD_PRICE_NODE = "price";
        public const string CD_PRICE_CURRENCY_ATTRIBUTE = "currency";
        public const string CD_DISTRIBUTOR_NODE = "cdDistributor";
    }
}
