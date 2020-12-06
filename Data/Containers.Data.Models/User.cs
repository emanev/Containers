//using System;
//using System.Collections.Generic;

//namespace ContainersCRM.Models
//{
//    public partial class User
//    {
//        public User()
//        {
//            Movement = new HashSet<Movement>();
//            SrsobjectIndustrial = new HashSet<SrsobjectIndustrial>();
//            SrsobjectIndustrialContainer = new HashSet<SrsobjectIndustrialContainer>();
//            SrsobjectIndustrialSchema = new HashSet<SrsobjectIndustrialSchema>();
//            Warehouse = new HashSet<Warehouse>();
//        }

//        public int Id { get; set; }
//        public int RoleId { get; set; }
//        public string Username { get; set; }
//        public string Email { get; set; }
//        public string Password { get; set; }

//        public virtual Roles Role { get; set; }
//        public virtual ICollection<Movement> Movement { get; set; }
//        public virtual ICollection<SrsobjectIndustrial> SrsobjectIndustrial { get; set; }
//        public virtual ICollection<SrsobjectIndustrialContainer> SrsobjectIndustrialContainer { get; set; }
//        public virtual ICollection<SrsobjectIndustrialSchema> SrsobjectIndustrialSchema { get; set; }
//        public virtual ICollection<Warehouse> Warehouse { get; set; }
//    }
//}
