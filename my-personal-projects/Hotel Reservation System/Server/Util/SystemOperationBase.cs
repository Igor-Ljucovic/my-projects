using DBBroker;
using System;

namespace Server.SystemOperation
{
    public abstract class SystemOperationBase<EntityType, ResultType>
    {
        protected Broker broker;
        protected EntityType Entity { get; set; }
        public ResultType Result { get; set; }

        public SystemOperationBase()
        {
            broker = new Broker();
        }

        public void ExecuteTemplate()
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();

                ExecuteConcreteOperation();

                broker.Commit();
            }
            catch (Exception ex)
            {
                broker.Rollback();
                throw ex;
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        protected abstract void ExecuteConcreteOperation();
    }
}
