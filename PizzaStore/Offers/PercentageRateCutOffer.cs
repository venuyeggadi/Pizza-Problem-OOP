namespace PizzaStore.Offers
{
	public class PercentageRateCutOffer : IOffer
	{
        public double Percentage { get; }
        private Func<Pizza, bool> _shouldApply;

        public PercentageRateCutOffer(double percentage, Func<Pizza, bool> shouldApply)
		{
            this.Percentage = percentage;
            this._shouldApply = shouldApply;
		}

        public double Apply(Pizza pizza)
        {
            if (_shouldApply(pizza))
            {
                return pizza.Price * this.Percentage / 100.0;
            }

            return 0;
        }
    }
}

