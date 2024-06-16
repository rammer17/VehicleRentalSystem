namespace VehicleRentalSystem
{
    internal class Vehicle
    {
        public Vehicle(string brand, string model, double value, DateTime rentalStartDate, TimeSpan rentalPeriod)
        {
            Brand = brand;
            Model = model;
            Value = value;
            RentalStartDate = rentalStartDate;
            RentalPeriod = rentalPeriod;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Value { get; set; }
        public DateTime RentalStartDate { get; set; }
        public TimeSpan RentalPeriod { get; set; }
        public virtual int AdditionalProp { get; set; }
    }
}
