using Business.Concreate;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concreate.InMemory;
using Entities.Concreate;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------ARAÇLAR-----------");
            VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
            foreach (Vehicle car in vehicleManager.GetAll())
            {
                Console.WriteLine(car.VehicleName);

            }

            AddCarTest();
            UpdateCarTest();
            DeleteCarTest();
            }


        public static void AddCarTest()
        {
            VehicleManager carManager = new VehicleManager(new EfVehicleDal());
            carManager.Add(new Vehicle { Id = 8, BrandId = 5, ColorId = 3, VehicleName = "BMW 316i", ModelYear = 2019, DailyPrice = 400, Description = "otomatik" });
            Console.WriteLine("---------GÜNCEL ARAÇLAR---------");
            foreach (Vehicle car in carManager.GetAll())
            {
                Console.WriteLine(car.VehicleName);
            }

        }
        private static void UpdateCarTest()
        {
            VehicleManager carManager = new VehicleManager(new EfVehicleDal());
            carManager.Update(new Vehicle { Id = 8, BrandId = 5, ColorId = 3, VehicleName = "BMW 316i", ModelYear = 2018, DailyPrice = 350, Description = "otomatik" });
            Console.WriteLine("---------GÜNCEL ARAÇLAR---------");
            foreach (Vehicle car in carManager.GetAll())
            {
                Console.WriteLine(car.VehicleName);
            }

        }
        public static void DeleteCarTest()
        {
            VehicleManager carManager = new VehicleManager(new EfVehicleDal());
            carManager.Delete(new Vehicle { Id = 8, BrandId = 5, ColorId = 3, VehicleName = "BMW 316i", ModelYear = 2019, DailyPrice = 400, Description = "otomatik" });
            Console.WriteLine("---------GÜNCEL ARAÇLAR---------");
            foreach (Vehicle car in carManager.GetAll())
            {
                Console.WriteLine(car.VehicleName);
            }

        }
    }
}
