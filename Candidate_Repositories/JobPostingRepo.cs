using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings() => JobPostingDAO.Instance.GetJobPostings();
        public JobPosting GetJobPostingByID(string id) => JobPostingDAO.Instance.GetJobPostingByID(id);
    }
}
