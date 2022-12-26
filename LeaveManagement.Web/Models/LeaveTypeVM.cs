using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    //this file will be used to project data on view
    public class LeaveTypeVM
    {
        public int ID { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name="Default Number of Days")]
        [Required]
        [Range(1,25,ErrorMessage ="Provide a valid value")  ]
      
        public int DefaultDays { get; set; }
    }
}
