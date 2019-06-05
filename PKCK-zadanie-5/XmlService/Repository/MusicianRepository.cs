using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlService.Repository
{
    public class MusicianRepository : IRepository<Musician>
    {
        public Dictionary<string, Musician> Musicians { get; private set; }

        public MusicianRepository()
        {
            Musicians = new Dictionary<string, Musician>();
        }

        public void Add(Musician musician)
        {
            if (!Musicians.ContainsKey(musician.Id))
            {
                Musicians.Add(musician.Id, musician);
            }
        }

        public void Delete(string id)
        {
            Musicians.Remove(id);
        }

        public void Delete(Musician musician)
        {
            Musicians.Remove(musician.Id);
        }

        public Musician Get(string id)
        {
            if (Musicians.ContainsKey(id))
            {
                return Musicians[id];
            }
            return null;
        }

        public List<Musician> GetAll()
        {
            return Musicians.Values.ToList();
        }

        public Musician Update(Musician musician)
        {
            string id = musician.Id;
            Musicians[id] = musician;
            return musician;
        }
    }
}
