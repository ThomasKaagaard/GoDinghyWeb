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
    
    public partial class cmsTask
    {
        public bool closed { get; set; }
        public int id { get; set; }
        public int taskTypeId { get; set; }
        public int nodeId { get; set; }
        public int parentUserId { get; set; }
        public int userId { get; set; }
        public System.DateTime DateTime { get; set; }
        public string Comment { get; set; }
    
        public virtual cmsTaskType cmsTaskType { get; set; }
        public virtual umbracoNode umbracoNode { get; set; }
        public virtual umbracoUser umbracoUser { get; set; }
        public virtual umbracoUser umbracoUser1 { get; set; }
    }
}
