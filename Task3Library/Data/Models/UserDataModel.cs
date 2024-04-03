using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Library.Data.Models
{
    [Table("UserData")]
    public class UserDataModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(32)]
        public string Password { get; set; }

        [MaxLength(10)]
        public string State { get; set; }
    }
}
