using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorSystem
{
    public class InternalButtonDispatcher
    {
        public Dictionary<int,ElevatorController> ElevatorControllers { get; set; }

        private InternalButtonDispatcher internalButtonDispatcher;

        private InternalButtonDispatcher()
        {
            ElevatorControllers = new Dictionary<int, ElevatorController>();
        }

        public InternalButtonDispatcher GetDispatcher()
        {
            if (internalButtonDispatcher != null)
                return internalButtonDispatcher;
            internalButtonDispatcher = new InternalButtonDispatcher();
            return internalButtonDispatcher;
        }

        public void SubmitRequest(int elevatorId, int destinationFloor)
        {
            var elevatorController = this.ElevatorControllers.ContainsKey(elevatorId) ? this.ElevatorControllers[elevatorId] : null;
            if (elevatorController == null)
                throw new Exception("Elevator is not operational");
            elevatorController.SubmitRequest(destinationFloor);
        }
    }
}
