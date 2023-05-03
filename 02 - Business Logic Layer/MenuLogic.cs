using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class MenuLogic : BaseLogic
    {

        public void LoadMenuTableFile()
        {
            string menuProducts = "C:\\Projects\\AngularProjectTest\\RestaurantApplication\\CSV Files\\MenuProducts.csv";

            var dataTable = new DataTable();
            dataTable.Columns.Add("CategoryID");
            dataTable.Columns.Add("MenuItemName");
            dataTable.Columns.Add("MenuItemDescription");
            dataTable.Columns.Add("MenuItemPrice");

            using (var parser = new TextFieldParser(menuProducts))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                // skip the first line (headers)
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    var values = parser.ReadFields();
                    string menuItemDescription = values[3].Trim('"');
                    dataTable.Rows.Add(values[1], values[2], menuItemDescription, values[4]);
                }
            }

            string connectionString = "Server=.\\sqlExpress;DataBase=Restaurant;Trusted_connection=True;Encrypt=False";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var bulkCopy = new SqlBulkCopy(connectionString))
                {
                    bulkCopy.DestinationTableName = "Menu";
                    bulkCopy.ColumnMappings.Add("CategoryID", "CategoryID");
                    bulkCopy.ColumnMappings.Add("MenuItemName", "MenuItemName");
                    bulkCopy.ColumnMappings.Add("MenuItemDescription", "MenuItemDescription");
                    bulkCopy.ColumnMappings.Add("MenuItemPrice", "MenuItemPrice");
                    bulkCopy.WriteToServer(dataTable);
                }
            }
        }
    }
}
