using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Medication
    {
        public Medication()
        {
            PatientMedications = new HashSet<PatientMedication>();
        }

        public int MedicationId { get; set; }
        public string MedicationName { get; set; }

        public virtual ICollection<PatientMedication> PatientMedications { get; set; }
    }
}
