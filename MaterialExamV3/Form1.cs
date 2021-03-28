using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialExamV3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitMyApp();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string Clipboard_now = Clipboard.GetText();
            if (Clipboard_tmp != Clipboard_now)
            {
                toolStripStatusLabel1.Text = Clipboard_now;
                string question = Clipboard_now;
                var keyValuePairs = Query.DoQuery(Context, question);
                string res = Query.Formatted(keyValuePairs, Context);
                textBox1.Text = res;

            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.TopMost = true;

        }



        private void InitMyApp()
        {
            Context = Query.InitDataBase();
            Clipboard_tmp = Clipboard.GetText();
        }

    }
}
