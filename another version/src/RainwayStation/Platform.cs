using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainwayStation
{
    public class Platform
    {
        private int id;
        private List<Track> tracks;
        public int Id { get => id; set => id = value; }
        internal List<Track> Tracks { get => tracks; set => tracks = value; }

        public Platform(int id, List<Track> tracks)
        {
            this.id = id;
            this.tracks = tracks;
        }
    }
}
