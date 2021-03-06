﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Model
{
    public partial class Allergy
    {
        public int AllergyId { get; set; }
        public int PatientId { get; set; }
        public string Allergen { get; set; }
        public string ReactionType { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
