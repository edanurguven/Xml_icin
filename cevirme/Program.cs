using System;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace cevirme
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var con = new SqlConnection(@"Server=Data Source=DESKTOP-DELL\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=SınavDatabaseDb;Integrated Security=true"))
            {
                con.Open();

                var cmdCreateTable = new SqlCommand("if object_id('dbo.t') is null create table t(id int identity primary key, doc xml);", con);
                cmdCreateTable.ExecuteNonQuery();

                var cmdInsertXml = new SqlCommand("insert into t(doc) values (@doc);", con);
                var pDoc = cmdInsertXml.Parameters.Add("@doc", System.Data.SqlDbType.Xml);

                var doc = XDocument.Parse("<root><cn/><cn/><cn/></root>");
                pDoc.Value = doc.CreateReader();

                cmdInsertXml.ExecuteNonQuery();

                var cmdRetrieveXml = new SqlCommand("select id, doc from t", con);
                using (var rdr = cmdRetrieveXml.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var xr = rdr.GetSqlXml(1);
                        var rd = XDocument.Parse(xr.Value);
                        Console.WriteLine(rd.ToString());

                    }
                }
            }
        }
    }
}