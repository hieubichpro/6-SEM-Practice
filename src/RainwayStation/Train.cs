using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace RainwayStation
{
    public class Train
    {
        private int id;
        private PictureBox pic = new PictureBox();
        private TimeSpan arrivalTime;
        private TimeSpan departureTime;
        private string direction;
        private string type;
        private int platformAssigned;
        private int trackAssigned;
        private bool hasDrawn = false;
        private bool wasPlaned = false;
        private int speed = 7;

        private int timeStoped = 50;
        static public int speedGlobal = 7;
        static public Dictionary<int, Point> positions = new Dictionary<int, Point>
        {
            {1, new Point(0, 71 + 177) },
            {2, new Point(1127, 115 + 177) },
            {3, new Point(0, 242 + 177) },
            {4, new Point(1127, 286 + 177) },
            {5, new Point(0, 428 + 177) },
            {6, new Point(1127, 472 + 177) }
        };

        public int Id { get => id; set => id = value; }
        public TimeSpan ArrivalTime { get => arrivalTime; set => arrivalTime = value; }
        public TimeSpan DepartureTime { get => departureTime; set => departureTime = value; }
        public string Direction { get => direction; set => direction = value; }
        public string Type { get => type; set => type = value; }
        public PictureBox Pic { get => pic; set => pic = value; }
        public int PlatformAssigned { get => platformAssigned; set => platformAssigned = value; }
        public int TrackAssigned { get => trackAssigned; set => trackAssigned = value; }
        public bool HasDrawn { get => hasDrawn; set => hasDrawn = value; }
        public int Speed { get => speed; set => speed = value; }
        public int TimeStoped { get => timeStoped; set => timeStoped = value; }
        public bool WasPlaned { get => wasPlaned; set => wasPlaned = value; }

        public Train(int id, TimeSpan departureTime, TimeSpan arrivalTime, string direction, string type)
        {
            this.id = id;
            pic.BackColor = Color.Red;
            pic.Location = new Point();
            pic.Size = new Size(100, 38);
            this.arrivalTime = arrivalTime;
            this.departureTime = departureTime;
            this.direction = direction;
            this.type = type;
        }

        public void MoveTrain()
        {
            var pos = pic.Location;
            pos.X += Speed;
            pic.Location = pos;
        }

        public void setSpeed()
        {
            if (trackAssigned % 2 == 0)
                Speed = -Speed;
        }
        public bool hasArrived(int width)
        {
            if (trackAssigned % 2 == 0)
                return pic.Location.X <= 0;
            else
                return pic.Location.X >= width;
        }
    }
}
