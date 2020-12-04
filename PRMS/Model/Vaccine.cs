using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Vaccine
    {
        public int VaccineId { get; set; }
        public int PatientId { get; set; }
        public string Vaccine1 { get; set; }
        public DateTime VaccineDate { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
