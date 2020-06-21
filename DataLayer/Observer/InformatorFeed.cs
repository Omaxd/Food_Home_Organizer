using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Observer
{
    public class InformatorFeed : IObservable<InformationEvent>
    {
        private IList<IObserver<InformationEvent>> _observers;

        public InformatorFeed()
        {
            _observers = new List<IObserver<InformationEvent>>();
        }

        public IDisposable Subscribe(IObserver<InformationEvent> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            DisposeSubscription disposeSubscription = new DisposeSubscription(_observers, observer);

            return disposeSubscription;
        }

        public void PublishPromotion(InformationEvent information)
        {
            foreach (IObserver<InformationEvent> observer in _observers)
            {
                if (information == null)
                    observer.OnError(new ArgumentNullException());

                observer.OnNext(information);
            }
        }
        public void End()
        {
            foreach (IObserver<InformationEvent> observer in _observers.ToList())
                observer.OnCompleted();

            _observers.Clear();
        }
    }
}