namespace LibrarySystemV1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Borrower
    {
        [Required]
        [Key]
        [Display(Name="Borrower Code")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BorrowerId { get; set; }

        [Display(Name = "Borrower Name")]
        [Required(ErrorMessage = "Borrower Name is Required")]
        [StringLength(50)]
        public string BorrowerName { get; set; }

        [Display(Name = "Book Code")]
        public int BookId { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
        
    }
}
