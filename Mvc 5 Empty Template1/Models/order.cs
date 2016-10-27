using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_5_Empty_Template1.Models
{
    public class order
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string userEmail { get; set; }
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime deliveredDate { get; set; }
        public int countPZ { get; set; }
    }
}