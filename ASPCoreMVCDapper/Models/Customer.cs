using System;
using System.ComponentModel.DataAnnotations;

namespace ASPCoreMVCDapper.Models
{
   public class Customer
   {
      public int CustomerID { get; set; }

      [Display(Name = "Company Name")]
      public string CompanyName { get; set; }

      [Display(Name = "Address")]
      public string Address { get; set; }

      [Display(Name = "City")]
      public string City { get; set; }

      [Display(Name = "State")]
      public string State { get; set; }

      [Display(Name = "Intro Date")]
      [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
      public DateTime IntroDate { get; set; }

      [Display(Name = "Credit Limit")]
      [DisplayFormat(DataFormatString = "{0:n2}")]
      public decimal CreditLimit { get; set; }
   }
}
