using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace SQLScriptUpdateManager.Manager
{
    public class MainManager
    {
        protected void LoadScript(string connectionString, string locationOfPath, string nameOfScript)
        {
            FileInfo file = new FileInfo(Path.Combine(locationOfPath, nameOfScript));
            string script = file.OpenText().ReadToEnd();

            SqlConnection conn = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(conn.ToString()));

            try
            {
                server.ConnectionContext.ExecuteNonQuery(script);
            }
            catch
            {
                throw new Exception("When we try open and load scipt something went wrong");
            }

        }
    }
}
