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
    public partial class TasksEndScreen : Form
    {
        public int UserChouse;

        public TasksEndScreen(bool passOrNot, int correctAnswersCount, int allQuestionCount, string time)
        {
            InitializeComponent();

            if (passOrNot)
            {
                labelSuccessfullOrNot.Text = "Успешно";
                labelSuccessfullOrNot.ForeColor = Color.Green;
                pictureBox1.Image = Image.FromFile("images\\Finale\\green.png");
            }
            else
            {
                labelSuccessfullOrNot.Text = "Провалено";
                labelSuccessfullOrNot.ForeColor = Color.Red;
                pictureBox1.Image = Image.FromFile("images\\Finale\\red.png");
            }

            labelAnswersSt.Text = $"Вы ответили верно на {correctAnswersCount} из {allQuestionCount}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserChouse = 1;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserChouse = 2;
            Close();
        }
    }
}
