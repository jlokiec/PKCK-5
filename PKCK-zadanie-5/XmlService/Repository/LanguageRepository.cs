using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlService.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public Dictionary<string, Language> Languages { get; set; }

        public LanguageRepository()
        {
            Languages = new Dictionary<string, Language>();
        }

        public void Add(Language language)
        {
            if (!Languages.ContainsKey(language.Id))
            {
                Languages.Add(language.Id, language);
            }
        }

        public void Delete(string id)
        {
            Languages.Remove(id);
        }

        public void Delete(Language language)
        {
            Languages.Remove(language.Id);
        }

        public Language Get(string id)
        {
            if (Languages.ContainsKey(id))
            {
                return Languages[id];
            }
            return null;
        }

        public List<Language> GetAll()
        {
            return Languages.Values.ToList();
        }

        public Language Update(Language language)
        {
            string id = language.Id;
            Languages[id] = language;
            return language;
        }
    }
}
