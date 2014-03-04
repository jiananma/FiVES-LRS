using FIVES;
using System;
using System.Runtime.Serialization;

namespace ServerSyncPlugin
{
    [Serializable]
    class EmptyDoR : IDomainOfResponsibility
    {
        public EmptyDoR()
        {
        }

        public bool IsResponsibleFor(Entity entity)
        {
            return false;
        }

        public event EventHandler Changed
        {
            add { }
            remove { }
        }

        #region ISerializable interface

        public EmptyDoR(SerializationInfo info, StreamingContext context)
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion
    }
}
