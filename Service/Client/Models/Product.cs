using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        public int Id
        {
            get;
            set;
        }
        [Display(Name = "Name")]
        public String Name
        {
            get;
            set;
        }
        [Display(Name = "Price")]
        public decimal Price
        {
            get;
            set;
        }
        [Display(Name = "Quantity")]
        public int Quantity
        {
            get;
            set;
        }
    }
}