using VehicleRentalSystem;

Vehicle vc1 = VehicleFactory.Create(VehicleType.Car, ("Mitsubishi", "Mirage", 15000, DateTime.Now.AddDays(-10), TimeSpan.FromDays(10), 4));
Vehicle vc2 = VehicleFactory.Create(VehicleType.Motorcycle, ("Triumph", "Tiger Sport 660", 10000, DateTime.Now.AddDays(-10), TimeSpan.FromDays(10), 20));
Vehicle vc3 = VehicleFactory.Create(VehicleType.CargoVan, ("Citroen", "Jumper", 20000, DateTime.Now.AddDays(-10), TimeSpan.FromDays(15), 8));

Invoice.Print(VehicleType.Car, vc1, "John Doe", DateTime.Now.AddDays(10));
Invoice.Print(VehicleType.Motorcycle, vc2, "Mary Johnson", DateTime.Now.AddDays(10));
Invoice.Print(VehicleType.CargoVan, vc3, "John Markson", DateTime.Now.AddDays(10));
