using System;
using System.ComponentModel.DataAnnotations;

namespace dizajni_i_sistemit_softuerik.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}
