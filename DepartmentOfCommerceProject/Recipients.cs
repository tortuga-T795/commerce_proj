//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DepartmentOfCommerceProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipients
    {
        public int id { get; set; }
        public string recipientName { get; set; }
        public int legalAddressId { get; set; }
        public string uniquePayerNumber { get; set; }
        public int legalEntityTypeId { get; set; }
        public int phoneNumber { get; set; }
    
        public virtual Addresses Addresses { get; set; }
        public virtual LegalEntityTypes LegalEntityTypes { get; set; }
    }
}
