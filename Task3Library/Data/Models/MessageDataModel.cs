using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Library.Data.Models
{
    [Table("MessageData")]
    public class MessageDataModel
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }
        public long ContactId { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
