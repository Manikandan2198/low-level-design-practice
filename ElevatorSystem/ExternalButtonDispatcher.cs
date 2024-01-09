using System.Collections.Generic;
using System.Linq;

namespace ElevatorSystem
{
    public class LookScanExternalButtonDispatcher : IExternalButtonDispatcher
    {
        public Dictionary<int, ElevatorController> ElevatorControllers { get; set; }

        private LookScanExternalButtonDispatcher ExternalButtonDispatcher;

        private LookScanExternalButtonDispatcher()
        {
            ElevatorControllers = new Dictionary<int, ElevatorController>();
        }

        public IExternalButtonDispatcher GetDispatcher()
        {
            if (ExternalButtonDispatcher != null)
                return ExternalButtonDispatcher;
            ExternalButtonDispatcher = new LookScanExternalButtonDispatcher();
            return ExternalButtonDispatcher;
        }

        public void SubmitRequest(int currentFloorId, Direction direction)
        {
            var idleElevator = ElevatorControllers.Values.FirstOrDefault(e => e.Elevator.Status == Status.IDLE);

            if(idleElevator != null)
            {
                idleElevator.SubmitRequest(currentFloorId);
            }
            var sameDirectionElevatorControllers = ElevatorControllers.Values.Where(e => e.Elevator.Direction == direction).ToList();
            List<ElevatorController> sameDirectionElegibleElevatorontrollers = null;
            if(direction == Direction.UP)
            {
                sameDirectionElegibleElevatorontrollers = ElevatorControllers.Values.Where(e => e.Elevator.CurrentFloor <= currentFloorId).ToList();
            }
            else
            {
                sameDirectionElegibleElevatorontrollers = ElevatorControllers.Values.Where(e => e.Elevator.CurrentFloor >= currentFloorId).ToList();
            }

            foreach (var elevatorController in sameDirectionElegibleElevatorontrollers)
            {
                elevatorController.SubmitRequest(currentFloorId);
            }
        }
    }
}