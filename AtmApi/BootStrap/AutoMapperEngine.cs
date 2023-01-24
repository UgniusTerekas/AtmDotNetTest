using AtmApi.BootStrap.Profiles;
using AtmApi.Contracts;
using AutoMapper;

namespace AtmApi.BootStrap
{
    public static class AutoMapperEngine
    {
        public static void SetupAutoMapper(this IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ExchangeMoneyProfile());
                
            });
            serviceCollection.AddSingleton(config.CreateMapper());
        }
    }
}
