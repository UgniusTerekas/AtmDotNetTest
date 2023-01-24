namespace AtmProject
{
    public interface IAtm
    {
        IEnumerable<ExchangeMoney> Exchange(int money);
    }

    public class Atm : IAtm
    {
        private const int SupportedNominal = 200;
        private const int SupportedCoin = 1;

        public IEnumerable<ExchangeMoney> Exchange(int money)
        {
            var exchangeCountList = new List<ExchangeMoney>();

            var isDividable = money % SupportedNominal == 0;
            var isNominalsNeeded = money / SupportedNominal != 0;

            if (isDividable)
            {
                return ExchangeNominals(money);
            }

            if (isNominalsNeeded)
            {
                return ExchangeNominalsCents(money);
            }

            return ExchangeCents(money);
        }

        private IEnumerable<ExchangeMoney> ExchangeNominals(int money)
        {
            var exchangeCountList = new List<ExchangeMoney>();
            var nominalCount = money / SupportedNominal;
            var dividableExchange = new ExchangeMoney(SupportedNominal.ToString(), nominalCount);
            exchangeCountList.Add(dividableExchange);

            return exchangeCountList;
        }

        private IEnumerable<ExchangeMoney> ExchangeNominalsCents(int money)
        {
            var exchangeCountList = new List<ExchangeMoney>();
            var nominalCount = money / SupportedNominal;
            var coinsCount = (money - nominalCount * SupportedNominal) * 100;

            var nominals = new ExchangeMoney(SupportedNominal.ToString(), nominalCount);
            var cents = new ExchangeMoney(SupportedCoin.ToString(), coinsCount);

            exchangeCountList.Add(nominals);
            exchangeCountList.Add(cents);

            return exchangeCountList;
        }

        private IEnumerable<ExchangeMoney> ExchangeCents(int money)
        {
            var exchangeCountList = new List<ExchangeMoney>();
            var coinsCount = money * 100;
            var onlyCentsExchange = new ExchangeMoney(SupportedCoin.ToString(), coinsCount);
            exchangeCountList.Add(onlyCentsExchange);

            return exchangeCountList;
        }
    }
}