﻿using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class ProductOrderRepository:BaseRepository<ProductOrder>,IProductOrderRepository
    {
        public ProductOrderRepository(CompanyRestaurantContext context):base(context)
        {
            
        }
    }
}
