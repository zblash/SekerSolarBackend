using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Dtos;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PhotoManager : IPhotoService
    {
        private readonly PhotoDal _photoDal;
        private readonly IMapper _mapper;

        public PhotoManager(PhotoDal photoDal,IMapper mapper)
        {
            _mapper = mapper;
            _photoDal = photoDal;
        }

        public async Task Add(Photo photo)
        {

            await _photoDal.Add(photo);
        }      
               
        public async Task Delete(int photoid)
        {
            await _photoDal.Delete(new Photo {Id = photoid});
        }

        public async Task<List<PhotoDto>> GetAll()
        {
            var photos = await _photoDal.GetList();
            return _mapper.Map<List<PhotoDto>>(photos);
        }

        public async Task<PhotoDto> GetById(int id)
        {
            var photo = await _photoDal.Get(p => p.Id == id);
            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task Update(Photo photo)
        {
            await _photoDal.Update(photo);
        }
    }
}
