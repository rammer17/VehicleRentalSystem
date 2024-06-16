namespace VehicleRentalSystem
{
    internal class Invoice
    {
        public static void Print(VehicleType vehicleType, Vehicle vehicle, string customerName, DateTime returnDate)
        {
            double rentalCostPerDay, insuranceCostPerDay; rentalCostPerDay = insuranceCostPerDay = 0;

            bool reducedRentalCost = vehicle.RentalPeriod > TimeSpan.FromDays(7), reducedInsuranceCost = false;

            double initialInsuranceCostPerDay = 0, insuranceDiscountPerDay;

            switch (vehicleType)
            {
                case VehicleType.Car:
                    rentalCostPerDay += reducedRentalCost ? 15 : 20;
                    insuranceCostPerDay += ((0.01 * vehicle.Value) / 100);

                    //Reduce insurance cost if vehicle is considered high safety
                    if (vehicle.AdditionalProp is >= 4 and <= 5)
                    {
                        reducedInsuranceCost = true;

                        initialInsuranceCostPerDay = insuranceCostPerDay;
                        insuranceCostPerDay *= 0.9;
                        insuranceDiscountPerDay = initialInsuranceCostPerDay - insuranceCostPerDay;
                    }

                    break;
                case VehicleType.Motorcycle:
                    rentalCostPerDay += reducedRentalCost ? 10 : 15;
                    insuranceCostPerDay += ((0.02 * vehicle.Value) / 100);

                    //Increase insurance cost if rider is under 25 years old
                    if (vehicle.AdditionalProp < 25)
                    {
                        reducedInsuranceCost = true;

                        initialInsuranceCostPerDay = insuranceCostPerDay;
                        insuranceCostPerDay *= 1.2;
                        insuranceDiscountPerDay = initialInsuranceCostPerDay - insuranceCostPerDay;
                    }

                    break;
                case VehicleType.CargoVan:
                    rentalCostPerDay += reducedRentalCost ? 40 : 50;
                    insuranceCostPerDay += ((0.03 * vehicle.Value) / 100);

                    //Reduce insurance cost if driver has more than 5 years of experience
                    if (vehicle.AdditionalProp >= 5)
                    {
                        reducedInsuranceCost = true;

                        initialInsuranceCostPerDay = insuranceCostPerDay;
                        insuranceCostPerDay *= 0.85;
                        insuranceDiscountPerDay = initialInsuranceCostPerDay - insuranceCostPerDay;
                    }
                    break;
                default:
                    break;
            }

            DateTime reservationEndDate = vehicle.RentalStartDate + vehicle.RentalPeriod;
            DateTime actualReturnDate = DateTime.Now;
            int actualRentalDays = actualReturnDate.Subtract(vehicle.RentalStartDate).Days;

            double totalRent, totalInsurance, discountedRent = 0, discountedInsurance = 0;

            bool isReturnedPreliminary = reservationEndDate > actualReturnDate;
            //Check if vehicle is returned preliminary
            if (isReturnedPreliminary)
            {
                int daysFullPrice = actualRentalDays;
                int daysHalfPrice = vehicle.RentalPeriod.Days - daysFullPrice;

                discountedRent = (daysHalfPrice * rentalCostPerDay) / 2;
                discountedInsurance = daysHalfPrice * insuranceCostPerDay;

                totalRent = (daysFullPrice * rentalCostPerDay) + discountedRent;
                totalInsurance = daysFullPrice * insuranceCostPerDay;
            }
            else
            {
                totalRent = actualRentalDays * rentalCostPerDay;
                totalInsurance = actualRentalDays * insuranceCostPerDay;
            }

            //Choose correct format method overload
            if (reducedInsuranceCost is true) FormatInvoice(vehicleType, vehicle, customerName, actualReturnDate, actualRentalDays, totalRent, rentalCostPerDay, insuranceCostPerDay, initialInsuranceCostPerDay, totalInsurance, discountedRent, discountedInsurance);
            else FormatInvoice(vehicleType, vehicle, customerName, actualReturnDate, actualRentalDays, totalRent, rentalCostPerDay, insuranceCostPerDay, totalInsurance, discountedRent, discountedInsurance);


        }
        private static void FormatInvoice(VehicleType vehicleType, Vehicle vehicle, string customerName, DateTime actualReturnDate, int actualRentalDays, double totalRent, double rentalCostPerDay, double insuranceCostPerDay, double totalInsurance, double discountedRent, double discountedInsurance)
        {
            Console.WriteLine(
                 $"A {vehicleType.ToString().ToLower()} that is valued at ${vehicle.Value.ToString("N2")}, and \n\n" + 
                 $"XXXXXXXXXX\n" +
                 $"Date: {actualReturnDate.ToString("yyyy-MM-dd")}\n" +
                 $"Customer Name: {customerName}\n" +
                 $"Rented Vehicle: {vehicle.Brand} {vehicle.Model}\n\n" +
                 $"Reservation start date: {vehicle.RentalStartDate.ToString("yyyy-MM-dd")}\n" +
                 $"Reservation end date: {(vehicle.RentalStartDate + vehicle.RentalPeriod).ToString("yyyy-MM-dd")}\n" +
                 $"Reserved rental days: {vehicle.RentalPeriod.Days} days\n\n" +
                 $"Actual return date: {actualReturnDate.ToString("yyyy-MM-dd")}\n" +
                 $"Actual rental days: {actualRentalDays} days\n\n" +
                 $"Rental cost per day: ${rentalCostPerDay.ToString("N2")}\n" +
                 $"Insurance cost per day: ${insuranceCostPerDay.ToString("N2")}\n\n" +
                                  ((discountedRent > 0 && discountedInsurance > 0) ? ($"Early return discount for rent: ${discountedRent.ToString("N2")}\n" + $"Early return discount for insurance: ${discountedInsurance.ToString("N2")}\n\n") : "") +
                 $"Total rent: ${totalRent.ToString("N2")}\n" +
                 $"Total insurance: ${totalInsurance.ToString("N2")}\n" +
                 $"Total: ${(totalRent + totalInsurance).ToString("N2")}\n" +
                 $"XXXXXXXXXX");
        }

        private static void FormatInvoice(VehicleType vehicleType, Vehicle vehicle, string customerName, DateTime actualReturnDate, int actualRentalDays, double totalRent, double rentalCostPerDay, double insuranceCostPerDay, double initialInsuranceCostPerDay, double totalInsurance, double discountedRent, double discountedInsurance)
        {
            Console.WriteLine(
                 $"A {vehicleType.ToString().ToLower()} that is valued at ${vehicle.Value.ToString("N2")}, and \n\n" +
                 $"XXXXXXXXXX\n" +
                 $"Date: {actualReturnDate.ToString("yyyy-MM-dd")}\n" +
                 $"Customer Name: {customerName}\n" +
                 $"Rented Vehicle: {vehicle.Brand} {vehicle.Model}\n\n" +
                 $"Reservation start date: {vehicle.RentalStartDate.ToString("yyyy-MM-dd")}\n" +
                 $"Reservation end date: {(vehicle.RentalStartDate + vehicle.RentalPeriod).ToString("yyyy-MM-dd")}\n" +
                 $"Reserved rental days: {vehicle.RentalPeriod.Days} days\n\n" +
                 $"Actual return date: {actualReturnDate.ToString("yyyy-MM-dd")}\n" +
                 $"Actual rental days: {actualRentalDays} days\n\n" +
                 $"Rental cost per day: ${rentalCostPerDay.ToString("N2")}\n" +
                 $"Initial insurance per day: ${initialInsuranceCostPerDay.ToString("N2")}\n" +
                 $"Insurance {(Math.Sign(initialInsuranceCostPerDay - insuranceCostPerDay) == 1 ? "discount" : "addition")} per day: ${(Math.Abs(initialInsuranceCostPerDay - insuranceCostPerDay)).ToString("N2")}\n" +
                 $"Insurance cost per day: ${insuranceCostPerDay.ToString("N2")}\n\n" +
                 ((discountedRent > 0 && discountedInsurance > 0) ? ($"Early return discount for rent: ${discountedRent.ToString("N2")}\n" + $"Early return discount for insurance: ${discountedInsurance.ToString("N2")}\n\n") : "") +
                 $"Total rent: ${totalRent.ToString("N2")}\n" +
                 $"Total insurance: ${totalInsurance.ToString("N2")}\n" +
                 $"Total: ${(totalRent + totalInsurance).ToString("N2")}\n" +
                 $"XXXXXXXXXX");
        }
    }
}
