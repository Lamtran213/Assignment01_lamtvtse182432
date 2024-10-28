using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface ICandidateProfileService
    {
        public List<CandidateProfile> GetCandidates();


        public CandidateProfile GetCandidateProfile(string id);



        public bool AddCandidateProfile(CandidateProfile candidateProfile);


        public bool DeleteCandidateProfile(string candidateProfileId);



        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
