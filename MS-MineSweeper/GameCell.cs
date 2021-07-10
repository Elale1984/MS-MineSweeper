using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeperConsole
{
    class GameCell
    {
        public GameCell(int rows, int column, bool activeState, bool isLive, int liveNeighbors)
        {
            this.Rows = rows;
            this.Column = column;
            this.ActiveState = activeState;
            this.IsLive = isLive;
            this.LiveNeighbors = liveNeighbors;
        }

        public int Rows { get; set; }
        public int Column { get; set; }
        public bool ActiveState { get; set; }
        public bool IsLive { get; set; }
        public int LiveNeighbors { get; set; }


    }
}
