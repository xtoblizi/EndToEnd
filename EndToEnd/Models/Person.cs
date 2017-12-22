using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web;

namespace EndToEnd.Models
{
    public abstract class Person
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public DropDown.Gender GenderList { get; set; }

        public string Gender { get; set; }

        public int? Age { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

            [NotMapped]
            public DropDown.State StateList { get; set; }
            public string State { get; set; }

        public string Country { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string FullName
        {


            get
            {
                if (MiddleName == null)
                {
                    return (FirstName + "" + LastName);
                }

                return (FirstName + "" + MiddleName + "" + LastName);
            }
            set { }
        }

        public byte[] Passport { get; set; }

        [NotMapped]
        [DataType(DataType.ImageUrl)]
        [ValidateFile(ErrorMessage = "Please select an image of Jpeg or Png format")]
        public HttpPostedFileBase File
        {
            get
            {

                return null;
            }

            set
            {
                try
                {
                    var target = new MemoryStream();
                    if (value.InputStream == null)
                        return;
                    value.InputStream.CopyTo(target);
                    Passport = target.ToArray();
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }
            }
        }

    }
}