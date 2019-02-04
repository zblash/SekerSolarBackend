using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Business.Abstract;
using Entities.Concrete;

namespace Business.Dtos
{
    public class PhotoDto : ICustomMapping
    {

        public int Id { get; set; }
        public string photoUrl { get; set; }

        public void CreateMapping(Profile profile)
        {
            profile.CreateMap<Photo,PhotoDto>();
        }
    }
}
