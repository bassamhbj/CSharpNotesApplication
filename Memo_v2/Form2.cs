using Memo_v2.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memo_v2 {
    public partial class Form2 : Form {
        Controlador control;
        public Form2(Controlador c) {
            InitializeComponent();
            this.control = c;
        }

        private void button1_Click(object sender, EventArgs e) {
            control.newMemo(textBox1.Text, richTextBox1.Text);
            this.Close();
        }
    }
}
