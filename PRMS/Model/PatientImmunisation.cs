using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class PatientImmunisation
    {
        public int PatientId { get; set; }
        public int VaccineId { get; set; }
        public DateTime VaccineDate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Vaccine Vaccine { get; set; }
    }
}
