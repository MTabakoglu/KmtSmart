using System;
using System.Timers;

namespace KmtSmart.Services
{
    public class BlazorTimer:IDisposable
    {
        private Timer _timer = new Timer();
        public BlazorTimer()
        {
            //_timer = new Timer();
            _timer.Enabled = false;
        }

        public void SetTimer(double interval)
        {
            //if (_timer == null) _timer = new Timer();
            if (isDispose)
            {
                _timer = new Timer();
                isDispose = false;
            }
            _timer.Interval =interval;
            _timer.Elapsed += NotifyTimerElapsed;
            _timer.Enabled = true;
        }

        public event Action OnElapsed;
        private bool isDispose = false;
        private void NotifyTimerElapsed(Object source, ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            OnElapsed?.Invoke();
            _timer.Enabled = true;
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer.Elapsed -= NotifyTimerElapsed;
            _timer.Enabled = false;
            _timer.Dispose();
            isDispose = true;
        }
    }
}