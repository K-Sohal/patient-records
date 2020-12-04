using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Patient
    {
        public Patient()
        {
            Allergies = new HashSet<Allergy>();
            Concerns = new HashSet<Concern>();
            Medications = new HashSet<Medication>();
            Vaccines = new HashSet<Vaccine>();
        }

        public int PatientId { get; set; }
        public int Gpid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string ContactNumber { get; set; }

        public virtual Gp Gp { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
        public virtual ICollection<Concern> Concerns { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
        public virtual ICollection<Vaccine> Vaccines { get; set; }
    }
}
