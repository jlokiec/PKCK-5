using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlService;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlReader = new MusicXmlReader();
            DataContext dataContext = xmlReader.Read(@"..\..\..\..\resources\music.xml");

            // list musicians
            foreach (var m in dataContext.Cds)
            {
                Console.WriteLine(m);
            }

            Console.ReadKey();
        }
    }
}
