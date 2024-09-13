using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainwayStation
{
    public class Track
    {
        private int id;
        private string direction;
        private List<Train> currTrains;
        public int Id { get => id; set => id = value; }
        public List<Train> CurrTrains { get => currTrains; set => currTrains = value; }
        public string Direction { get => direction; set => direction = value; }

        public Track(int id, string direction)
        {
            this.id = id;
            this.direction = direction;
            this.CurrTrains = new List<Train>();
        }
    }
}
