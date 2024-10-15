using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveSchool
{
    public partial class MainMenu : Form
    {
        //true - A,B   false = C,D 
        private bool CategoryChose = new bool();

        public MainMenu()
        {
            InitializeComponent();
            CheckUpdate();
            labelUser.Size = flowLayoutPanel1.Size;
            labelUser.Text = "Тут будет ваше имя";
            addChousenButton();
        }

        private void CheckUpdate()
        {
            WebClient client = new WebClient();


            if (client.DownloadString("https://pastebin.com/SrTLr3Z7").Contains(File.ReadAllText("version.txt")))
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Обнаружена новая версия программы. Хотите обновить прямо сейчас", "Обновлене", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Открывает ссылку на проект гитхаб
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void ComboBoxChouseCategoryCreate()
        {
            ComboBox comboBox = new ComboBox()
            {
                Dock = DockStyle.Fill,
                FormattingEnabled = true,
                Name = "comboBoxChouseCategory",
                TabIndex = 0
            };

            comboBox.SelectedIndexChanged += comboBoxChouseCategory_ChangeIndex;
            comboBox.Items.Add("A, B");
            comboBox.Items.Add("C, D");
            comboBox.SelectedIndex = 0;

            tableLayoutPanel2.Controls.Add(comboBox, 16, 2);
            tableLayoutPanel2.SetColumnSpan(comboBox, 3);
            tableLayoutPanel2.SetRowSpan(comboBox, 3);
        }

        private void comboBoxChouseCategory_ChangeIndex(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    CategoryChose = true;
                    break;
                case 1:
                    CategoryChose = false;
                    break;
                default:
                    break;
            }
        }

        private void addChousenButton()
        {
            tableLayoutPanel2.Controls.Clear();
            ComboBoxChouseCategoryCreate();
            Button buttonStart = new Button()
            {
                Dock = DockStyle.Fill,
                Text = "Начать экзамен",
                BackColor = Color.LightGray,
            };
            buttonStart.Click += buttonClickStartExam;

            tableLayoutPanel2.Controls.Add(buttonStart);
            tableLayoutPanel2.SetColumn(buttonStart, 2);
            tableLayoutPanel2.SetRow(buttonStart, 2);
            tableLayoutPanel2.SetColumnSpan(buttonStart, 5);
            tableLayoutPanel2.SetRowSpan(buttonStart, 3);


            Button buttonTicket = new Button()
            {
                Dock = DockStyle.Fill,
                Text = "Решать билеты",
                BackColor = Color.LightGray,
            };
            buttonTicket.Click += buttonStartTicket_Click;

            tableLayoutPanel2.Controls.Add(buttonTicket);
            tableLayoutPanel2.SetColumn(buttonTicket, 10);
            tableLayoutPanel2.SetRow(buttonTicket, 2);
            tableLayoutPanel2.SetColumnSpan(buttonTicket, 5);
            tableLayoutPanel2.SetRowSpan(buttonTicket, 3);

        }


        //Добавляет кнопки при выборе предметов 
        private void addTicketButton()
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
                    BackColor = Color.LightGray
                };
                button.Click += buttonTicketClick;


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

            Button but = new Button()
            {
                Text = "Вернуться назад",
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };
            but.Click += buttonReturnToChouse_Click;

            tableLayoutPanel2.Controls.Add(but, x, y);
            tableLayoutPanel2.SetColumnSpan(but, 6);
            tableLayoutPanel2.SetRowSpan(but, 4);

        }

        private void buttonReturnToChouse_Click(object sender, EventArgs e)
        {
            addChousenButton();
        }

        private void buttonTicketClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<Question> ques = TicketsWork.GetTicketFromFile(button.Text, CategoryChose);
            TicketsForm ticketsForm = new TicketsForm(ques, false);
            Hide();
            ticketsForm.ShowDialog();
            Show();
        }

        private void buttonClickStartExam(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<Question> ques = TicketsWork.GetQuestionsForExam(CategoryChose);
            TicketsForm ticketsForm = new TicketsForm(ques, true);
            Hide();
            ticketsForm.ShowDialog();
            Show();
        }

        private void buttonStartTicket_Click(object sender, EventArgs e)
        {
            addTicketButton();
        }

        private void labelUser_Click(object sender, EventArgs e)
        {
            RegistrMenu reg = new RegistrMenu();
            reg.ShowDialog();
        }
    }
}
