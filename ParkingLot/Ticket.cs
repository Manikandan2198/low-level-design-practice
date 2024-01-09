using System;

namespace ParkingLot
{
    public class Ticket
    {
        public Vehicle Vehicle { get; set; }
        public ParkingSlot ParkingSlot { get; set; }
        public DateTime EntryTime { get; set; }

        public Ticket(Vehicle vehicle, ParkingSlot parkingSlot)
        {
            this.Vehicle = vehicle;
            this.ParkingSlot = parkingSlot;
            this.EntryTime = DateTime.Now;
        }
    }
}