using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Model;
using DataLayer.Observer;
using DataLayer.Repositories;
using InformationEvent = DataLayer.Observer.InformationEvent;

namespace LogicLayer.Classes
{
    public class InformationPublisher : IDisposable
    {
        private readonly IInformationRepository _informationRepository;
        private IDisposable _subscription;
        private readonly InformatorFeed _informationFeed;

        public TimeSpan Period { get; }

        public InformationPublisher(TimeSpan period)
        {
            _informationRepository = new InformationRepository(DataStore.Instance.State.Informations);
            _informationFeed = new InformatorFeed();
            Period = period;
        }

        public void Start()
        {
            IObservable<long> timerObservable = Observable.Interval(Period);
            _subscription = timerObservable.ObserveOn(Scheduler.Default).Subscribe(RaiseTick);
        }

        public void Subscribe(IObserver<InformationEvent> observer)
        {
            _informationFeed.Subscribe(observer);
        }

        public void End()
        {
            _informationFeed.End();
        }

        private  void RaiseTick(long counter)
        {
            Information discountCode = _informationRepository.GetRandomDiscountCode();
            InformationEvent promotion = new InformationEvent(discountCode);
            _informationFeed.PublishPromotion(promotion);
        }

        public void Dispose()
        {
            _subscription?.Dispose();
        }

    }
}