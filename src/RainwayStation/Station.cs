using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainwayStation
{
    public class Station
    {
        private string name;
        private List<Platform> platforms;
        private List<Train> trains;

        public string Name { get => name; set => name = value; }
        public List<Platform> Platforms { get => platforms; set => platforms = value; }
        public List<Train> Trains { get => trains; set => trains = value; }

        public Station(string name, List<Platform> platforms)
        {
            this.name = name;
            this.platforms = platforms;
            this.trains = new List<Train>();
        }
        public void AddTrain(Train train)
        {
            this.trains.Add(train);
        }

        public void Schedule()
        {
            foreach (var train in trains.OrderBy(t => t.DepartureTime))
            {
                TimeSpan minTime = new TimeSpan(23, 59, 59);
                Platform platformTmp = null;
                Track trackTmp = null;
                foreach (var platform in platforms)
                {
                    foreach (var track in platform.Tracks)
                    {
                        if ((train.Direction.Split(' ')[0] == "Moscow" && track.Direction == "From Moscow") ||
                            (train.Direction.Split(' ')[0] != "Moscow" && track.Direction == "To Moscow"))
                        {
                            if (track.CurrTrains.Count == 0 ||
                            (train.DepartureTime.TotalMinutes - track.CurrTrains.Last().DepartureTime.TotalMinutes) >= 9)
                            {
                                track.CurrTrains.Add(train);
                                train.PlatformAssigned = platform.Id;
                                train.TrackAssigned = track.Id;
                                train.WasPlaned = true;
                                train.setSpeed();
                                break;
                            }
                            else
                            {
                                if (track.CurrTrains.Last().DepartureTime <= minTime)
                                {
                                    minTime = track.CurrTrains.Last().DepartureTime;
                                    platformTmp = platform;
                                    trackTmp = track;
                                }
                            }
                        }
                    }
                    if (train.WasPlaned)
                        break;
                }
                if (!train.WasPlaned)
                {
                    train.DepartureTime = TimeSpan.FromMinutes(minTime.TotalMinutes + 10);
                    trackTmp.CurrTrains.Add(train);
                    train.PlatformAssigned = platformTmp.Id;
                    train.TrackAssigned = trackTmp.Id;
                    train.WasPlaned = true;
                    train.setSpeed();
                }
                    
            }
        }

        public void UpdatePlatforms(int width)
        {
            foreach (var platform in platforms)
            {
                foreach (var track in platform.Tracks)
                {
                    track.CurrTrains.RemoveAll(t => t.hasArrived(width) == true);
                }
            }
        }
	}
}
