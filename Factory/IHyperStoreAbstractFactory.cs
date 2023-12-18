using HyperStoreEntities.MarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperStoreEntities.Factory
{
    public interface IHyperStoreAbstractFactory
    {
        List<Transport> CreateTransport();
        List<MarketEmployee> CreateEmployees();
    }
}
