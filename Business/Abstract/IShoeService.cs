using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IShoeService
    {
       IDataResult< List<Shoe>> GetAll();

        IDataResult<List<Shoe>> GetByBrandId(int brandId);
        IDataResult<Shoe> GetById(int shoeId);
        IResult Add(Shoe shoe);
      
    }
}
