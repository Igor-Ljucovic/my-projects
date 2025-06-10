using Common.Communication;
using Common.Domain;
using Common.Util;
using System.Windows.Forms;

namespace Client.Util
{
    static public class IEntityComboBoxHandler
    {
        public delegate Response SearchDelegate(IEntityAndCommandText entityAndCommandText);

        static public void Fill<IEntityType>(ComboBox comboBox, SearchDelegate searchMethod, string displayMember, string valueMember, bool unselectedState)
            where IEntityType : IEntity, ISearch, IObjectFactory<IEntityType>, new()
        {
            IEntityType iEntityType = IEntityType.CreateInstance();
            Response response = searchMethod(new IEntityAndCommandText { Entity = iEntityType, SQLCommandText = iEntityType.WhereSQLCondition });
            ComboBoxHandler.Fill<IEntityType>(comboBox, response.Result, displayMember, valueMember, unselectedState);
        }
    }
}
