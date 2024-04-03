using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Library.Data.Models
{
    [Table("ContactData")]
    [PrimaryKey(nameof(UserId), nameof(ContactId))]
    public class ContactDataModel
    {
        public long UserId { get; set; }
        public long ContactId { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
