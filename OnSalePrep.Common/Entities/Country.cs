using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Common.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "Country")]
        public string Name { get; set; }

        public ICollection<Department> Departments { get; set; }

        [DisplayName("Departments Number")]
        public int DepartmentsNumber => Departments == null ? 0 : Departments.Count;
    }
}
