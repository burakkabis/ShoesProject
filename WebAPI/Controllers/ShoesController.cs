using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {

        IShoeService _shoeService;

        public ShoesController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _shoeService.GetAll();
            if (result.Success)
            {
                return Ok(result);//Ok 200 donduruyor.

            }
            return BadRequest(result);

        }


        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _shoeService.GetById(id);
            if (result.Success)

            {
                return Ok(result);
            }
            return BadRequest(result);
        
        
        }


        [HttpPost("add")]
        public IActionResult Add(Shoe shoe)

        {
            var result = _shoeService.Add(shoe);

            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
            
        
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBradnId(int brandId)
        {
            var result = _shoeService.GetByBrandId(brandId);

            if (result.Success)

            {
                return Ok(result);
            }
            return BadRequest(result);


        }





    }


}
