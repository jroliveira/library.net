using System;

namespace Demo.Domain.Entities {

    public class Entity {

        public long Id { get; protected set; }
        public DateTime CreatedDate { get; private set; }

        public Entity() {
            CreatedDate = DateTime.Now;
        }
    }
}
