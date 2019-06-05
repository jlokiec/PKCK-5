using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlService.Repository
{
    public class DistributorRepository : IRepository<Distributor>
    {
        public Dictionary<string, Distributor> Distributors { get; private set; }

        public DistributorRepository()
        {
            Distributors = new Dictionary<string, Distributor>();
        }

        public void Add(Distributor distributor)
        {
            if (!Distributors.ContainsKey(distributor.Id))
            {
                Distributors.Add(distributor.Id, distributor);
            }
        }

        public void Delete(string id)
        {
            Distributors.Remove(id);
        }

        public void Delete(Distributor distributor)
        {
            Distributors.Remove(distributor.Id);
        }

        public Distributor Get(string id)
        {
            if (Distributors.ContainsKey(id))
            {
                return Distributors[id];
            }
            return null;
        }

        public List<Distributor> GetAll()
        {
            return Distributors.Values.ToList();
        }

        public Distributor Update(Distributor distributor)
        {
            string id = distributor.Id;
            Distributors[id] = distributor;
            return distributor;
        }
    }
}
