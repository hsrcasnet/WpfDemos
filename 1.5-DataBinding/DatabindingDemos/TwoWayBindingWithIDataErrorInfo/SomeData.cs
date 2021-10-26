using System.ComponentModel;

namespace TwoWayBinding
{
    public class SomeData : IDataErrorInfo
    {
        public int Value2 { get; set; }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == nameof(this.Value2))
                {
                    if (this.Value2 < 0 || this.Value2 > 100)
                    {
                        return "age must not be less than 0 or greater than 100";
                    }
                }

                return null;
            }
        }
    }
}