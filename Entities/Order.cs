using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Order : BaseEntity
    {
        public int ClientId { get; set;}    

    }
}
