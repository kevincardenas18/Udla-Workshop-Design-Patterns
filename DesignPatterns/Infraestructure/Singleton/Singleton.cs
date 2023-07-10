using DesignPatterns.Models;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Infraestructure.Singleton
{
    public class MemoryCollection
    {
        public ICollection<Vehicle> Vehiculos { get; set; }

        private static MemoryCollection Instance;

        public MemoryCollection()
        {
            Vehiculos = new List<Vehicle>();
        }
        public static MemoryCollection GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MemoryCollection();
            }
            return Instance;
        }
    }
}