using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveSchool
{
    public partial class MainMenu : Form
    {
        //true - A,B   false = C,D 
        private bool CategoryId = true;


        public MainMenu()
        {
            if (CheckUpdate())
            {
                Environment.Exit(0);
            }
            InitializeComponent();
            comboBoxChouseCategory.Items.Add("A/B");
            comboBoxChouseCategory.Items.Add("C/D");
            comboBoxChouseCategory.SelectedIndex = 0;
            comboBoxChouseCategory.SelectedIndexChanged += comboBoxChouseCategory_changedSelectionIndex;
        }

        private bool CheckUpdate()
        {
            try
            {
                WebClient client = new WebClient();

                if (client.DownloadString("https://pastebin.com/SrTLr3Z7").Contains(File.ReadAllText("version.txt")))
                {
                    return false;
                }

                DialogResult dialogResult = MessageBox.Show("Обнаружена новая версия программы. Хотите обновить прямо сейчас", "Обновлене", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo("https://github.com/kot1pod1snusom/DriveSchool/releases") { UseShellExecute = true });
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось проверить наличие обновлений, возможно у вас отсутствует подключение к интеренету");
                return false;
            }
        }



        private void comboBoxChouseCategory_changedSelectionIndex(object sender, EventArgs e)
        {
            if (comboBoxChouseCategory.Text == "A/B")
            {
                CategoryId = true;
            }
            else { CategoryId = false; }
        }

        private void printChousenButtonsTopics(List<string> ticketNames)
        {
            tableLayoutPanel2.Controls.Clear();
            int x = 1;
            int y = 1;
            for (int i = 0; i < ticketNames.Count; i++)
            {
                Button button = new Button()
                {
                    Text = ticketNames[i],
                    Enabled = true,
                    Dock = DockStyle.Fill,
                    BackColor = SystemColors.ControlDarkDark
                };
                button.Click += buttonStartTopic_Click;

                tableLayoutPanel2.Controls.Add(button, x, y);
                tableLayoutPanel2.SetColumnSpan(button, 9);
                tableLayoutPanel2.SetRowSpan(button, 2);

                x += 9;
                if (x >= 18)
                {
                    x = 1;
                    y += 2;
                }
            }
        }

        //Default realisation for standart tickets chouse out
        private void printChousenButtonsTickets()
        {
            tableLayoutPanel2.Controls.Clear();
            int x = 1;
            int y = 1;
            for (int i = 1; i <= 40; i++)
            {
                Button button = new Button()
                {
                    Text = $"Билет {i}",
                    Enabled = true,
                    Dock = DockStyle.Fill,
                    BackColor = SystemColors.ControlDarkDark
                };
                button.Click += buttonStartTicket_Click;


                tableLayoutPanel2.Controls.Add(button, x, y);
                tableLayoutPanel2.SetColumnSpan(button, 3);
                tableLayoutPanel2.SetRowSpan(button, 3);

                x += 3;
                if (x >= 18)
                {
                    x = 1;
                    y += 3;
                }
            }
        }

        private void buttonTicketStartOut_Click(object sender, EventArgs e)
        {
            List<string> ticketNames = new List<string>();
            for (int i = 1; i <= 40; i++)
            {
                ticketNames.Add($"Билет {i}");
            }

            printChousenButtonsTickets();
        }

        private void buttonTopicButtonsOut_Click(object sender, EventArgs e)
        {
            List<string> topicsNames = TicketsWork.GetTopicsName(CategoryId);
            printChousenButtonsTopics(topicsNames);
        }

        private void buttonStartTopic_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<Question> ques = TicketsWork.GetTopicTicketFromFile(button.Text, CategoryId);
            TicketsForm ticketsForm = new TicketsForm(ques, false, "00:00");
            Hide();
            ticketsForm.ShowDialog();
            Show();
        }

        private void buttonStartTicket_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<Question> ques = TicketsWork.GetTicketFromFile(button.Text, CategoryId);
            TicketsForm ticketsForm = new TicketsForm(ques, false, "00:00");
            Hide();
            ticketsForm.ShowDialog();
            Show();
        }

        private void buttonStartExam_Click(object sender, EventArgs e)
        {
            List<Question> ques = TicketsWork.GetQuestionsForExam(CategoryId);
            TicketsForm ticketsForm = new TicketsForm(ques, true, "20:00");
            Hide();
            ticketsForm.ShowDialog();
            Show();
        }

        private void buttonMarathon_Click(object sender, EventArgs e)
        {
            List<Question> ques = TicketsWork.GetAllQuestions(CategoryId);
            TicketsForm ticketsForm = new TicketsForm(ques, false, "00:00");
            Hide();
            ticketsForm.ShowDialog();
            Show();
        }

        private void buttonCorrectionWork_Click(object sender, EventArgs e)
        {
            List<Question> ques = TicketsWork.GetMistakeQuestions(CategoryId);
            if ((ques == null) || (ques.Count == 0))
            {
                MessageBox.Show("Здесь появятся вопросы, на которые ты ответил неправильно");
                return;
            }
            else
            {
                TicketsForm ticketsForm = new TicketsForm(ques, false, "00:00");
                Hide();
                ticketsForm.ShowDialog();
                Show();
            }
        }
    }
}
