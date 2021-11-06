namespace LibrarySystemV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [Display(Name = "Book Code")]
        [Required(ErrorMessage = "Book Code is Required")]
        [Key]
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        [Required(ErrorMessage ="Book Name is Required")]
        [StringLength(50)]
        public string BookName { get; set; }

        [Display(Name = "No Of Copies")]
        public int NoOfCopies { get; set; }

        [Display(Name = "Available Copies")]
        public int NoOfExistingCopies { get; set; }

        public virtual ICollection<Borrower> Borrowers { get; set; } = new HashSet<Borrower>();
    }
}
