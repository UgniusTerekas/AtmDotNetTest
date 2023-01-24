using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtmApi.Contracts;
using AtmApi.Controllers;
using AtmProject;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ATM_tests
{
    public class AtmControllerTests
    {
        [Fact]
        public void GetExchangeMoney_GivenMoneyToExchange_WhenMoneyIsRequested_ShouldReturnJsonResponse()
        {
            // arrange
            const int anyMoney = 0;
            var mapperMock = new Mock<IMapper>();
            var atmMock = new Mock<IAtm>();

            mapperMock.Setup(m => m
                .Map<ExchangeMoney, IEnumerable<ExchangeMoneyResponse>>(It.IsAny<ExchangeMoney>()))
                .Returns(new List<ExchangeMoneyResponse>());

            atmMock.Setup(a => a
                .Exchange(It.IsAny<int>()))
                .Returns(new List<ExchangeMoney>());

            var atmController = new AtmController(mapperMock.Object, atmMock.Object);

            // act
            var actionResult = atmController.GetExchangeMoney(anyMoney);

            // assert
            Assert.IsType<ActionResult<IEnumerable<ExchangeMoneyResponse>>>(actionResult);
        }
    }
}
