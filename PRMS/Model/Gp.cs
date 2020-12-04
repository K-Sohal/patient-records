using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Gp
    {
        public Gp()
        {
            Patients = new HashSet<Patient>();
        }

        public int Gpid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
