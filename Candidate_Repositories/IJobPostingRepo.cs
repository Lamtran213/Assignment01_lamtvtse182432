﻿using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting GetJobPostingByID(string id);
        public bool UpdateJobPosting(JobPosting jobPosting);
        public bool CreateJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(string id);
    }
}
