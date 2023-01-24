using AtmApi.Contracts;
using AtmProject;
using AutoMapper;

namespace AtmApi.BootStrap.Profiles
{
    public class ExchangeMoneyProfile : Profile
    {
        public ExchangeMoneyProfile()
        {
            CreateMap<ExchangeMoney, ExchangeMoneyResponse>()
                .ForMember(dest => dest.NominalsCount, opt => opt.MapFrom(src => src.Count));
        }
    }
}
