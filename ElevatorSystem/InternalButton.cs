namespace ElevatorSystem
{
    public class InternalButton
    {
        public InternalButtonDispatcher InternalButtonDispatcher { get; set; }
        public int ElevatorId { get; set; }

        public InternalButton(int elevatorId, InternalButtonDispatcher internalButtonDispatcher)
        {
            this.ElevatorId = elevatorId;
            this.InternalButtonDispatcher = internalButtonDispatcher;
        }
        public void PressButton(int destinationFloorNumber)
        {

        }
    }
}