//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeLineBlog
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resource
    {
        public int ResourceId { get; set; }
        public string ResourceTitle { get; set; }
        public string ResourceUrl { get; set; }
        public System.DateTime DatePublished { get; set; }
        public System.DateTime DateAdded { get; set; }
        public int ResourceType { get; set; }
        public int TimelineId { get; set; }
        public int ApprovalStatus { get; set; }
        public Nullable<int> FeedId { get; set; }
        public string FactText { get; set; }
    
        public virtual RSSFeed RSSFeed { get; set; }
        public virtual Timeline Timeline { get; set; }
    }
}
