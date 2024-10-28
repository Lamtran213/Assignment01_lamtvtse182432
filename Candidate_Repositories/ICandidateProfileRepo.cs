﻿using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface ICandidateProfileRepo
    {
        public List<CandidateProfile> GetCandidates();

        public CandidateProfile GetCandidateProfile(string id);

        public bool AddCandidateProfile(CandidateProfile candidateProfile);

        public bool DeleteCandidateProfile(string candidateProfileId);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);


    }
}