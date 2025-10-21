using AutoMapper;
using AssetControl.SmallBiz.Modules.Customers.Models;
using AssetControl.SmallBiz.Modules.Customers.Dtos;

namespace AssetControl.SmallBiz.Modules.Customers.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerReadDto>().ReverseMap();
        CreateMap<CustomerCreateDto, Customer>();
        CreateMap<CustomerUpdateDto, Customer>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
