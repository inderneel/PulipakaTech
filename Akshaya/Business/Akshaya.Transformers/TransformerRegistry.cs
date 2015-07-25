using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akshaya.AppEntities.Entities;
using Akshaya.Data.Entities;
using AutoMapper;

namespace Akshaya.Transformers
{
    public class TransformerRegistry
    {
        //public TransformerRegistry()
        //{
        //    RegisterMappings();

        //}
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Product, ProductModel>();
            Mapper.CreateMap<Picture, PictureModel>();
        }
    }
}
