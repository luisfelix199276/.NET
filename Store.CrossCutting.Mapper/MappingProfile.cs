using AutoMapper;
using Store.API.Model.Request.Post;
using Store.API.Model.Response.Get;
using Store.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.CrossCutting.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region [VM => Entity]

            CreateMap<PostCustomerRequestViewModel, Customers>();            

            #endregion

            #region [Entity => VM]

            
            CreateMap<Customers, GetCustomerResponseModelView>();    

            #endregion
        }
    }
}
