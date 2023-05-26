namespace PizzaStore.Offers
{
	public class FixedRateCutOffer : IOffer
	{
		public double Amount { get; }
		private Func<Pizza, bool> _shouldApply;

		public FixedRateCutOffer(double amount, Func<Pizza, bool> shouldApply)
		{
			this.Amount = amount;
			this._shouldApply = shouldApply;
		}

        public double Apply(Pizza pizza)
        {
			if (_shouldApply(pizza))
			{
				return this.Amount;
			}

			return 0;
        }
    }
}

