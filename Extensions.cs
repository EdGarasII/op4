using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OP2_LAB4_U4_05
{
    static class Extensions
    {
        /// <summary>
        /// Table extension method, adds row based on given strings/objects
        /// </summary>
        /// <param name="table"></param>
        /// <param name="cells"></param>
        public static void AddTableRowFromStrings(this Table table, params object[] cells)
        {
            TableRow row = new TableRow();

            foreach (object cell in cells)
                row.Cells.Add(new TableCell() { Text = cell.ToString() });

            table.Rows.Add(row);
        }

        /// <summary>
        /// Removes all except first (header) row
        /// </summary>
        /// <param name="table"></param>
        public static void RemoveAllExceptFirstRows(this Table table)
        {
            if (table.Rows.Count == 0)
                throw new InvalidOperationException();

            TableRow firstRow = table.Rows[0];
            table.Rows.Clear();
            table.Rows.Add(firstRow);
        }
    }
}