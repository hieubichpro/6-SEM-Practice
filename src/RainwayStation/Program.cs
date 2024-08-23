using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainwayStation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var trackPL1 = new List<Track>
            {
                new Track(1, "From Moscow"),
                new Track(2, "To Moscow")
            };
            var trackPL2 = new List<Track>
            {
                new Track(3, "From Moscow"),
                new Track(4, "To Moscow")
            };
            var trackPL3 = new List<Track>
            {
                new Track(5, "From Moscow"),
                new Track(6, "To Moscow")
            };
            var platForms = new List<Platform>
            {
                new Platform(1, trackPL1),
                new Platform(2, trackPL2),
                new Platform(3, trackPL3)
            };

            var station = new Station("Center Station", platForms);
            int hourTest = 23;
            int minuteTest = 27;
            var trains = new List<Train>
            {
                new Train(1, new TimeSpan(hourTest, minuteTest + 3, 0), new TimeSpan(17, 20, 0), "Moscow - Kazan", "passing"),
                new Train(2, new TimeSpan(hourTest, minuteTest + 1, 0), new TimeSpan(17, 30, 0), "Moscow - Tula", "passing"),
                new Train(7, new TimeSpan(hourTest, minuteTest + 11, 0), new TimeSpan(17, 30, 0), "Moscow - Tula", "passing"),
                new Train(8, new TimeSpan(hourTest, minuteTest + 7, 0), new TimeSpan(17, 30, 0), "Moscow - Tula", "passing"),
                new Train(9, new TimeSpan(hourTest, minuteTest + 15, 0), new TimeSpan(17, 30, 0), "Moscow - Tula", "passing"),
                new Train(10, new TimeSpan(hourTest, minuteTest + 9, 0), new TimeSpan(17, 30, 0), "Moscow - Tula", "passing"),

                new Train(3, new TimeSpan(hourTest, minuteTest + 20, 0), new TimeSpan(14, 50, 0), "Tula - Moscow", "terminal"),
                new Train(4, new TimeSpan(hourTest, minuteTest + 13, 0), new TimeSpan(17, 30, 0), "Moscow - Peter", "passing"),
                new Train(5, new TimeSpan(hourTest, minuteTest + 6, 0), new TimeSpan(14, 50, 0), "Peter - Moscow", "passing"),
                new Train(6, new TimeSpan(hourTest, minuteTest + 15, 30), new TimeSpan(17, 20, 0), "Moscow - Kazan", "passing")
            };

            foreach (var train in trains)
            {
                station.AddTrain(train);
            }
            station.Schedule();
            //foreach (var train in station.Trains)
            //{
            //    Console.WriteLine("Train ${train.Id]}");
            //    Console.WriteLine(train.DepartureTime);
            //    Console.WriteLine(train.PlatformAssigned);
            //    Console.WriteLine(train.TrackAssigned);
            //    Console.WriteLine("");
            //}
            Application.Run(new Form2(station));
            //foreach (var train in station.Trains)
            //{
            //    Console.WriteLine($"{train.PlatformAssigned},  {train.TrackAssigned}");
            //}
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //TimeSpan a = new TimeSpan(12, 30, 30);
            //TimeSpan b = new TimeSpan(12, 34, 0);
            //Console.WriteLine(a.TotalMinutes);
            //Console.WriteLine(a.CompareTo(b));
            //Console.WriteLine("Moscow - Tula".Split(' ')[2]);
            //Application.Run(new Form1());
            //Console.ReadKey();
        }
    }
}
