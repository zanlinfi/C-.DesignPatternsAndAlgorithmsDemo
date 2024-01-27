using ObservePattern.Observers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservePattern.EventObjects
{
    internal class Weather
    {
        private List<IObserver> _observers = new(); 
        /// <summary>
        /// 被观察者对象，观察这根据其状态得到通知，改变行为
        /// </summary>
        public void RainEvent()
        {
            Console.WriteLine("天要下雨了！");
            foreach (var observe in _observers)
            {
                observe.Action();
            }
        }

        public void AddOberve(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveOberve(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public event Action WeatherEvent;
        public void RainEvent2()
        {
            Console.WriteLine("天要下雨了！");
            if (WeatherEvent is not null)
            {
                WeatherEvent.Invoke();
            }
        }
    }
}
