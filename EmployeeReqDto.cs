using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class EmployeeReqDto
    {
        [Required(ErrorMessage ="FLag is Required")]
        [StringLength(10,ErrorMessage ="flag cannot be longer than 10 characters.")]
        public string flag { get; set; }

        [Required(ErrorMessage = "EMp id is Required")]
        [RegularExpression(@"^[A-Za-z0-9]+$",ErrorMessage ="Emp id is must be alphanumeric")]
        [StringLength(20,ErrorMessage ="Emp id cannot be longer than 20 characters")]
         public string p1 { get; set; }

        [Required(ErrorMessage = "Ename is Required")]
        [StringLength(100,ErrorMessage ="Employee Name cannot be longer than 50 char")]
        public string p2 { get; set; }

        [Required(ErrorMessage = "DESIGNATION is Required")]
        [StringLength(50,ErrorMessage ="Designation cannot be longer than 50 char")]
        public string p3{ get; set; }

        [Required(ErrorMessage = "Department is Required")]
        [StringLength(50, ErrorMessage = "Designation cannot be longer than 50 char")]

        public string p4{ get; set; }

        //[EmailAddress(ErrorMessage ="Invalid Email Address")]
        //public string email { get; set; }

        //[Phone(ErrorMessage ="Invalid phone number format")]
        //public string phoneNumber { get; set; }

        //[Range(18,65,ErrorMessage ="Age must be btw 18 And 65")]
        //public int Age { get; set; }

    }
}
