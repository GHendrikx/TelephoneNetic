/// <summary>
/// Timer system made by Geoffrey Hendrikx.
/// </summary>
namespace UnityEngine.Timers
{
    /// <summary>
    /// This class should only be created by the class TimerManager.
    /// Created by Geoffrey Hendrikx
    /// </summary>
    public class Timer
    {
        public delegate void ExecuteAfterTimer();
        public event ExecuteAfterTimer executeAfterTimerRunsOut;

        private float time;

        private bool stopTimer;
        public bool StopTimer
        {
            get
            {
                return stopTimer;
            }
            set
            {
                stopTimer = value;
            }
        }

        /// <summary>
        /// Should only be made by the TimerManager
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="time"></param>
        public Timer(ExecuteAfterTimer execute, float time)
        {
            this.executeAfterTimerRunsOut = execute;
            this.time = time;
        }


        /// <summary>
        /// Update the timer.
        /// </summary>
        public void UpdateTimer()
        {
            if (!stopTimer)
                time -= Time.deltaTime;

            if (time < 0)
                EndTimer();

        }

        /// <summary>
        /// Executing the delegate.
        /// </summary>
        public void EndTimer()
        {
            executeAfterTimerRunsOut.Invoke();
            TimerManager.Instance.RemoveTimer(this);
        }
    }
}