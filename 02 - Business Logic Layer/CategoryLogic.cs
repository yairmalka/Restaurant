using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class CategoryLogic: BaseLogic
    {
        public void LoadCategoriesTableFile()
        {
            string categoriesCSVfilePath = "C:\\Projects\\AngularProjectTest\\RestaurantApplication\\CSV Files\\Categories.csv";
            using (var reader = new StreamReader(categoriesCSVfilePath))
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("CategoryName");

                // skip the first line (headers)
                reader.ReadLine();

                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    dataTable.Rows.Add(values[1]);
                }

                string connectionString = "Server=.\\sqlExpress;DataBase=Restaurant;Trusted_connection=True;Encrypt=False";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var bulkCopy = new SqlBulkCopy(connectionString))
                    {
                        bulkCopy.DestinationTableName = "Categories";
                        bulkCopy.ColumnMappings.Add("CategoryName", "CategoryName");
                        bulkCopy.WriteToServer(dataTable);
                    }
                }
            }
        }
    }
}
