//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DinamikFormYonetimi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Form
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Form()
        {
            this.Fields = new HashSet<Field>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.Guid createdBy { get; set; }
    
        public virtual aspnet_Users aspnet_Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Field> Fields { get; set; }
    }
}