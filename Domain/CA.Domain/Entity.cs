using System;
using Ca.Domain.Exceptions;

namespace CA.Domain
{
    public abstract class Entity
    {
       int _Id;

        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public Entity()
        {

        }
    }
}
