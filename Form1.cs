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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Hide user controls
            userControl11.Show();
            userControl21.Hide();
            userControl31.Hide();

            //Format textboxes
        }
    }
}
