using Business.Concreate;
using DataAccess.Concreate.InMemory;
using Entities.Concreate;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleManager vehicleManager = new VehicleManager(new InMemoryVehicleDal());
            foreach (Vehicle car in vehicleManager.GetAll())
            {
                Console.WriteLine(car.Description);

            }
        }
    }
}
