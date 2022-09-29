﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedprDB.Entities
{
    public class Prescription : IBaseEntity
    {
        public Guid Id { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime EndDate { get; set; }

        public int Dose { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid DrugId { get; set; }
        public Drug Drug { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
