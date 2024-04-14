using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace MyStore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try 
            {
                 using(SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1C3GF3F\\SQLEXPRESS01;Initial Catalog=mystore;Integrated Security=True;TrustServerCertificate=True"))
                {
                    connection.Open();
                    String sql = "SELECT * FROM CLIENTS";
                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = "" + reader.GetString(1);
                                clientInfo.email = "" + reader.GetString(2);
                                clientInfo.phone = "" + reader.GetString(3);
                                clientInfo.address = "" + reader.GetString(4);
                                clientInfo.created = "" + reader.GetDateTime(5).ToString(); 
                                listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("EXCEPTION : " + ex.ToString());
            }
        }
    }
    public class ClientInfo 
    {
        public String id;    
        public String name;    
        public String email;    
        public String phone;    
        public String address;
        public String created;
    }
}
