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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) { if (checkBox1.Checked) { textBox1.UseSystemPasswordChar = false;  } else { textBox1.UseSystemPasswordChar = true;  } }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) { if (checkBox2.Checked) { textBox2.UseSystemPasswordChar = false;  } else { textBox2.UseSystemPasswordChar = true;  } }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) { if (checkBox3.Checked) { textBox3.UseSystemPasswordChar = false; } else { textBox3.UseSystemPasswordChar = true; } }

        private void UserControl2_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 5)
            {
                MessageBox.Show("Looks like your username length is less than 6 characters OR contains a/ space/s, you must have a username of more than 5 characters long", "Uh Oh!");
            }
            else
            {
                if (textBox2.Text == textBox3.Text | textBox2.Text.Length <= 5)
                {
                    PasswordManager.PasswordStrength Ps = new PasswordManager.PasswordStrength();

                    if (Ps.Check(textBox2.Text))
                    {
                        Properties.Settings.Default.MasterSet = true;
                        Properties.Settings.Default.MasterUsername = textBox1.Text;
                        Properties.Settings.Default.MasterPassword = textBox2.Text;
                        Properties.Settings.Default.Save();
                        this.Hide();
                        this.Parent.FindForm().GetNextControl(this, true).Show();
                    }
                    else
                    {
                        if (MessageBox.Show("The password checking algorithm says that this password is not secure! A strong password should have 2 of each of the following: Upper case character, Lower case character, special character, number. As well as the length which should be at least 12 characters long! Are you sure you want that to be your password?", "Uh oh!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Properties.Settings.Default.MasterSet = true;
                            Properties.Settings.Default.MasterUsername = textBox1.Text;
                            Properties.Settings.Default.MasterPassword = textBox2.Text;
                            Properties.Settings.Default.Save();
                            this.Hide();
                            this.Parent.FindForm().GetNextControl(this, true).Show();
                        }
                        else { MessageBox.Show("In that case, try creating a new, stronger password for your master account login!", "Let's try again!"); }
                    }
                }
                else { MessageBox.Show("Looks like either the passwords don't match or they have a length of under 6! Make sure that they match if you want to save your settings!", "Uh Oh!"); }
            }
        }
    }
}
