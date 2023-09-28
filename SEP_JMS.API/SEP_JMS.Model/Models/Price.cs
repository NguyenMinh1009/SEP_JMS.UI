﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SEP_JMS.Model.Models
{
    [Index(nameof(PriceGroupId), nameof(JobTypeId), IsUnique = true)]
    public class Price
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PriceId { get; set; }

        public Guid JobTypeId { get; set; }

        public int PriceGroupId { get; set; }

        public int UnitPrice { get; set; }

        public string? Description { get; set; } = null;
    }
}
