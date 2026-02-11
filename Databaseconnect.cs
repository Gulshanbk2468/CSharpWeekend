using MySql.Data.MySqlClient;

public class DatabaseConnect
{
    string connStr = "server=localhost;user=root;password=;database=techcsharp";
    public bool TestConnection(out string message)
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                message = "Database Connected Successfully!";
                return true;
            }
        }
        catch (System.Exception ex)
        {
            message = "Error: " + ex.Message;
            return false;
        }
    }
}