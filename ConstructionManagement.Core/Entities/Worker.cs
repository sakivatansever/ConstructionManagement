using ConstructionManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Core.Entities
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }              
        [Required]
        public string Name { get; set; }         
        public Role Role { get; set; }        
        [EmailAddress]
        public string Email { get; set; }      
        [Phone]
        public string PhoneNumber { get; set; }      

        public virtual ICollection<Activity> Activities { get; set; } 

    }
}
