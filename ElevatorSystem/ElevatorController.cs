using System.Collections.Generic;

namespace ElevatorSystem
{
    public class ElevatorController
    {
        public Elevator Elevator { get; set; }

        private SortedSet<int> UpDirectionStops { get; set; }

        private SortedSet<int> DownDirectionStops { get; set; }

        public void SubmitRequest(int destinationFloor)
        {
            if(Elevator.Direction == Direction.NONE && Elevator.Status == Status.IDLE)
            {
                if (destinationFloor > Elevator.CurrentFloor)
                {
                    UpDirectionStops.Add(destinationFloor);
                    Elevator.Direction = Direction.UP;
                }
                else
                {
                    DownDirectionStops.Add(destinationFloor);
                    Elevator.Direction = Direction.DOWN;
                }

                Elevator.Status = Status.MOVING;
            }
            else if (Elevator.Direction == Direction.UP && destinationFloor > Elevator.CurrentFloor)
            {
                UpDirectionStops.Add(destinationFloor);
            }
            else if(Elevator.Direction == Direction.UP)
            {
                DownDirectionStops.Add(destinationFloor);
            }
            else if (Elevator.Direction==Direction.DOWN && destinationFloor < Elevator.CurrentFloor)
            {
                DownDirectionStops.Add(destinationFloor);
            }
            else if(Elevator.Direction == Direction.DOWN)
            {
                UpDirectionStops.Add(destinationFloor);
            }

        }

        public void ControlCar()
        {
            var nextFloor = Elevator.CurrentFloor;
            if (Elevator.Direction == Direction.NONE || (UpDirectionStops.Count == 0 && DownDirectionStops.Count == 0))
                return;

            if (Elevator.Direction == Direction.UP)
            {
                nextFloor = UpDirectionStops.Min;
                UpDirectionStops.Remove(nextFloor);
            }
            else if (Elevator.Direction == Direction.DOWN)
            {
                nextFloor = DownDirectionStops.Max;
                DownDirectionStops.Remove(nextFloor);
            }

            Elevator.MoveToFloor(nextFloor, Direction.UP);
            if (UpDirectionStops.Count == 0 && DownDirectionStops.Count == 0)
            {
                Elevator.Direction = Direction.NONE;
                Elevator.Status = Status.IDLE;
            }

        }
    }
}