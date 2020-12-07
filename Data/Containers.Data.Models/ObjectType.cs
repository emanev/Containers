namespace Containers.Data.Models
{
    using System.Collections.Generic;

    public partial class ObjectType
    {
        public ObjectType()
        {
            this.Schedule = new HashSet<Schedule>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
