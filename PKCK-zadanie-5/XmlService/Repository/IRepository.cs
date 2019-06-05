using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlService.Repository
{
    interface IRepository<T>
    {
        void Add(T t);
        void Delete(string id);
        void Delete(T t);
        T Get(string id);
        List<T> GetAll();
        T Update(T t);
    }
}
