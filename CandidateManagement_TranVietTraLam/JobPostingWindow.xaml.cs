using Candidate_BusinessObjects;
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
            LoadJobPostingList(); // Load data into DataGrid
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

        private void dtgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow dataGridRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell cell = (DataGridCell)dataGrid.Columns[0].GetCellContent(dataGridRow).Parent as DataGridCell;
            string id = ((TextBlock)cell.Content).Text;
            JobPosting jobPosting = jobPostingService.GetJobPostingByID(id);
            txtPostID.Text = jobPosting.PostingId;
            txtJobPostingTitle.Text = jobPosting.JobPostingTitle;
            txtDescription.Text = jobPosting.Description;
            dpPostedDate.Text = jobPosting.PostedDate.ToString();
        }
        public void LoadJobPostingList()
        {
            this.dtgJobPosting.ItemsSource = jobPostingService.GetJobPostings().Select(a => new { a.PostingId, a.JobPostingTitle, a.Description, a.PostedDate });
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JobPosting jobPosting = new JobPosting();
                jobPosting.PostingId = txtPostID.Text;
                jobPosting.JobPostingTitle = txtJobPostingTitle.Text;
                jobPosting.Description = txtDescription.Text;
                jobPosting.PostedDate = dpPostedDate.SelectedDate;
                bool isAdded = jobPostingService.CreateJobPosting(jobPosting);
                if (isAdded)
                {
                    MessageBox.Show("Add job posting successfully.");
                    this.LoadJobPostingList();
                }
                else
                {
                    MessageBox.Show("Add fail!");
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Cannot add for some reason!");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPostID.Text.Length > 0)
                {
                    string id = txtPostID.Text;
                    bool isDelete = jobPostingService.DeleteJobPosting(id);
                    if (isDelete)
                    {
                        MessageBox.Show("Delete job posting successfully.");
                        this.LoadJobPostingList();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete job posting for some reason!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete for some reason!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtPostID.Text.Length > 0)
                {
                    string id = txtPostID.Text;
                    JobPosting jobPosting = new JobPosting();
                    jobPosting.PostingId = txtPostID.Text;
                    jobPosting.JobPostingTitle = txtJobPostingTitle.Text;
                    jobPosting.PostedDate = dpPostedDate.SelectedDate;
                    if(jobPostingService.UpdateJobPosting(jobPosting) == true)
                    {
                        MessageBox.Show("Update job posting successfully.");
                        this.LoadJobPostingList();
                    }
                    else
                    {
                        MessageBox.Show("Cannot update job posting for some reason!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update job posting for some reason!");
            }
        }
    }
}
