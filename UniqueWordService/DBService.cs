using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordService
{
    public sealed class DBService : BaseService
    {
        private string _connectionString;
        public DBService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        }
        // add a word to DB
        public override void AddWord(string word)
        {           
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("insert into WordsTable(word) values(@word)", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@word", SqlDbType.NVarChar).Value = word;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public override List<KeyValuePair<string, int>> GetWords()
        {
            List<KeyValuePair<string, int>> words = new List<KeyValuePair<string, int>>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select word,count(*) as count from WordsTable with(nolock) group by word", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            words.Add(new KeyValuePair<string, int>(Convert.ToString(reader["word"]), Convert.ToInt32(reader["PostCodesId"])));
                        }
                    }
                }
            }
            return words;
        }
    }
}
