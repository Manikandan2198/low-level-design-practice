using System;
using System.Collections.Generic;
using System.Text;

namespace ElevatorSystem
{
    public class Elevator
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; }
        public Direction Direction { get; set; }
        public Status Status { get; set; }
        public InternalButton InternalButton { get; set; }
        public Display Display { get; set; }

        public Elevator(int id,int currentFloor, InternalButtonDispatcher internalButtonDispatcher)
        {
            this.Id = id;
            this.CurrentFloor = currentFloor;
            this.Status = Status.IDLE;
            this.InternalButton = new InternalButton(id, internalButtonDispatcher);
        }

        public void MoveToFloor(int floor, Direction direction)
        {
            this.CurrentFloor = floor;
            this.Direction = direction;
            this.Display.SetDisplay(floor, direction);
        }
    }

    public class Display
    {
        public int Floor { get; set; }
        public Direction Direction { get; set; }
        public void SetDisplay(int floor, Direction direction)
        {
            this.Floor = floor;
            this.Direction = direction;
        }
    }

    public enum Status
    {
        MOVING,
        IDLE
    }

    public enum Direction
    {
        UP,
        DOWN,
        NONE
    }
}
