using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Concern
    {
        public int ConcernId { get; set; }
        public int PatientId { get; set; }
        public string Concern1 { get; set; }
        public DateTime? ConcernDate { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
