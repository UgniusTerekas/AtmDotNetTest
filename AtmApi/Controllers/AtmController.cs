using AtmApi.Contracts;
using AtmProject;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AtmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAtm _atm;

        public AtmController(IMapper mapper, IAtm atm)
        {
            _mapper = mapper;
            _atm = atm;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExchangeMoneyResponse>> GetExchangeMoney(int money)
        {
            var exchangedMoney = _atm.Exchange(money);

            var exchangeMoneyResponse = _mapper.Map<IEnumerable<ExchangeMoneyResponse>>(exchangedMoney);

            return Ok(exchangeMoneyResponse);
        }
    }
}
