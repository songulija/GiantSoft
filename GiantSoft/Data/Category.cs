using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Data
{
    /// <summary>
    /// Each category will have ParentId of parent category 
    /// unless category is first then parentiD is null
    /// If its included you can get list of Products based on category
    /// we dont need to include this into migration. so we use VIRTUAL
    /// </summary>
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
