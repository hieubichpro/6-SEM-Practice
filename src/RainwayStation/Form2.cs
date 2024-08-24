using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainwayStation
{
    public partial class Form2 : Form
    {
        private Station station;
        public static DateTime fastTime = new DateTime(2024, 8, 23, 12, 0, 0);
        private int speedFactor =50;
        public Form2(Station station)
        {

            InitializeComponent();
            this.station = station;
            //fastTime = DateTime.Now;
            timer1.Interval = 100;
            timer1.Start();
            fill(station.Trains);
            //timer2.Interval = 1000;
            //timer2.Start();
        }

        public Station Station { get => station; set => station = value; }
        public void fill(List<Train> trains)
        {
            foreach (var train in trains.OrderBy(t => t.DepartureTime))
            {
                string platform = train.PlatformAssigned == 0 ? "-" : train.PlatformAssigned.ToString();
                string track = train.TrackAssigned == 0 ? "-" : train.TrackAssigned.ToString();
                TimeSpan time = TimeSpan.FromMinutes(train.DepartureTime.TotalMinutes + 0);
                string[] row = { "Поезд " + train.Id, train.Direction, train.Type, time.ToString(), platform, track };
                var item = new ListViewItem(row);
                listView1.Items.Add(item);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //station.Schedule(fastTime.TimeOfDay);
            foreach (var train in station.Trains.OrderBy(t => t.DepartureTime))
            {
                if (!train.HasDrawn && train.WasPlaned && Math.Abs(train.DepartureTime.TotalSeconds - fastTime.TimeOfDay.TotalSeconds) <= 10)
                {
                    //Console.WriteLine(train.TrackAssigned);
                    train.Pic.Location = Train.positions[(int)train.TrackAssigned];
                    Controls.Add(train.Pic);
                    train.Pic.BringToFront();
                    train.HasDrawn = true;
                }
                if ((train.Pic.Location.X >= (int)bg.Size.Width / 2 - (int)Train.speedGlobal / 2) &&
                    (train.Pic.Location.X <= (int)bg.Size.Width / 2 +(int)Train.speedGlobal / 2))
                {
                    train.Speed = 0;
                    train.TimeStoped -= 3;

                }
                if (train.TimeStoped <= 0)
                {
                    if (train.Type == "terminal")
                    {
                        Controls.Remove(train.Pic);
                    }
                    train.Speed = Train.speedGlobal;
                    train.setSpeed();
                }
                if (train.HasDrawn)
                {
                    train.MoveTrain();
                }
                if (train.hasArrived(bg.Size.Width))
                {
                    Controls.Remove(train.Pic);
                    station.UpdatePlatforms(bg.Size.Width);
                }

            }
            fastTime = fastTime.AddSeconds(speedFactor * (timer1.Interval / 1000.0));
            currDate.Text = DateTime.Now.ToLongDateString();
            currTime.Text = fastTime.ToString("HH:mm:ss") + " MCK";
        }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    fill(station.Trains);
        //}
    }
}
