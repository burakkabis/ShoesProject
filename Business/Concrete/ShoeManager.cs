using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Businnes;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ShoeManager : IShoeService
    {
        IShoeDal _shoeDal;

        public ShoeManager(IShoeDal shoeDal)
        {
            _shoeDal = shoeDal;
        }
        [SecuredOperation("shoe.add,admin")]
        [ValidationAspect(typeof(ShoeValidator))]
        public IResult Add(Shoe shoe)
        {
            IResult result = BusinessRules.Run(CheckIfShoeNameExist(shoe.ShoeName),CheckIfShoeCountOfCategoryCorrect(shoe.CategoryId));
            //ValidationTool.Validate(new AnimalValidator(), animal);
            if (result != null) //Kurala uymayan bir logic olusmussa

            {

                return result;
            }
            //Is kodlarinadn geciyorsa veri erisimi cagirmamz lazim.(_productdal)

            _shoeDal.Add(shoe);
            return new SuccessResult(Messages.ShoeAdded);
        }

        [CacheAspect]
        public IDataResult<List<Shoe>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Shoe>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Shoe>>(_shoeDal.GetAll(), Messages.ShoesListed);


        }

        public IDataResult<List<Shoe>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Shoe>>( _shoeDal.GetAll(s => s.BrandId == brandId));
        }

        [CacheAspect]

        public IDataResult<Shoe> GetById(int shoeId)
        {
            // return new SuccessDataResult<List<Shoe>> (_shoeDal.Get(s => s.Id == shoeId));
            return new SuccessDataResult<Shoe>(_shoeDal.Get(s => s.Id == shoeId));

        }



        private IResult CheckIfShoeCountOfCategoryCorrect(int categoryId)
        {
            var result = _shoeDal.GetAll(s => s.CategoryId ==categoryId).Count;

            if (result >= 15)
            {
                return new ErrorResult(Messages.ShoeCountOfCategoryError);

            }
            return new SuccessResult();

        }



        private IResult CheckIfShoeNameExist(string shoeName)
        {
            var result = _shoeDal.GetAll(s => s.ShoeName == shoeName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ShoeNameAlreadyExist);

            }
            return new SuccessResult();

        }
    }
}
