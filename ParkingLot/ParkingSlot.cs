using System;

namespace ParkingLot
{
    public class ParkingSlot
    {
        private String SlotId { get; set; }
        private ParkingSlotType ParkingSlotType { get; set; }
        private Vehicle Vehicle { get; set; }
        public Boolean IsAvailable { get; set; }

        public ParkingSlot(String slotId, ParkingSlotType parkingSlotType)
        {
            this.SlotId = slotId;
            this.ParkingSlotType = parkingSlotType;
            this.IsAvailable = true;
        }

        public String GetSlotId()
        {
            return this.SlotId;
        }

        public ParkingSlotType GetParkingSlotType()
        {
            return this.ParkingSlotType;
        }

        public void AllocateSlot(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
            this.IsAvailable = false;
        }

        public void DeAllocateSlot()
        {
            this.Vehicle = null;
            this.IsAvailable = true;
        }
    }

    public enum ParkingSlotType
    {
        TWOWHEELER=1,
        LIGHT=2,
        MEDIUM=2,
        HEAVY=3
    }
}