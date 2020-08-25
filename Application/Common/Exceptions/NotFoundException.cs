using System;

namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object id)
            : base($"Entity {name} with id {id} was not found.")
        {
        }
    }
}
