//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wsc2020Session1App
{
    using System;
    using System.Collections.Generic;
    
    public partial class DelegateFlight
    {
        public int id { get; set; }
        public int delegateId { get; set; }
        public int flightId { get; set; }
        public int classId { get; set; }
    
        public virtual Delegate Delegate { get; set; }
        public virtual FlightClass FlightClass { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
