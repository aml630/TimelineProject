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
    
    public partial class Fact
    {
        public int FactId { get; set; }
        public string FactTitle { get; set; }
        public string FactText { get; set; }
        public System.DateTime DateTookPlace { get; set; }
        public System.DateTime DateAdded { get; set; }
        public string SourceArticleUrl { get; set; }
        public string SourceArticleTitle { get; set; }
        public int ApprovalStatus { get; set; }
        public int TimelineId { get; set; }
    
        public virtual Timeline Timeline { get; set; }
    }
}
