namespace ElevatorSystem
{
    public interface IExternalButtonDispatcher
    {
        IExternalButtonDispatcher GetDispatcher();
        void SubmitRequest(int currentFloorId, Direction direction);
    }
}