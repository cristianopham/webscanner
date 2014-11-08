using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulScanner
{
    public class StopWatch
    {
        private DateTime startTime;
        private DateTime stopTime;
        private DateTime currentTime;
        private bool running = false;


        public void Start()
        {
            this.startTime = DateTime.Now;
            this.running = true;
        }


        public void Stop()
        {
            this.stopTime = DateTime.Now;
            this.running = false;
        }


        // elaspsed time in milliseconds
        public string GetElapsedTimeString()
        {
            TimeSpan interval;

            if (!running)
                return ""; //interval = DateTime.Now - startTime;
            else
            {
                this.currentTime = DateTime.Now;
                interval = currentTime - startTime;
            }

            int days = interval.Days;
            double hours = interval.Hours;
            double mins = interval.Minutes;
            double secs = interval.Seconds;
            string x = "";
            if (days != 0)
            {
                x += days.ToString() + ":";
            }
            if (hours != 0)
            {
                x += hours.ToString("00") + ":";
            }
            x += mins.ToString("00") + ":";
            x += secs.ToString("00");

            return x;
        }
        public double GetElapsedMilliseconds()
        {
            TimeSpan interval;

            if (running)
                interval = DateTime.Now - startTime;
            else
                interval = stopTime - startTime;

            return interval.TotalMilliseconds;
        }


        // elaspsed time in seconds
        public double GetElapsedTimeSecs()
        {
            TimeSpan interval;

            if (running)
                interval = DateTime.Now - startTime;
            else
                interval = stopTime - startTime;

            return interval.TotalSeconds;
        }
    }
}
