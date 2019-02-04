using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        Task<List<PhotoDto>> GetAll();

        Task<PhotoDto> GetById(int id);

        Task Add(Photo photo);

        Task Delete(int photoid);

        Task Update(Photo photo);
    }
}
