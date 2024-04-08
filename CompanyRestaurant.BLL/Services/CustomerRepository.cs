﻿using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CompanyRestaurantContext context) : base(context)
        {
        }
    }
}
