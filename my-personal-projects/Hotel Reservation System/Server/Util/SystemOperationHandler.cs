using Server.SystemOperation;

namespace Server.Util
{
    internal class SystemOperationHandler
    {
        public static ResultType Execute<EntityType, ResultType>
                                  (SystemOperationBase<EntityType, ResultType> systemOperationInstance)
        {
            systemOperationInstance.ExecuteTemplate();
            return systemOperationInstance.Result;
        }
    }
}
