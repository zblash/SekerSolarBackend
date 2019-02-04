using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Business.Abstract
{
    public interface ICustomMapping
    {
        void CreateMapping(Profile profile);
    }
}
