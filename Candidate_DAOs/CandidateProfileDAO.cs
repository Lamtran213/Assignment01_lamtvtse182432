﻿using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO
    {
        private static CandidateProfileDAO instance;
        private static CandidateManagementContext dbContext;

        private CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public static CandidateProfileDAO Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        public List<CandidateProfile> GetCandidates()
        {
            return dbContext.Set<CandidateProfile>()
                            .Include(u => u.Posting)
                            .ToList();
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return dbContext.Set<CandidateProfile>()
                            .SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            if (!Regex.IsMatch(candidateProfile.CandidateId, @"^CANDIDATE\d{4}$"))
            {
                throw new ArgumentException("CandidateID must have the format 'CANDIDATE' followed by 4 digits.");
            }

            if (GetCandidateProfile(candidateProfile.CandidateId) == null)
            {
                dbContext.Set<CandidateProfile>().Add(candidateProfile);
                return dbContext.SaveChanges() > 0;
            }

            return false;
        }

        public bool DeleteCandidateProfile(string candidateProfileId)
        {
            var candidate = GetCandidateProfile(candidateProfileId);
            if (candidate != null)
            {
                dbContext.Set<CandidateProfile>().Remove(candidate);
                return dbContext.SaveChanges() > 0;
            }
            return false; 
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            if (!Regex.IsMatch(candidateProfile.CandidateId, @"^CANDIDATE\d{4}$"))
            {
                throw new ArgumentException("CandidateID must have the format 'CANDIDATE' followed by 4 digits.");
            }
            var candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate != null)
            {
                candidate.Fullname = candidateProfile.Fullname;
                candidate.ProfileUrl = candidateProfile.ProfileUrl;
                candidate.Birthday = candidateProfile.Birthday;
                candidate.PostingId = candidateProfile.PostingId;
                candidate.ProfileShortDescription = candidateProfile.ProfileShortDescription;

                return dbContext.SaveChanges() > 0;
            }
            return false; 
        }
    }
}
