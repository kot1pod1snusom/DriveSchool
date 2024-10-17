using DriveSchool.user;
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


        private bool skipTextBox_TextChanged_HidePassword = false;
        private void textBoxPassword_TextChanged_HidePassword(object sender, EventArgs e)
        {
            if (skipTextBox_TextChanged_HidePassword == true)
            {
                skipTextBox_TextChanged_HidePassword = false;
                return;
            }

            if (textBoxPassword.TextLength < password.Length)
            {
                password = password.Remove(textBoxPassword.SelectionStart, 1);
            }
            else if (textBoxPassword.SelectionStart - 1 >= password.Length)
            {
                password += textBoxPassword.Text[textBoxPassword.TextLength - 1];
            }
            else if (textBoxPassword.SelectionStart - 1 < password.Length)
            {
                string str12 = textBoxPassword.Text[textBoxPassword.SelectionStart - 1].ToString();
                password = password.Insert(textBoxPassword.SelectionStart - 1, str12);
            }

            skipTextBox_TextChanged_HidePassword = true;
            int previosSelectionStart = textBoxPassword.SelectionStart;
            string str = new String('*', textBoxPassword.TextLength);
            textBoxPassword.Text = str;
            textBoxPassword.SelectionStart = previosSelectionStart;
        }


        private void checkBoxShowHidePassword_changed(object sender, EventArgs e)
        {
            if (checkBoxShowHidePassword.Checked)
            {
                hideAllPassword();
                textBoxPassword.KeyPress -= textBoxPassword_TextChanged_ShowPassword;
                textBoxPassword.TextChanged += textBoxPassword_TextChanged_HidePassword;

            }
            else
            {
                textBoxPassword.TextChanged -= textBoxPassword_TextChanged_HidePassword;
                textBoxPassword.KeyPress += textBoxPassword_TextChanged_ShowPassword;
                showAllPassword();
            }
        }

        private void buttonRegistr_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = textBoxName.Text,
                Password = password,
                Id = "-1"
            };

            user = UserJsonDBWork.Registration(user);
        
            if (user.Id == "-1") {
                MessageBox.Show("Данный пользователь уже зарегистрирован");
                return;
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            User user = new User() { 
                Password = password,
                Name = textBoxName.Text,
                Id = "-1"
            };

            user = UserJsonDBWork.LogIn(user);

            if (user.Id == "-1") {
                MessageBox.Show("Данный пользователь уже зарегистрирован");
            }
        }
    }
}
