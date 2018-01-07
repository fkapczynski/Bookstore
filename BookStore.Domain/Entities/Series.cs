using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Series
    {
        public int SeriesId { get; set; }
        public int AuthorId { get; set; }
        public string SeriesTitle { get; set; }
    }
}
