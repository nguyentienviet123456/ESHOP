using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class Register: BaseEntity
    {
        public string FullName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}
