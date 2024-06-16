namespace VehicleRentalSystem
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle((string brand, string model, double value, DateTime rentalStartDate, TimeSpan rentalPeriod, int additionalProp) details) : base(details.brand, details.model, details.value, details.rentalStartDate, details.rentalPeriod)
        {
            AdditionalProp = details.additionalProp;
        }
        public override int AdditionalProp
        {
            get => base.AdditionalProp;
            set
            {
                if (Math.Sign(value) <= 0)
                {
                    throw new ArgumentOutOfRangeException("Driver age must be a positive number");
                }
                base.AdditionalProp = value;
            }
        }
    }
}
