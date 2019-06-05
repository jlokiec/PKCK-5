using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CdXml
    {
        public string MusicianId { get; set; }
        public string Title { get; set; }
        public string GenreId { get; set; }
        public string LanguageId { get; set; }
        public string PremiereDate { get; set; }
        public string NumberOfCds { get; set; }
        public string PriceValue { get; set; }
        public string PriceCurrency { get; set; }
        public string DistributorId { get; set; }
    }
}
