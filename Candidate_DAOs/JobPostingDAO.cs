using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
        private static CandidateManagementContext dbContext;
        private static JobPostingDAO instance;
        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        public JobPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public List<JobPosting> GetJobPostings()
        {
            return dbContext.JobPostings.ToList();
        }

        public JobPosting GetJobPostingByID(string id)
        {
            return dbContext.JobPostings.SingleOrDefault(m => m.PostingId.Equals(id));
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            if (!Regex.IsMatch(jobPosting.PostingId, @"^P\d{4}$"))
            {
                throw new ArgumentException("PostingId must have the format 'P' followed by 4 digits.");
            }
            var jobPostingToUpdate = GetJobPostingByID(jobPosting.PostingId);
            if (jobPostingToUpdate != null)
            {
                jobPostingToUpdate.JobPostingTitle = jobPosting.JobPostingTitle.Trim();
                jobPostingToUpdate.Description = jobPosting.Description;
                jobPostingToUpdate.PostedDate = jobPosting.PostedDate;

                return dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool CreateJobPosting(JobPosting jobPosting)
        {
            if (!Regex.IsMatch(jobPosting.PostingId, @"^P\d{4}$"))
            {
                throw new ArgumentException("PostingId must have the format 'P' followed by 4 digits.");
            }

            if (GetJobPostingByID(jobPosting.PostingId) == null)
            {
                dbContext.Set<JobPosting>().Add(jobPosting);
                return dbContext.SaveChanges() > 0;
            }

            return false; // JobPosting đã tồn tại
        }

        public bool DeleteJobPosting(string id)
        {
            var jobPostingDeleted = GetJobPostingByID(id);
            if(jobPostingDeleted != null)
            {
                dbContext.Set<JobPosting>().Remove(jobPostingDeleted);
                return dbContext.SaveChanges() > 0;
            }
            return false;
        }
    }
}
