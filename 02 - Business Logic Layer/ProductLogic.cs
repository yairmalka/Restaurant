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
    public class ProductLogic : BaseLogic
    {

        public void LoadProductTableFile()
        {
            string products = "C:\\Projects\\AngularProjectTest\\RestaurantApplication\\CSV Files\\Products.csv";

            var dataTable = new DataTable();
            dataTable.Columns.Add("CategoryID");
            dataTable.Columns.Add("ProductName");
            dataTable.Columns.Add("ProductDescription");
            dataTable.Columns.Add("ProductPrice");

            using (var parser = new TextFieldParser(products))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                // skip the first line (headers)
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    var values = parser.ReadFields();
                    string productDescription = values[3].Trim('"');
                    dataTable.Rows.Add(values[1], values[2], productDescription, values[4]);
                }
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var bulkCopy = new SqlBulkCopy(connectionString))
                {
                    bulkCopy.DestinationTableName = "Products";
                    bulkCopy.ColumnMappings.Add("CategoryID", "CategoryID");
                    bulkCopy.ColumnMappings.Add("ProductName", "ProductName");
                    bulkCopy.ColumnMappings.Add("ProductDescription", "ProductDescription");
                    bulkCopy.ColumnMappings.Add("ProductPrice", "ProductPrice");
                    bulkCopy.WriteToServer(dataTable);
                }
            }
        }
    }
}
