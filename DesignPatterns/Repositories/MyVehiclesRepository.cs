using DesignPatterns.Infraestructure.Singleton;
using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    public class MyVehiclesRepository : IVehicleRepository
    {
        private readonly MemoryCollection _memoryCollection;

        public MyVehiclesRepository()
        {
            _memoryCollection = MemoryCollection.GetInstance();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _memoryCollection.Vehiculos.Add(vehicle);
        }

        public Vehicle Find(string id)
        {
            return _memoryCollection.Vehiculos.FirstOrDefault(v => v.ID.Equals(new Guid(id)));
        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _memoryCollection.Vehiculos;
        }


    }
}