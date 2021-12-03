using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assaignment.Models
{   
    public class FindUser
    {
        public string Email { get; set; }
        public string New_Password { get; set; }
        public string Confirm_New_Password { get; set; }

    }
}
