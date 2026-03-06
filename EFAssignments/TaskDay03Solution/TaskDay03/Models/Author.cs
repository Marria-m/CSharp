using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay03.Models
{
    [Table("Writers")]
    internal class Author
    {
        // "Id" → Primary Key + Identity(1,1) (NOT NULL)
        public int Id { get; set; }


        [Required]  // (NOT NULL in DB)
        [MaxLength(100)]  // (nvarchar(100)
        public string Name { get; set; }
        public string? Country { get; set; }
    }
}
