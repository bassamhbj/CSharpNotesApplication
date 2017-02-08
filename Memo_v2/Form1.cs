using Memo_v2.Controller;
using Memo_v2.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memo_v2.Logic;

namespace Memo_v2 {
    public partial class Form1 : Form, Observer{
        Controlador control;

        public Form1(Controlador control) {
            InitializeComponent();
            this.control = control;

            control.addObserver(this);
        }

        public void onLoadMemo(List<Memo> memoList) {
            //throw new NotImplementedException();
            listBox1.Items.Clear();
            
            foreach(var memo in memoList) {
                listBox1.Items.Add(memo.Title);
            }
        }

        public void onLoadMemoBody(string body) {
            //throw new NotImplementedException();
            richTextBox1.Text = body;
        }

        private void Form1_Load(object sender, EventArgs e) {
            control.loadMemo();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            control.loadMemoBody(listBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e) {
            using(Form2 frm = new Form2(control)) {
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        public void onNewMemoCreated() {
            //throw new NotImplementedException();
            control.loadMemo();
        }

        public void onMemoDeleted() {
            //throw new NotImplementedException();
            control.loadMemo();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
            //autoSave doesnt work properly
            //control.autoSave(richTextBox1.Text, DateTime.Now, listBox1.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e) {
            control.deleteMemo(listBox1.SelectedIndex);
            richTextBox1.Text = "";
        }
    }
}
