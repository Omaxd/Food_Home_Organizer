using System;
using System.Collections.Generic;
using DataLayer.Interfaces;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public class InformationRepository : Repository<Information>, IInformationRepository
    {
        public InformationRepository(IList<Information> discountCodes) 
            : base(discountCodes)
        {
        }

        public Information GetRandomInformation()
        {
            Random random = new Random();
            int index = random.Next(database.Count);
            Information randomInformation = database[index];

            return randomInformation;
        }
    }
}