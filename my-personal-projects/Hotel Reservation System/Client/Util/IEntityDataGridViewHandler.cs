using Common.Domain;
using System.Windows.Forms;
using Common.Communication;

namespace Client.Util
{
    static public class IEntityDataGridViewHandler
    {
        public delegate Response RefreshDelegate(IEntityAndCommandText entityAndCommandText);

        static public void Refresh<IEntityType>(DataGridView dataGridView, IEntityAndCommandText iEntityAndCommandText, RefreshDelegate refreshDelegate)
            where IEntityType : IEntity, new()
        {
            Response response = refreshDelegate(iEntityAndCommandText);
            DataGridViewHandler.Fill<IEntityType>(dataGridView, response.Result);
        }
    }
}
