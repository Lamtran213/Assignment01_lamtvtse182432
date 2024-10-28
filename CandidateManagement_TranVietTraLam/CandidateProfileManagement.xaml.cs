using Candidate_BusinessObjects;
using Candidate_Service;
using Candidate_Services;
using System.Windows;
using System.Windows.Controls;

namespace CandidateManagement_TranVietTraLam
{
    /// <summary>
    /// Interaction logic for CandidateProfileManagement.xaml
    /// </summary>
    public partial class CandidateProfileManagement : Window
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobPostingService;
        private readonly int? roleID;
        public CandidateProfileManagement(int? roleID)
        {
            InitializeComponent();
            profileService = new CandidateProfileService();
            jobPostingService = new JobPostingService();
            this.roleID = roleID;
        }

        public void LoadProductList()
        {
            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidates().Select(a=> new {a.CandidateId, a.Fullname, a.Posting.JobPostingTitle });
            this.cmbPostId.ItemsSource = jobPostingService.GetJobPostings();
            this.cmbPostId.DisplayMemberPath = "JobPostingTitle";
            this.cmbPostId.SelectedValuePath = "PostingId";
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtID.Text.Length > 0)
                {
                    string candidateId = txtID.Text;
                    bool isDeleted = profileService.DeleteCandidateProfile(candidateId);

                    if (isDeleted)
                    {
                        MessageBox.Show("Candidate profile deleted successfully.");
                        this.LoadProductList();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete candidate profile.");
                    }
                }
                else
                {
                    MessageBox.Show("You must select a candidate.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CandidateProfile candidateProfile = new CandidateProfile();
                candidateProfile.CandidateId = txtID.Text;
                candidateProfile.Fullname = txtName.Text;
                candidateProfile.ProfileUrl = txtImageURL.Text;
                candidateProfile.Birthday = txtBirthday.SelectedDate;
                candidateProfile.PostingId = cmbPostId.SelectedValue.ToString();
                candidateProfile.ProfileShortDescription = txtDescription.Text;
                bool isAdded = profileService.AddCandidateProfile(candidateProfile);
                if (isAdded == true)
                {
                    MessageBox.Show("Add candidate profile successfully.");
                    this.LoadProductList();
                }
                else
                {
                    MessageBox.Show("Add fail.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtID.Text.Length > 0)
                {
                    CandidateProfile candidateProfile = new CandidateProfile();
                    candidateProfile.CandidateId = txtID.Text;
                    candidateProfile.Fullname = txtName.Text;
                    candidateProfile.ProfileUrl = txtImageURL.Text;
                    candidateProfile.Birthday = txtBirthday.SelectedDate;

                    if (cmbPostId.SelectedValue != null)
                    {
                        candidateProfile.PostingId = cmbPostId.SelectedValue.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Please select a Posting ID.");
                        return;
                    }

                    candidateProfile.ProfileShortDescription = txtDescription.Text;
                    profileService.UpdateCandidateProfile(candidateProfile);
                    if (profileService.UpdateCandidateProfile(candidateProfile) == true)
                    {
                        MessageBox.Show("Update candidate information successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Fail to update for some reason!!!");
                    }
                }
                else
                {
                    MessageBox.Show("You must select a candidate.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (roleID)
            {
                case 1:
                    break;
                case 2:
                    //Staff
                    this.btn_Add.IsEnabled = false;
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            this.LoadProductList();
        }

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn =
                (DataGridCell)dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)RowColumn.Content).Text;
            CandidateProfile candidateProfile = profileService.GetCandidateProfile(id);
            txtID.Text = candidateProfile.CandidateId;
            txtName.Text = candidateProfile.Fullname;
            txtImageURL.Text = candidateProfile.ProfileUrl;
            txtBirthday.Text = candidateProfile.Birthday.ToString();
            cmbPostId.SelectedValue = candidateProfile.PostingId;
            txtDescription.Text = candidateProfile.ProfileShortDescription;
        }

        private void btnCandidate_Click(object sender, RoutedEventArgs e)
        {
            this.Activate();
        }

        private void btnJobPosting_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow(jobPostingService);
            this.Close();
            jobPostingWindow.ShowDialog();
        }
    }
}
