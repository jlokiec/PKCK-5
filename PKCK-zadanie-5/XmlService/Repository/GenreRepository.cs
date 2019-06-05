using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlService.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        public Dictionary<string, Genre> Genres { get; set; }

        public GenreRepository()
        {
            Genres = new Dictionary<string, Genre>();
        }
        public void Add(Genre genre)
        {
            if (!Genres.ContainsKey(genre.Id))
            {
                Genres.Add(genre.Id, genre);
            }
        }

        public void Delete(string id)
        {
            Genres.Remove(id);
        }

        public void Delete(Genre genre)
        {
            Genres.Remove(genre.Id);
        }

        public Genre Get(string id)
        {
            if (Genres.ContainsKey(id))
            {
                return Genres[id];
            }
            return null;
        }

        public List<Genre> GetAll()
        {
            return Genres.Values.ToList();
        }

        public Genre Update(Genre genre)
        {
            string id = genre.Id;
            Genres[id] = genre;
            return genre;
        }
    }
}
