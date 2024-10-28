using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;

namespace Candidate_Services
{
    public interface IHRAccountService
    {
        Hraccount GetHRAccountByEmail(string email);
        List<Hraccount> GetHRAccounts();
    }
}
