using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public enum TileStatus {
        CLOSED, OPEN, FLAGGED
    }

    public class Tile
    {
       
        public bool Open()
        {
            if (Mine)
                return false;

                Status = TileStatus.OPEN;
                return true;
            
        }

        public void SetFlag()
        {
            if (Status == TileStatus.FLAGGED)
                Status = TileStatus.CLOSED;
            else
            Status = TileStatus.FLAGGED;
        }

        public bool Mine
        {
            get;
            set;
        }

        public TileStatus Status
        {
            get;
            set;
        }
    }
}
