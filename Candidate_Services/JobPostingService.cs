
using Candidate_BusinessObjects;
using Candidate_Repositories;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class JobPostingService : IJobPostingService
    {

        private readonly IJobPostingRepo jobPostingRepo;
        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }
        public List<JobPosting> GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }
        public JobPosting GetJobPostingByID(string id)
        {
            return jobPostingRepo.GetJobPostingByID(id);
        }
    }
}