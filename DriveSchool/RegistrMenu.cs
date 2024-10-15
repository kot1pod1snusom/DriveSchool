using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveSchool
{
    public partial class RegistrMenu : Form
    {
        private string password;

        public RegistrMenu()
        {
            InitializeComponent();
            checkBoxShowHidePassword.CheckedChanged += checkBoxShowHidePassword_changed;
            checkBoxShowHidePassword.Checked = true;
        }


        private void hideAllPassword()
        {
            password = textBoxPassword.Text;
            textBoxPassword.Text = new String('*', textBoxPassword.Text.Length);
            textBoxPassword.SelectionStart = textBoxPassword.TextLength;
        }
        
        private void showAllPassword()
        {
            textBoxPassword.Text = password;
        }

        private void textBoxPassword_TextChanged_ShowPassword(object sender, KeyPressEventArgs e)
        {
            password = textBoxPassword.Text;
        }

        private void textBoxPassword_TextChanged_HidePassword(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\b') {
                password = password.Remove(textBoxPassword.SelectionStart - 1, 1); }
            else if (textBoxPassword.SelectionStart == textBoxPassword.TextLength) password += e.KeyChar;
            else password.Insert(textBoxPassword.SelectionStart, e.KeyChar.ToString());


            string str = new String('*', textBoxPassword.TextLength);
            textBoxPassword.Text = str;
            textBoxPassword.SelectionStart = textBoxPassword.TextLength;
        }

        private void checkBoxShowHidePassword_changed(object sender, EventArgs e)
        {
            if (checkBoxShowHidePassword.Checked) {
                hideAllPassword();
                textBoxPassword.KeyPress -= textBoxPassword_TextChanged_ShowPassword;
                textBoxPassword.KeyPress += textBoxPassword_TextChanged_HidePassword;
            }
            else {
                textBoxPassword.KeyPress -= textBoxPassword_TextChanged_HidePassword;
                textBoxPassword.KeyPress += textBoxPassword_TextChanged_ShowPassword;
                showAllPassword();
            }
        }

    }
}
