using System;
using System.Collections.Generic;

namespace DataLayer.Observer
{
    class DisposeSubscription : IDisposable
    {
        private IList<IObserver<InformationEvent>> _observers;
        private IObserver<InformationEvent> _observer;

        private bool _disposed = false;

        public DisposeSubscription(IList<IObserver<InformationEvent>> observers, IObserver<InformationEvent> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing && _observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);

            _disposed = true;
        }
    }
}
