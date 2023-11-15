using System.Collections.Generic;

namespace DefaultNamespace.Observers
{
    public class AudioGameObserver
    {
        private List<IObservable> Observables { get; set; }


        public void AddObserver(IObservable observable) =>
            Observables.Add(observable);

        public void RemoveObserver(IObservable observable) =>
            Observables.Add(observable);

        public void Notify()
        {
            foreach (IObservable observable in Observables)
                observable.Update();
        }
    }

    public interface IObservable
    {
        void Update();
    }
}