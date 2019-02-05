using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public PhotosController(IPhotoService photoService, IMapper mapper, IProductService productService)
        {
            _photoService = photoService;
            _productService = productService;
            _mapper = mapper;
        }

        
        [HttpPost("{productId}")]
        public async Task<ActionResult> Add(int productId,[FromBody] PhotoForCreationDTO PhotoDTO)
        {
            
            var product = await _productService.GetById(productId);
            var fileName = product.Name + DateTime.Today.ToString();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            if (product != null)
            {
                var file = PhotoDTO.File;
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var photo = _mapper.Map<Photo>(PhotoDTO);
                    photo.ProductId = productId;
                    await _photoService.Add(photo);

                    return Ok();
                }
                return BadRequest("Could not add photo");
            }
            return BadRequest("There is no product with this id:"+productId);

        }
        
        [HttpDelete("{photoId}")]
        public async Task<ActionResult> Delete(int photoId)
        {
            await _photoService.Delete(photoId);
            return Ok();
        }
    }
}