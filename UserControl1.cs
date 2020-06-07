/*

 Author: Quentin 'Q' James Thomas
 Email: libnexus.theprogrammer@gmail.com
 
 Project Start Date: 05/06/2020
 Language/s: C#
 License: MIT
 Made In: Visual Studio 2019

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MasterSet)
            {
                if (Global.Attempts <= 1) { MessageBox.Show("You've exceeded your attempts, now closing form", "Uh Oh!"); this.Parent.FindForm().Close(); }
                else
                {
                    if (textBox1.Text == Properties.Settings.Default.MasterUsername && textBox2.Text == Properties.Settings.Default.MasterPassword) { this.Hide(); }

                    else { Global.Attempts -= 1;  MessageBox.Show(String.Format("Either your username or password was wrong! Attempts remaining {0}", Global.Attempts), "Uh oh!"); }
                }
            }
            else
            {
                MessageBox.Show("There is no Master information set! Please Type in your wanted information to set some Master information!", "Uh Oh!");
                this.Hide();
                this.Parent.FindForm().GetNextControl(this, true).Show();
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }

    static class Global
    {
        public static int Attempts = 5;
    }
}
