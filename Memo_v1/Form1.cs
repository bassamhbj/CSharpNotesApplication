using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Memo_v1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private List<Memo> memoList;
        private Observer obs, obs2;

        private void Form1_Load(object sender, EventArgs e) {
            initElem();
        }

        private void initElem() {
            obs = new DataBase();

            loadMemo();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                richTextBox1.Text = memoList[listBox1.SelectedIndex].Body;
            }
            catch(Exception ex) {
                Debug.Print(ex.Message);
            }             
        }

        private void newBT_Click(object sender, EventArgs e) {
            addNote();
        }

        private void deleteBT_Click(object sender, EventArgs e) {
            obs.deleteMemo(listBox1.SelectedIndex);
            richTextBox1.Text = "";
            loadMemo();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
            // Add timer for autosave after a few seconds, not after every new character is added
            obs.autoSave(richTextBox1.Text, DateTime.Now, listBox1.SelectedIndex);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e) {
            Process.Start(e.LinkText);
        }

        public void addNote() {
            using (Form2 frm = new Form2()) {
                frm.ShowDialog();
                frm.Dispose();
                loadMemo();
            }
        }

        public void loadMemo() {
            memoList = obs.loadMemo();;
            listBox1.Items.Clear();

            for (int i = 0; i < memoList.ToArray().Length; i++) {
                listBox1.Items.Add(memoList[i].Title);
            }
        }
    }
}
