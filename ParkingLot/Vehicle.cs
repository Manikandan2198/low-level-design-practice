namespace ParkingLot
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public VehicleType VehicleType { get; set; }
    }

    public enum VehicleType
    {
        TWOWHEELER,
        CAR,
        VAN,
        TRUCK,
        BUS
    }
}