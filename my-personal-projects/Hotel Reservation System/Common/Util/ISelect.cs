using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    internal interface ISelect
    {
        public string SelectSQLCondition { get; }
    }
}
