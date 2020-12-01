using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Patient
    {
        public Patient()
        {
            InverseGp = new HashSet<Patient>();
            PatientMedications = new HashSet<PatientMedication>();
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

        public virtual Patient Gp { get; set; }
        public virtual ICollection<Patient> InverseGp { get; set; }
        public virtual ICollection<PatientMedication> PatientMedications { get; set; }
    }
}
