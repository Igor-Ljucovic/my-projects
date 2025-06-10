using System;
using System.Windows.Forms;

namespace Client.Util
{
    static internal class Validation
    {
        static internal bool Validate(bool condition, string errorMessage)
        {
            if (condition)
            {
                if (errorMessage == null)
                    return false;

                MessageBox.Show(errorMessage);
                return false;
            }
            return true;
        }

        static internal bool TryParse<T>(string input, out T result, string errorMessage)
        {
            result = default;

            try
            {
                if (typeof(T) == typeof(int) && int.TryParse(input, out int intValue))
                {
                    result = (T)(object)intValue;
                    return true;
                }
                else if (typeof(T) == typeof(float) && float.TryParse(input, out float floatValue))
                {
                    result = (T)(object)floatValue;
                    return true;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show(errorMessage);
            return false;
        }
    }
}
