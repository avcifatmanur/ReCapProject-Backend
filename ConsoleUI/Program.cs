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
            GetCarAll();

            //UpdateBrandTest();
            //DeleteBrandTest();
            //AddBrandTest();
            //UpdateColorTest();
            //DeleteColorTest();
            //AddColorTest();
            //UpdateCarTest();
            //DeleteCarTest();
            //AddCarTest();
        }

        private static void GetCarAll()
        {
            Console.WriteLine("-----------ARAÇLAR-----------");
            VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
            foreach (var car in vehicleManager.GetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / ",car.carName,car.brandName,car.colorName,car.DailyPrice);

            }
        }
        private static void UpdateBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { BrandId = 6, BrandName = "Volvo" });
            Console.WriteLine("Tüm Markalar");
            foreach (var brand in brandManager.GetAll())
            {

                Console.WriteLine(brand.BrandName);
            }
        }

        private static void DeleteBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { BrandId = 5, BrandName = "Mercedes" });
            Console.WriteLine("Tüm Markalar");
            foreach (var brand in brandManager.GetAll())
            {

                Console.WriteLine(brand.BrandName);
            }
        }

        private static void AddBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 5, BrandName = "Mercedes" });
            Console.WriteLine("Tüm Markalar");
            foreach (var brand in brandManager.GetAll())
            {

                Console.WriteLine(brand.BrandName);
            }
        }

        private static void UpdateColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { ColorId = 1, ColorName = "gold" });
            Console.WriteLine("Tüm Renkler");
            foreach (var color in colorManager.GetAll())
            {

                Console.WriteLine(color.ColorName);
            }
        }

        private static void DeleteColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { ColorId = 2, ColorName = "siyah" });
            Console.WriteLine("Tüm Renkler");
            foreach (var color in colorManager.GetAll())
            {

                Console.WriteLine(color.ColorName);
            }
        }

        private static void AddColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 3, ColorName = "Kırmızı" });
            Console.WriteLine("Tüm Renkler");
            foreach (var color in colorManager.GetAll())
            {

                Console.WriteLine(color.ColorName);
            }
        }


        public static void AddCarTest()
        {
            VehicleManager carManager = new VehicleManager(new EfVehicleDal());
            carManager.Add(new Vehicle { Id = 9, BrandId = 5, ColorId = 3, VehicleName = "BMW 316i", ModelYear = 2019, DailyPrice = 400, Description = "otomatik" });
            Console.WriteLine("---------GÜNCEL ARAÇLAR---------");
            foreach (Vehicle car in carManager.GetAll())
            {
                Console.WriteLine(car.VehicleName);
            }

        }
        private static void UpdateCarTest()
        {
            VehicleManager carManager = new VehicleManager(new EfVehicleDal());
            carManager.Update(new Vehicle { Id = 9, BrandId = 5, ColorId = 3, VehicleName = "520i", ModelYear = 2018, DailyPrice = 350, Description = "otomatik" });
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
