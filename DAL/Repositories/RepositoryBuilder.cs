using HyperStoreEntities.DAL.Interfaces;
using HyperStoreEntities.DAL.Repositories.XML;

namespace HyperStoreEntities.DAL.Repositories
{
    internal class RepositoryBuilder
    {
        static List<IRepositoryRead> _readers = new List<IRepositoryRead>();
        static List<IRepositoryWrite> _writers = new List<IRepositoryWrite>();

        RepositoryBuilder() { }

        public static IRepositoryRead GetReader() 
        {
            // Some business logics with setting, 
            if (_readers.Count() == 0)
            {                
                _readers.Add( new XMLReader());
            }

            return _readers.First();
        }

        public static IRepositoryWrite GetWriter()
        {
            if (_writers.Count() == 0)
            {
                _writers.Add(new XMLWriter());
            }

            return _writers.First();
        }

    }
}
