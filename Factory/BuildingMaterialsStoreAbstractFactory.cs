using HyperStoreEntities.MarketEntities;

namespace HyperStoreEntities.Factory
{
    public class BuildingMaterialsStoreAbstractFactory : IHyperStoreAbstractFactory
    {
        public List<MarketEmployee> CreateEmployees()
        {
            // Employee- > building materials -> 10 managers, 10 dockees, 1 cashier
            // food- > 3 managers, 20 chashiers, no dockers
            List<MarketEmployee> employees = new List<MarketEmployee>();
            employees.Add(new MarketEmployee() { Name = "Peter1", Role = "Manager" });
            employees.Add(new MarketEmployee() { Name = "Peter2", Role = "Manager" });
            employees.Add(new MarketEmployee() { Name = "Peter3", Role = "Manager" });
            employees.Add(new MarketEmployee() { Name = "Peter4", Role = "Cashier" });
            return employees;
        }


        public List<Transport> CreateTransport()
        {
            List<Transport> transports = new List<Transport>();
            transports.Add(new Transport() { Name = "Volvo", Type = "Lorry" });
            transports.Add(new Transport() { Name = "Volvo", Type = "Car" });
            return transports; 
        }
    }
}
