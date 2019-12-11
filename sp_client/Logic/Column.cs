using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Column
    {
        public string ColumnName { get; set; }

        public string ColumnStaticName { get; set; }

        public Type ColumnType { get; set; }

        public List<ColumnField> ColumnMultipleValues { get; set; }

        public List<ColumnField> ColumnFields { get; set; }
    }
}
