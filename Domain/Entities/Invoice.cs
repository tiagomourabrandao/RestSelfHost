using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Invoice
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Range(1, 12)]
        public int ReferenceMonth { get; set; }
        public int ReferenceYear { get; set; }
        public string Document { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeactiveAt { get; set; }

    }
}
