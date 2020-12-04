using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Medication
    {
        public int MedicationId { get; set; }
        public int PatientId { get; set; }
        public string MedicationName { get; set; }
        public string Frequency { get; set; }
        public string Dosage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
