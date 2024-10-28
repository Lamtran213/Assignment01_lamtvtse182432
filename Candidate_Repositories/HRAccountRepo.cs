using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {
        Hraccount IHRAccountRepo.GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email);

        List<Hraccount> IHRAccountRepo.GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();
    }
}
