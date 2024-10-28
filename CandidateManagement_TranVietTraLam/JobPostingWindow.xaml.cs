using Candidate_Repositories;
using Candidate_Service;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_TranVietTraLam
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private int? roleID;
        private readonly IJobPostingService jobPostingService;
        public JobPostingWindow(IJobPostingService jobPostingService)
        {
            this.jobPostingService = jobPostingService;
            InitializeComponent();
        }

        private void btnJobPosting_Click(object sender, RoutedEventArgs e)
        {
            this.Activate();
        }

        private void btnCandidate_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfileManagement candidateProfileManagement = new CandidateProfileManagement(roleID);
            this.Close();
            candidateProfileManagement.ShowDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }
    }
}
