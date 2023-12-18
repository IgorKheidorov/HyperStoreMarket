using FirstLanguageSampleMexico.MarkerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperStoreEntities.Factory
{
    public class HyperStoreBuilder
    {
        public static HyperStore BuildHyperStore(string name, string type) 
        {
            IHyperStoreAbstractFactory factory;

            switch (type)
            {
                case "Food":
                    factory = new FoodStoreAbstractFactory();
                    break;
                case "Building materials":
                    factory = new BuildingMaterialsStoreAbstractFactory();
                    break;
                default:
                    throw new ArgumentException();
            }

            HyperStore store = new HyperStore(name) { Type = type };
            store.Transport = factory.CreateTransport();
            store.Employees = factory.CreateEmployees();

            return store;
        }
    }
}
