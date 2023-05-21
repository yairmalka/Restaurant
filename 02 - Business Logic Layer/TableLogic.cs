using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Restaurant
{
    public class TableLogic : BaseLogic
    {

        public void LoadAllRestaurantTables()
        {
            string listOfRestaurantTables = "C:\\Projects\\AngularProjectTest\\RestaurantApplication\\CSV Files\\Tables.csv";
            using (var reader = new StreamReader(listOfRestaurantTables))
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("TableNumber");
                dataTable.Columns.Add("TableAvailable");
                dataTable.Columns.Add("TableNumOfSeats");


                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var values = line.Split(",");
                    dataTable.Rows.Add(values[1], true, values[3]);
                }

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var bulkCpy = new SqlBulkCopy(connectionString))
                    {
                        bulkCpy.DestinationTableName = "Tables";
                        bulkCpy.ColumnMappings.Add("TableNumber", "TableNumber");
                        bulkCpy.ColumnMappings.Add("TableAvailable", "TableAvailable");
                        bulkCpy.ColumnMappings.Add("TableNumOfSeats", "TableNumOfSeats");
                        bulkCpy.WriteToServer(dataTable);
                    }
                }
            }
        }

        public int AssignFreeTable(int numOfSeats)
        {
            List<Table> availableTables = db.Tables.Where(t => t.TableAvailable == true).OrderBy(t => t.TableNumOfSeats).ToList();
            Table availableTable = availableTables.FirstOrDefault(t => t.TableNumOfSeats == numOfSeats);

            if (availableTable == null)
            {
                availableTable = availableTables.FirstOrDefault(t => t.TableNumOfSeats > numOfSeats);

                if (availableTable == null) // if all tables are taken
                {
                    throw new NotFoundException($"No suitable table with {numOfSeats} or more seats found.");
                }
            }

            availableTable.TableAvailable = false;
            db.SaveChanges();
            return availableTable.TableId;

        }

        //TO DO: freeTable(int id)

    }
}
