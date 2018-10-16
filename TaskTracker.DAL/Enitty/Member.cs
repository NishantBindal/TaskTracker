using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTracker.DAL.Abstract;

namespace TaskTracker.DAL.Entity
{
    public class Member : BaseEntity
    {
        [Key]
        public new Guid ID { get; set; }
        public string EmailAddress { get; set; }
        public Board Board { get; set; }
    }
}
