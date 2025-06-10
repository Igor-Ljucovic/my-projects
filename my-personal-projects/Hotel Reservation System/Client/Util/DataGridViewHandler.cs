using Common.Domain;
using System.Windows.Forms;

namespace Client.Util
{
    static public class DataGridViewHandler
    {
        static public void Fill<EntityType>(DataGridView dataGridView, object dataSource)
            where EntityType : IEntity, new()
        {
            dataGridView.DataSource = dataSource;

            foreach (string column in new EntityType().DataGridViewColumnsToIgnore)
                dataGridView.Columns[column].Visible = false;
        }
    }
}
