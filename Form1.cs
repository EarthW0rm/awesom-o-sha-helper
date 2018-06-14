using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sha256_helper
{
     public partial class Form1 : Form
    {
        public string Hash { get; set; }
        public string Path { get; set; }

        public Form1(string hash, string path)
        {
            InitializeComponent();
            this.Hash = hash.ToLower();
            this.Path = path;

            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;


            

            this.KeyDown += Form1_KeyDown;
            this.textBox1.KeyDown += Form1_KeyDown;
            this.textBox2.KeyDown += TextBox2_KeyDown;
            this.button1.KeyDown += Form1_KeyDown;
        }

        private void copyPath() {
            System.Windows.Forms.Clipboard.SetText(this.Path);
            this.label2.Text = string.Empty;
            System.Threading.Thread.Sleep(100);
            this.label2.Text = "Copiado path para área de transferência.";
        }

        private void copyHash()
        {
            System.Windows.Forms.Clipboard.SetText(this.Hash);
            this.label2.Text = string.Empty;
            System.Threading.Thread.Sleep(100);
            this.label2.Text = "Copiado hash para área de transferência.";
        }
               

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.label2.Text = string.Empty;
            this.textBox1.AllowDrop = false;
            this.textBox1.Text = this.label1.Text = this.Hash;
            this.textBox1.Width = this.label1.Width;
            if (this.Width < this.pictureBox1.Width + this.label1.Width + 40)
                this.Width = this.pictureBox1.Width + this.label1.Width + 40;

            this.textBox2.Text = this.Path;
            this.textBox2.Width = this.textBox1.Width;

            this.textBox1.SelectionStart = 0;
            this.textBox1.DeselectAll();

            this.textBox2.SelectionStart = 0;
            this.textBox2.DeselectAll();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                copyHash();
            }
            else {
                e.Handled = true;
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                copyPath();
            }
            else
            {
                e.Handled = true;
            }
        }

        private void block_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            copyHash();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.textBox1.Focus();
            this.textBox1.SelectionStart = 0;
            this.textBox1.SelectAll();

            copyHash();
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.textBox2.Focus();
            this.textBox2.SelectionStart = 0;
            this.textBox2.SelectAll();

            copyPath();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            copyHash();
            Application.Exit();
        }
    }
}
