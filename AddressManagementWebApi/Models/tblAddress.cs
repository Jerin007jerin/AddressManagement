//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddressManagementWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAddress
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Familyname { get; set; }
        public DateTime DOB { get; set; }
        public string DOBStr
        {
            get
            {
                return DOB.ToString("yyyy/MM/dd");
                
            }
        }

        public string Street { get; set; }
        public Nullable<int> Pincode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Nullable<decimal> phone { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
    }
}
