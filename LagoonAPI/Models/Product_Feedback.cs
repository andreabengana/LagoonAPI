//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LagoonAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product_Feedback
    {
        public int ID_ProductFeedback { get; set; }
        public Nullable<int> ID_StoreProduct { get; set; }
        public string UserName { get; set; }
        public string ProductFeedback { get; set; }
    
        public virtual Store_Product Store_Product { get; set; }
    }
}
