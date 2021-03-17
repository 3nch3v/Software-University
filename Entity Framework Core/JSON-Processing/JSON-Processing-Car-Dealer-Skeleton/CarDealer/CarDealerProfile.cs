using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputModel, Supplier>();
            CreateMap<PartsImputModel, Part>();
            CreateMap<CarInputModel, Car>();
            CreateMap<CustomerInputModel, Customer>();
            CreateMap<SalesInputmodel, Sale>();
        }
    }
}
