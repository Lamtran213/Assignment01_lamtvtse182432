using Candidate_BusinessObjects;
using Candidate_Repositories;
using System.Collections.Generic;

namespace Candidate_Services
{
    public class HRAccountServices : IHRAccountService
    {
        private readonly IHRAccountRepo iAccountRepo;

        // Constructor for dependency injection
        public HRAccountServices()
        {
            iAccountRepo = new HRAccountRepo();
        }

        // Implementing the methods defined in the interface
        public List<Hraccount> GetHRAccounts()
        {
            return iAccountRepo.GetHraccounts();
        }

        public Hraccount GetHRAccountByEmail(string email)
        {
            return iAccountRepo.GetHraccountByEmail(email);
        }
    }
}
