﻿using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Entities
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
