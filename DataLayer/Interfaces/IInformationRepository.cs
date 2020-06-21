using DataLayer.Model;

namespace DataLayer.Interfaces
{
    public interface IInformationRepository : IRepository<Information>
    {
        Information GetRandomDiscountCode();
    }
}