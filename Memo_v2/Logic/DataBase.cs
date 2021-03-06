﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Memo_v2.Logic {
    public class DataBase : Storage{
        private List<Memo> memoList;

        // Arreglar SQLTransaction

        public override List<Memo> loadMemo() {
            using (SqlConnection cn = new SqlConnection(DBPath)) {
                string sql = "SELECT * FROM dbo.MemoTable";

                SqlCommand cmd = new SqlCommand(sql, cn);
                //SqlTransaction trans = cmd.Transaction;
                memoList = new List<Memo>();

                try {
                    cn.Open();
                    //cn.BeginTransaction();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read()) {
                        memoList.Add(new Memo(dr.GetDateTime(0), dr.GetString(1), dr.GetString(2)));
                    }
                    dr.Close();

                    foreach(var memo in memoList) {
                        Debug.Print(memo.Title);
                    }

                    //trans.Commit();
                }
                catch (Exception e) {
                    Debug.Print(e.Message);
                }
                finally {
                    //dr.Close();
                }
            }
            return memoList;
        }

        public override void newMemo(string title, string body) {
            using (SqlConnection cn = new SqlConnection(DBPath)) {
                string sql = "INSERT INTO MemoTable(date, title, body) VALUES(@date, @title, @body)";

                cn.Open();

                SqlCommand cmd = new SqlCommand(sql, cn);

                try {
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@body", body);

                    cmd.ExecuteNonQuery();
                    //Debug.Print(DateTime.Now.ToString());
                    Debug.Print("save");
                }
                catch (Exception ex) {
                    Debug.Print(ex.Message);
                }
            }
        }

        public override void deleteMemo(int index) {
            using (SqlConnection cn = new SqlConnection(DBPath)) {
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

        public override void autoSave(string text, DateTime time, int index) {
            using (SqlConnection cn = new SqlConnection(DBPath)) {
                string sql = "UPDATE MemoTable SET body = @body where date = @date";

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
