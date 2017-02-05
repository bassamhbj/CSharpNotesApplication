using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace Memo_v1 {
    class DataBase : Observer {

        private List<Memo> memoList;
        private DBXMLPath dbPATH = new DBXMLPath();


        public List<Memo> loadMemo() {
            using (SqlConnection cn = new SqlConnection(dbPATH.DBPath)) {
                string sql = "SELECT * FROM dbo.MemoTable";

                SqlCommand cmd = new SqlCommand(sql, cn);
                memoList = new List<Memo>();

                try {
                    cn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read()) {
                        memoList.Add(new Memo(dr.GetDateTime(0), dr.GetString(1), dr.GetString(2)));
                    }
                    dr.Close();

                }
                catch (Exception e) {
                    Debug.Print(e.Message);
                }
            }
                return memoList;
        }

        public void newMemo(string title, string body) {
            using (SqlConnection cn = new SqlConnection(dbPATH.DBPath)) {
                string sql = "INSERT INTO MemoTable(date, title, body) VALUES(@date, @title, @body)";

                cn.Open();

                SqlCommand cmd = new SqlCommand(sql, cn);

                try {
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@body", body);

                    cmd.ExecuteNonQuery();
                    Debug.Print(DateTime.Now.ToString());
                    Debug.Print("save");
                }
                catch (Exception ex) {
                    Debug.Print(ex.Message);
                }
            }
        }

        public void deleteMemo(int index) {
            using (SqlConnection cn = new SqlConnection(dbPATH.DBPath)) {
                string sql = "DELETE FROM dbo.MemoTable WHERE date = @date";

                SqlCommand cmd = new SqlCommand(sql, cn);

                try {
                    cmd.Parameters.AddWithValue("@date", memoList[index].Date);

                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex) {
                    Debug.Print(ex.Message);
                }
            }
        }

        public void autoSave(string text, DateTime time, int index) {
            using (SqlConnection cn = new SqlConnection(dbPATH.DBPath)) {
                string sql = "UPDATE dbo.MemoTable SET body = @body where date = @date";

                SqlCommand cmd = new SqlCommand(sql, cn);

                Debug.Print("changing text2");

                try {
                    cn.Open();

                    cmd.Parameters.AddWithValue("@body", text);
                    cmd.Parameters.AddWithValue("@date", time);

                    cmd.ExecuteNonQuery();

                    memoList[index].Body = text;

                    Debug.Print("autosave2");
                }
                catch (Exception ex) {
                    Debug.Print(ex.Message);
                }
            }
        }
    }
}
