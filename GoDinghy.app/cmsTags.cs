//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoDinghy.app
{
    using System;
    using System.Collections.Generic;
    
    public partial class cmsTags
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cmsTags()
        {
            this.cmsTagRelationship = new HashSet<cmsTagRelationship>();
            this.cmsTags1 = new HashSet<cmsTags>();
        }
    
        public int id { get; set; }
        public string tag { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string group { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cmsTagRelationship> cmsTagRelationship { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cmsTags> cmsTags1 { get; set; }
        public virtual cmsTags cmsTags2 { get; set; }
    }
}
