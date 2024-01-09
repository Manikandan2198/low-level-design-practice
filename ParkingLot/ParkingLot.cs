using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLot
{
    class ParkingLot
    {
        private String Name { get; set; }
        private Address Address { get; set; }
        private List<Floor> Floors { get; set; }

        private ParkingLot parkingLot { get; set; }

        private ParkingLot(String name,Address address)
        {
            this.Name = name;
            this.Address = address;
            this.Floors = new List<Floor>();
        }

        public ParkingLot GetInstance(String name, Address address)
        {
            if (parkingLot != null)
                return parkingLot;

            parkingLot = new ParkingLot(name, address);
            return parkingLot;
        }

        public Ticket AssignTicket(Vehicle vehicle)
        {
            ParkingSlot parkingSlot = null;
            foreach (var floor in this.Floors)
            {
                parkingSlot = floor.GetAvailableParkingSlotForVehicle(vehicle);
                if (parkingSlot != null)
                    break;
            }

            return CreateTicket(vehicle,parkingSlot);
        }

        private Ticket CreateTicket(Vehicle vehicle, ParkingSlot parkingSlot)
        {
            return new Ticket(vehicle, parkingSlot);
        }

        public decimal ScanAndPay(Ticket ticket)
        {
            var endTime = DateTime.Now;
            var duration = endTime.Subtract(ticket.EntryTime).Minutes;
            return CalculateTotalAmount(duration, ticket.ParkingSlot.GetParkingSlotType());
        }

        private decimal CalculateTotalAmount(int durationInMinutes, ParkingSlotType parkingSlotType)
        {
            return ((decimal)parkingSlotType) * durationInMinutes;
        }


        public void AddFloor(Floor floor)
        {
            Floors.Add(floor);
        }

        public void RemoveFloor(Floor floor)
        {
            Floors.Remove(floor);
        }

    }
}
