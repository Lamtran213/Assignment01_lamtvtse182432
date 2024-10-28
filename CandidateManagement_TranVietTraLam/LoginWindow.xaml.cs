using Candidate_BusinessObjects;
using Candidate_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_TranVietTraLam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountService iAccountService;
        public LoginWindow()
        {
            InitializeComponent();
            iAccountService = new HRAccountServices();
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iAccountService.GetHRAccountByEmail(txtEmail.Text.Trim());

            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password))
            {
                int? roleID = hraccount.MemberRole;
                switch (roleID)
                {
                    case 1:
                        this.Hide();
                        CandidateProfileManagement candForm = new CandidateProfileManagement(roleID);
                        candForm.Show();
                        break;
                    case 2:
                        this.Hide();
                        CandidateProfileManagement staffCandidate = new CandidateProfileManagement(roleID);
                        staffCandidate.Show();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }     

            }
            else
            {
                MessageBox.Show("Bye bye!");
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

