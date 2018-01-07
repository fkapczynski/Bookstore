using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SecondName))
                    return FirstName + " " + LastName;
                else
                    return FirstName + " " + SecondName + " " + LastName; 
            }
        }
    }
}
