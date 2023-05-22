using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ShoeGetAll();

            //GetById();
            //GetByBrandId();


            //BrandGetAll();

            // GetByIdBrand();
            //AddBrand();
          



        }

        private static void AddBrand()
        {
            Brand brand1 = new Brand();
            brand1.Name = "Reebok";
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(brand1);
        }

        private static void GetByIdBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(2);
            Console.WriteLine(result.Name);
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void GetByBrandId()
        {
            ShoeManager shoeManager = new ShoeManager(new EfShoeDal());

            foreach (var shoe in shoeManager.GetByBrandId(2).Data)
            {
                Console.WriteLine(shoe.ShoeName);

            }
        }

        //private static void GetById()
        //{
        //    ShoeManager shoeManager = new ShoeManager(new EfShoeDal());

        //    foreach (var shoe in shoeManager.GetById(2).Data)
        //    {
        //        Console.WriteLine(shoe.ShoeName);

        //    }
        //}

        private static void ShoeGetAll()
        {
            ShoeManager shoeManager = new ShoeManager(new EfShoeDal());
            foreach (var shoe in shoeManager.GetAll().Data)
            {
                Console.WriteLine(shoe.ShoeName);

            }
        }
    }
}
