using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fresher;
using DataAccess;

namespace FreshersInfo
{
    public partial class CreateFresher : Form
    {
        private readonly Freshermanagement fresherManagement = new Freshermanagement();
        private string name;
        private DateTime dateOfBirth;
        private long mobileNumber;
        private string address;
        private string qualification;

        public CreateFresher()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            int affectedRow;
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                name = nameContainer.Text;
                dateOfBirth = dateOfBirthContainer.Value;
                mobileNumber = long.Parse(mobileNumberContainer.Text);
                address = addressContainer.Text;
                qualification = course.Text;

                var fresher = new FresherDetail(name, dateOfBirth.ToString("yyyy/MM/dd"), 
                                                mobileNumber, address, qualification);
                fresher.id = 0;    
                
                if (idContainer.Text == "")
                {
                    if (1 == (affectedRow = fresherManagement.SaveFreshers(fresher)))
                    {
                        MessageBox.Show($"{name} added successfully !!!");
                        MessageBox.Show("New fresher id: " + fresher.id.ToString());
                        Clear();
                    } else
                    {
                        MessageBox.Show("Mobile number already exist");
                        mobileNumberContainer.Clear();
                    }
                } else
                {
                    fresher.id = int.Parse(idContainer.Text);
                    if (1 == (affectedRow = fresherManagement.SaveFreshers(fresher)))
                    {
                        MessageBox.Show($"{name} updated successfully !!!");
                        Clear();
                    } else
                    {
                        MessageBox.Show("Mobile number already exist");
                        mobileNumberContainer.Clear();
                    }
                }
            }
        }

        public void Clear()
        {
            nameContainer.Clear();
            dateOfBirthContainer.Text = "";
            mobileNumberContainer.Clear();
            addressContainer.Clear();
            course.Text = "";
            idContainer.Clear();
        }

        public void DeleteFresher(int id, string name)
        {
            fresherManagement.DeleteFresher(id);
            MessageBox.Show($"{name} deleted successfully !!!");
        }

        public void GetValues(FresherDetail fresher)
        {
            nameContainer.Text = fresher.name;
            dateOfBirthContainer.Text = fresher.dateOfBirth;
            mobileNumberContainer.Text = fresher.mobileNumber.ToString();
            addressContainer.Text = fresher.address;
            course.Text = fresher.qualification;
            idContainer.Text = fresher.id.ToString();
        }

        private void nameContainer_Validating(object sender, CancelEventArgs e)
        {
            string stringRegex = @"^([a-zA-Z .]*)$";
            Regex regex = new Regex(stringRegex);
            string name = nameContainer.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                e.Cancel = true;
                nameContainer.Focus();
                errorProvider1.SetError(nameContainer, "Name should not be left blank");

            } else if (!regex.IsMatch(name))
            {
                e.Cancel = true;
                nameContainer.Focus();
                errorProvider1.SetError(nameContainer, "Name should contain only alphabets");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(nameContainer, "");
            }
        }

        private void dateOfBirthContainer_Validating(object sender, CancelEventArgs e)
        {
            dateOfBirth = dateOfBirthContainer.Value;
            int age = GetAge(dateOfBirth);
            if (age >= 18)
            {
                e.Cancel = false;
                errorProvider1.SetError(dateOfBirthContainer, "");
            } else
            {
                e.Cancel = true;
                dateOfBirthContainer.Focus();
                errorProvider1.SetError(dateOfBirthContainer, $"Age should be above 18, Your age is {age}");               
            }
        }

        private int GetAge(DateTime date)
        {
            DateTime currentDate = DateTime.Today;
            int currentYear = currentDate.Year;
            int age = (currentYear - date.Year);
               
            return age;
        }

        private void CreateFresher_Load(object sender, EventArgs e)
        {
            ActiveControl = nameContainer;
        }

        private void mobileNumberContainer_Validating(object sender, CancelEventArgs e)
        {
            string stringRegex = @"^([6789]\d{9})$";
            var regex = new Regex(stringRegex);
            string mobileNumber = mobileNumberContainer.Text;
            if (regex.IsMatch(mobileNumber))
            {
                e.Cancel = false;
                errorProvider1.SetError(mobileNumberContainer, "");
            } else
            {
                e.Cancel = true;
                mobileNumberContainer.Focus();
                errorProvider1.SetError(mobileNumberContainer, "Enter valid mobile number");
            }
        }
    }
}
