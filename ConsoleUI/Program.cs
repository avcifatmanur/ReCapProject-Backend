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
            var result = vehicleManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3} / ", car.carName, car.brandName, car.colorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        private static void UpdateBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Update(new Brand { BrandId = 6, BrandName = "Volvo" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeleteBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result=brandManager.Delete(new Brand { BrandId = 5, BrandName = "Mercedes" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result= brandManager.Add(new Brand { BrandId = 5, BrandName = "Mercedes" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UpdateColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result=colorManager.Update(new Color { ColorId = 1, ColorName = "gold" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void DeleteColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result=colorManager.Delete(new Color { ColorId = 2, ColorName = "siyah" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result=colorManager.Add(new Color { ColorId = 3, ColorName = "Kırmızı" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


        public static void AddCarTest()
        {
            VehicleManager carManager = new VehicleManager(new EfVehicleDal());
            var result=carManager.Add(new Vehicle { Id = 9, BrandId = 5, ColorId = 3, VehicleName = "BMW 316i", ModelYear = 2019, DailyPrice = 400, Description = "otomatik" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void UpdateCarTest()
        {
            VehicleManager carManager = new VehicleManager(new EfVehicleDal());
            var result=carManager.Update(new Vehicle { Id = 9, BrandId = 5, ColorId = 3, VehicleName = "520i", ModelYear = 2018, DailyPrice = 350, Description = "otomatik" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        public static void DeleteCarTest()
        {
            VehicleManager carManager = new VehicleManager(new EfVehicleDal());
            var result=carManager.Delete(new Vehicle { Id = 8, BrandId = 5, ColorId = 3, VehicleName = "BMW 316i", ModelYear = 2019, DailyPrice = 400, Description = "otomatik" });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
