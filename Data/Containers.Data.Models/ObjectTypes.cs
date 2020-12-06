namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;
    public partial class ObjectTypes
    {
        public ObjectTypes()
        {
            Schedule = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
