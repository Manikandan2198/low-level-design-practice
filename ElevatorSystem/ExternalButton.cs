namespace ElevatorSystem
{
    public class ExternalButton
    {
        public int FloorId { get; set; }
        public IExternalButtonDispatcher ExternalButtonDispatcher { get; set; }

        public void PressButton(Direction direction)
        {

        }
    }
}