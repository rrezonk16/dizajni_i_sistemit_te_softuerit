using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
        public DateTime CreatedAt { get; set; }
    }
}
