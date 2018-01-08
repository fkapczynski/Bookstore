using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Opinion
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int opinionId { get; set; }
        public String opinionTitle { get; set; }
        public String opinionContent { get; set; }
        public String feedbackEmail { get; set; }
        public bool recommended { get; set; }
        public int bookId { get; set; }
    }
}
