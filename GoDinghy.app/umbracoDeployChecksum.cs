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
    
    public partial class umbracoDeployChecksum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public umbracoDeployChecksum()
        {
            this.umbracoDeployDependency = new HashSet<umbracoDeployDependency>();
            this.umbracoDeployDependency1 = new HashSet<umbracoDeployDependency>();
        }
    
        public int id { get; set; }
        public string entityType { get; set; }
        public Nullable<System.Guid> entityGuid { get; set; }
        public string entityPath { get; set; }
        public string localChecksum { get; set; }
        public string compositeChecksum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<umbracoDeployDependency> umbracoDeployDependency { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<umbracoDeployDependency> umbracoDeployDependency1 { get; set; }
    }
}