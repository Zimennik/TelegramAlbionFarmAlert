//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelegramAlbionFarmAlert.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserSubscription
    {
        public int UserId { get; set; }
        public int TimerId { get; set; }
    
        public virtual Timer Timer { get; set; }
    }
}
