using Common.Domain;
using Domen;

namespace Server.SystemOperation
{
    public class LogInEmployeeSO : SystemOperationBase<Employee, Employee>
    {
        public LogInEmployeeSO(Employee zaposleni)
        {
           Entity = zaposleni;
        }

        protected override void ExecuteConcreteOperation()
        {
            IEntity zaposleni =  broker.GetOneByConditions<Employee>(Entity.SelectSQLCondition, Entity.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
