using Candidate_BusinessObjects;
using Candidate_DAOs;
using System.Collections.Generic;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {

        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);
        

        public bool DeleteCandidateProfile(string candidateProfileId) => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateProfileId);   
       

        public CandidateProfile GetCandidateProfile(string id) => CandidateProfileDAO.Instance.GetCandidateProfile(id);


        public List<CandidateProfile> GetCandidates() => CandidateProfileDAO.Instance.GetCandidates();



        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile); 

    }
}
