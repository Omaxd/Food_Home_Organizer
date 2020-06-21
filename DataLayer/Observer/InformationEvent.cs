using DataLayer.Model;

namespace DataLayer.Observer
{
    public class InformationEvent
    {
        public InformationEvent(Information information)
        {
            Information = information;
        }

        public Information Information { get; private set; }
    }
}
