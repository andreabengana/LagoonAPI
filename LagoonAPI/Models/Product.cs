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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Store_Product = new HashSet<Store_Product>();
        }
    
        public int ID_Product { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<System.DateTime> PreparationTime { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_Product> Store_Product { get; set; }
    }
}
