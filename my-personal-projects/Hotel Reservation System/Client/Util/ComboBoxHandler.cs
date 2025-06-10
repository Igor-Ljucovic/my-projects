using Common.Domain;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Util
{
    static public class ComboBoxHandler
    {
        static public void Fill<EntityType>(ComboBox comboBox, object dataSource, string displayMember, string valueMember, bool unselectedState)
            where EntityType : IEntity, new()
        {
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedIndex = unselectedState ? -1 : comboBox.SelectedIndex;
            comboBox.DataSource = dataSource;
            AdjustComboBoxDropDownWidth(comboBox);
        }

        static public void AdjustComboBoxDropDownWidth(ComboBox comboBox)
        {
            int maxWidth = comboBox.DropDownWidth;

            using (Graphics graphic = comboBox.CreateGraphics())
            {
                foreach (var row in comboBox.Items)
                {
                    string text = row.ToString();
                    int width = (int)graphic.MeasureString(text, comboBox.Font).Width;
                    if (width > maxWidth)
                        maxWidth = width;
                }
            }
            comboBox.DropDownWidth = maxWidth + 20;
        }
    }
}
