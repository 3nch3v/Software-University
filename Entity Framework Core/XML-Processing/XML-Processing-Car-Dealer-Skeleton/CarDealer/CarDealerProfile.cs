using AutoMapper;
using CarDealer.ImportModels;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDto, Supplier>();
            CreateMap<PartsImportDto, Part>();
            CreateMap<CustomersImportDto, Customer>();
            CreateMap<SalesImportDto, Sale>();
        }
    }
}
