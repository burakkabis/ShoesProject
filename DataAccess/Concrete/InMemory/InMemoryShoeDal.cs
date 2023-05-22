using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryShoeDal : IShoeDal
    {

        List<Shoe> _shoes;
        public InMemoryShoeDal()
        {
            //Sanki bu veri tabanlarindan (Oracle,Sql Server, Postgres , MongoDb) geliyormus gibi kendi bellegimizi olusturduk.Test amacli.

            _shoes = new List<Shoe> {
                new Shoe{Id=1, CategoryId=1,ColorId=1,BrandId=1, ShoeName="Nike",ShoeNo=37, UnitPrice=315, UnitsInStock=15},
               new Shoe{Id=2, CategoryId=2,ColorId=1,BrandId=2, ShoeName="Puma",ShoeNo=36, UnitPrice=225, UnitsInStock=12},
               new Shoe{Id=1, CategoryId=1,ColorId=2,BrandId=1, ShoeName="Adidas",ShoeNo=42, UnitPrice=415, UnitsInStock=18},


            };

        }
        public void Add(Shoe shoe)
        {
            _shoes.Add(shoe);
        }

        public void Delete(Shoe shoe)
        {
            Shoe shoeToDelete = _shoes.SingleOrDefault(s => s.Id == shoe.Id);

            _shoes.Remove(shoeToDelete);
        }

        public Shoe Get(Expression<Func<Shoe, bool>> filter)
        {
            throw new NotImplementedException();
        }



        public List<Shoe> GetAll(Expression<Func<Shoe, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Shoe shoe)
        {
            Shoe shoeToUpdate = _shoes.SingleOrDefault(s => s.Id == shoe.Id);
            shoeToUpdate.ShoeName = shoe.ShoeName;
            shoeToUpdate.Id = shoe.Id;
            shoeToUpdate.CategoryId = shoe.CategoryId;
            shoeToUpdate.BrandId = shoe.BrandId;
            shoeToUpdate.ColorId = shoe.ColorId;
            shoeToUpdate.ShoeNo = shoe.ShoeNo;
            shoeToUpdate.UnitPrice = shoe.UnitPrice;
            shoeToUpdate.UnitsInStock = shoe.UnitsInStock;

        }
    }
}