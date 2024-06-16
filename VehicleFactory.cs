namespace VehicleRentalSystem
{
    internal class VehicleFactory
    {
        public static Vehicle Create(VehicleType vehicleType, (string brand, string model, double value, DateTime rentalStartDate, TimeSpan rentalPeriod, int additionalProp) details)
        {
            switch(vehicleType)
            {
                case VehicleType.Car: return new Car(details);
                case VehicleType.Motorcycle: return new Motorcycle(details);
                case VehicleType.CargoVan: return new CargoVan(details);
                default: throw new NotSupportedException($"{vehicleType} is not supported");
            }
        } 
    }
}
