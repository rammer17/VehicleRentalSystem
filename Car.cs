namespace VehicleRentalSystem
{
    internal class Car : Vehicle
    {
        public Car((string brand, string model, double value, DateTime rentalStartDate, TimeSpan rentalPeriod, int additionalProp) details) : base(details.brand, details.model, details.value, details.rentalStartDate, details.rentalPeriod)
        {
            AdditionalProp = details.additionalProp;
        }
        public override int AdditionalProp
        {
            get => base.AdditionalProp; set
            {
                if (value is < 1 or > 5)
                {
                    throw new ArgumentOutOfRangeException("Safety rating must be between 1 and 5");
                }
                base.AdditionalProp = value;
            }
        }
    }
}