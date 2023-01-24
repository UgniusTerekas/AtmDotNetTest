using AtmProject;

namespace ATM_tests
{
    public class AtmTests
    {
        [Theory]
        [MemberData(nameof(MoneyAndSupportedNominalsCount))]
        public void
            Exchange_GivenAtmSupports200NominalsAnd1Cent_WhenMoneyIsRequested_ShouldReturnCorrectExchange(
                int money, List<ExchangeMoney> expected)
        {
            //Arrange
            var atm = new Atm();

            //Act
            var actual = atm.Exchange(money);

            //Assert
            Assert.Equivalent(expected, actual);
        }

        public static IEnumerable<object[]> MoneyAndSupportedNominalsCount()
        {
            yield return new object[] { 200, new List<ExchangeMoney> { new ExchangeMoney("200", 1)} };
            yield return new object[] { 405, new List<ExchangeMoney> { new ExchangeMoney("200", 2), new ExchangeMoney("1", 500) } };
            yield return new object[] { 100, new List<ExchangeMoney> { new ExchangeMoney("1", 10000) } };
        }
    }
}