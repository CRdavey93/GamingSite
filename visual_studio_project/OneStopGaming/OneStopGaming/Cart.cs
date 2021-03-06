//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OneStopGaming
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cart()
        {
            this.CartsProducts = new HashSet<CartsProduct>();
            this.CartsPromotions = new HashSet<CartsPromotion>();
        }
    
        public int ID { get; set; }
        public string Status { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int UserID { get; set; }
        public Nullable<int> Zip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartsProduct> CartsProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartsPromotion> CartsPromotions { get; set; }
        public virtual User User { get; set; }
    }
}
