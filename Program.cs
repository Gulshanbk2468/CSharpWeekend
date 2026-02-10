using System;
using System.Diagnostics;
using System.Net;
using System.Text;

class Program
{
    static void Main()
    {
        DatabaseConnect db = new DatabaseConnect();

        db.TestConnection(out string result);

        string url = "http://localhost:5050/";

        // Start browser (Edge)
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });

        // Simple web server
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add(url);
        listener.Start();

        var context = listener.GetContext();
        var response = context.Response;

        string html =
            "<h1>" + result + "</h1>";

        byte[] buffer = Encoding.UTF8.GetBytes(html);

        response.ContentLength64 = buffer.Length;
        response.OutputStream.Write(buffer, 0, buffer.Length);
        response.OutputStream.Close();

        listener.Stop();
    }
}