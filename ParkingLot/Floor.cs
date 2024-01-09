using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class Floor
    {
        public int FloorId { get; set; }

        private Dictionary<ParkingSlotType,Dictionary<String,ParkingSlot>> Slots { get; set; }

        public Floor(int floorId, Dictionary<ParkingSlotType, Dictionary<String, ParkingSlot>> slots)
        {
            this.FloorId = floorId;
            this.Slots = slots;
        }

        public void AddParkingSlot(ParkingSlot parkingSlot)
        {
            if (Slots.ContainsKey(parkingSlot.GetParkingSlotType()))
            {
                this.Slots[parkingSlot.GetParkingSlotType()].Add(parkingSlot.GetSlotId(),parkingSlot);
            }
            else
            {
                var parkingSlotList = new Dictionary<String,ParkingSlot>();
                parkingSlotList.Add(parkingSlot.GetSlotId(),parkingSlot);
                this.Slots.Add(parkingSlot.GetParkingSlotType(), parkingSlotList);
            }
        }

        public void RemoveParkingSlot(ParkingSlot parkingSlot)
        {
            if (!this.Slots.ContainsKey(parkingSlot.GetParkingSlotType()))
            {
                throw new Exception("The given parking slot is not in this floor");
            }

            var parkingSlotList = this.Slots[parkingSlot.GetParkingSlotType()];

            if (!parkingSlotList.ContainsKey(parkingSlot.GetSlotId()))
            {
                throw new Exception("The given parking slot is not in this floor");
            }

            parkingSlotList.Remove(parkingSlot.GetSlotId());
        }

        public ParkingSlot GetAvailableParkingSlotForVehicle(Vehicle vehicle)
        {
            var parkingSlotTypeRequired = this.GetParkingSlotTypeForVehicleType(vehicle.VehicleType);
            if (!this.Slots.ContainsKey(parkingSlotTypeRequired))
                return null;

            var parkingSlotsOfSameType = this.Slots[parkingSlotTypeRequired];
            foreach (var parkingSlotKey in parkingSlotsOfSameType.Keys)
            {
                if (parkingSlotsOfSameType[parkingSlotKey].IsAvailable)
                    return parkingSlotsOfSameType[parkingSlotKey];
            }
            return null;
        }

        private ParkingSlotType GetParkingSlotTypeForVehicleType(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.TWOWHEELER:
                    return ParkingSlotType.TWOWHEELER;
                case VehicleType.CAR:
                    return ParkingSlotType.LIGHT;
                case VehicleType.VAN:
                    return ParkingSlotType.MEDIUM;
                case VehicleType.TRUCK:
                    return ParkingSlotType.HEAVY;
                case VehicleType.BUS:
                    return ParkingSlotType.HEAVY;
                default:
                    return ParkingSlotType.HEAVY;
            }
        }
    }
}