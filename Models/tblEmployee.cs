using System.ComponentModel.DataAnnotations;

namespace SamuelCoreAdo.Models
{
    public class tblEmployee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }

        [Range(17, 100, ErrorMessage = "Age should be b/w 17 and 100")]
        public int Age { get; set; }
        public string Gender { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Please select a Country")]
        public string Country { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select a Country")]
        public string State { get; set; }
    }
}
