﻿using Microsoft.AspNetCore.Mvc;

namespace dizajni_i_sistemit_softuerik.Entities
{
    public class Order : BaseEntity
    {
        public int ClientId { get; set;}
        public decimal TotalAmount { get; set; }
        public Client Client { get; set; }
    }
}
