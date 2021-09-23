using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class Entity : ValidatableObject
    {
        protected Entity() { }

        public Entity(Guid id) : this()
        {
            this.Id = id;
        }

        [Required(ErrorMessage = "Pole \"Id\" jest wymagane.")]
        public virtual Guid Id { get; protected set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Entity other = obj as Entity;
            if (other != null)
                return Id.Equals(other.Id);
            return base.Equals(obj);
        }
    }
}
