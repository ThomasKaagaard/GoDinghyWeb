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
    
    public partial class cmsDataType
    {
        public int pk { get; set; }
        public int nodeId { get; set; }
        public string propertyEditorAlias { get; set; }
        public string dbType { get; set; }
    
        public virtual umbracoNode umbracoNode { get; set; }
    }
}
