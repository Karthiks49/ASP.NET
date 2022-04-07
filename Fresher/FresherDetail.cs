using System;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fresher
{
    public class FresherDetail
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("NAME")]
        [Required(ErrorMessage = "Please enter name")]
        [RegularExpression(@"^([a-zA-Z .]*)$", ErrorMessage = "Invalid name")]
        public string name { get; set; }

        [DisplayName("DATE OF BIRTH")]
        [Required(ErrorMessage = "Please enter date of birth")]
        [DataType(DataType.Date)]
        public string dateOfBirth { get; set; }

        [DisplayName("MOBILE NUMBER")]
        [Required(ErrorMessage = "Please enter mobile number")]
        [RegularExpression(@"^([6789]\d{9})$", ErrorMessage = "Invalid mobile number")]
        public long mobileNumber { get; set; }

        [DisplayName("ADDRESS")]
        [Required(ErrorMessage = "Please enter address")]
        public string address { get; set; }

        [DisplayName("QUALIFICATION")]
        [Required(ErrorMessage = "Please enter qualification")]
        public string qualification { get; set; }

        public FresherDetail(string name, string dateOfBirth, long mobileNumber, string address, string qualification)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.mobileNumber = mobileNumber;
            this.address = address;
            this.qualification = qualification;
        }

        public FresherDetail() { }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("\nId: ").Append(id).Append("\nName: ").Append(name)
                    .Append("\nDate of birth: ").Append(dateOfBirth)
                    .Append("\nMobile Number: ").Append(mobileNumber)
                    .Append("\nAddress: ").Append(address)
                    .Append("\nQualification: ").Append(qualification).Append("\n");

            return stringBuilder.ToString();
        }
    }
}
