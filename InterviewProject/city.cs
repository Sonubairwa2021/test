//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterviewProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class city
    {
        public int id { get; set; }
        public int sid { get; set; }
        public string city1 { get; set; }
    
        public virtual state state { get; set; }
    }
}
