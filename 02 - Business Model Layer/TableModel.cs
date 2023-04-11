using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class TableModel
    {
        public int TableId { get; set; }

        public int? TableNumber { get; set; }

        public bool? TableAvailable { get; set; }

        public int TableNumOfSeats { get; set; }


        public TableModel(Table table)
        {
            TableId = table.TableId;
            TableNumber = table.TableNumber;
            TableAvailable = table.TableAvailable;
            this.TableNumOfSeats = table.TableNumOfSeats;
        }

        public TableModel() { }


    }
}
