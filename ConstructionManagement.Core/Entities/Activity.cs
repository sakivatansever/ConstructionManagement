using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Core.Entities
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }                      
        [Required]
        public string ActivityType { get; set; }          
        public DateTime Date { get; set; }               
        public string Description { get; set; }            
        public int WorkerId { get; set; }               

        public Worker Worker { get; set; }               
    }
}
