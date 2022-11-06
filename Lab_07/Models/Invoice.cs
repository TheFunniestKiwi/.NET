using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab_07.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        public long InvoiceId { get; set; }
        public long CustomerId { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Date")]
        [UIHint("DateView")]
        public DateTime InvoiceDate { get; set; }
        [Display(Name = "Address")]
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingCountry { get; set; }
        public string? BillingPostalCode { get; set; }
        [DataType(DataType.Currency)]
        public decimal Total { get; set; } 

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
