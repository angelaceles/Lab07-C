using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DInvoice
    {
        public static string connectionString = "Data Source=LAB1504-14\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=userTecsup;Password=123456";
        public List<Invoice> Get()
        {
            List<Invoice> result = new List<Invoice>();
         
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "ListarInvoices";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Invoice invoice = new Invoice
                                {
                                    InvoiceId = reader.GetInt32(reader.GetOrdinal("InvoiceId")),
                                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Total = reader.GetDouble(reader.GetOrdinal("Total")),
                                    Active = reader.GetInt32(reader.GetOrdinal("Active"))
                                };
                                result.Add(invoice);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return result;
        }
    }
}
