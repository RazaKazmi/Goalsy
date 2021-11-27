using System;
using System.Threading.Tasks;
using System.Timers;
using Serilog;

namespace Goalsy.Components
{
    class CountdownTimer : ITimer
    {
        private Timer _timer;
        private DateTime _startTime;
        private DateTime _endTime;
        private TimeSpan _initialTimeSet;
        private TimeSpan _timeRemaining;

        private int _hours;
        private int _minutes;
        private int _seconds;

        private const int MaxHours = 24;
        private const int MaxMinutes = 60;
        private const int MaxSeconds = 60;

        public CountdownTimer(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            _initialTimeSet = new TimeSpan(hours, minutes, seconds);
            _timeRemaining = new TimeSpan(hours, minutes, seconds);

            _timer = new Timer(1000);
            _timer.Elapsed += OnTimeEvent;
            _timer.Enabled = true;
        }

        public string Name 
        {   
            get => "CountdownTimer";
        }

        public int Hours
        {
            get { return _hours; }
            set
            {
                if (value < 0 || value >= MaxHours)
                    throw new ArgumentOutOfRangeException("Hours");
                _hours = value;
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value < 0 || value >= MaxMinutes)
                    throw new ArgumentOutOfRangeException("Minutes");
                _minutes = value;
            }
        }

        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (value < 0 || value >= MaxSeconds)
                    throw new ArgumentOutOfRangeException("Seconds");
                _seconds = value;
            }
        }

        public void Pause()
        {
            _timeRemaining = new TimeSpan(Hours,Minutes,Seconds);
            _startTime = DateTime.MinValue;
            _endTime = DateTime.MinValue;
            _timer.Stop();
        }

        // TO DO: Reset timer back to original inputted time.
        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            _startTime = DateTime.UtcNow;
            _endTime = _startTime.Add(_timeRemaining);
            _timer.Start();
        }

        // Returns the current timer in the format {hh:mm:ss}.
        string ToStringTimer()
        {
            return _timeRemaining.ToString(@"hh\:mm\:ss");
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            if (_timeRemaining <= TimeSpan.Zero)
            {
                _timer.Stop();
            }
            else
            {
                int totalSeconds = (Hours * 60 * 60) + (Minutes * 60) + Seconds;
                totalSeconds--;
                _timeRemaining = TimeSpan.FromSeconds(totalSeconds);
                Hours = _timeRemaining.Hours;
                Minutes = _timeRemaining.Minutes;
                Seconds = _timeRemaining.Seconds;
                Console.WriteLine(this.ToStringTimer());
            }
        }
    }
}
