using System.ComponentModel;
using System.Configuration.Internal;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DriveSchool
{
    public partial class TicketsForm : Form
    {
        private List<Question> questionList = new List<Question>(20);
        private List<int> UserAnswerIndex = new List<int>();
        private int activeQuestionIndex = 0;
        private int correctAnswersCount = 0;

        //Индексы вопросов, на которые пользователь ответил неправильно
        private List<int> UserWrongAnswersIndex = new List<int>();
        //true - exam, false - no exam =)
        private bool TicketOrExam;

        public TicketsForm(List<Question> questions, bool ticketOrExam)
        {
            InitializeComponent();
            questionList = questions;
            //Создание кнопок выбора вопросов
            for (int i = 1; i <= questions.Count; i++)
            {
                Button button = new Button()
                {
                    Name = $"changeQuestionButton{i}",
                    Text = $"{i}",
                    BackColor = Color.DarkGray,
                    ForeColor = SystemColors.ControlText,
                    Size = new Size(45, 20)
                };
                button.Click += buttonChangeQuestion_click;
                flowLayoutPanel1.Controls.Add(button);

                UserAnswerIndex.Add(-1);
            }
            TicketOrExam = ticketOrExam;
            if (ticketOrExam == true)
            {
                labelTime.Text = "20:00";
                timer1.Tick += timer1_TickExam;
            }
            else
            {
                timer1.Tick += timer1_TickTicker;
            }
            QuestionOut(questionList[activeQuestionIndex]);
        }

        private void ShowAnswers()
        {
            TicketOrExam = false;
            for (int i = 0; i < questionList.Count; i++)
            {
                if (questionList[i].CheckResponse(UserAnswerIndex[i]))
                {
                    flowLayoutPanel1.Controls[i].BackColor = Color.Green;
                }
                else
                {
                    flowLayoutPanel1.Controls[i].BackColor = Color.Red;
                }
            }
        }

        private bool TicketPass()
        {
            if (correctAnswersCount == 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int ExamPass()
        {
            //1 - сдал, 0 - доп вопросы, -1 - не сдал

            //Проверка успел ли человек решит билеты за установленное время
            if (UserAnswerIndex.Count < questionList.Count) { return 0; }

            if (questionList.Count == 20)
            {
                if (correctAnswersCount == 20)
                {
                    return 1;
                }

                if (UserWrongAnswersIndex.Count == 1)
                {
                    return 0;
                }
                else if (UserWrongAnswersIndex.Count == 2)
                {
                    if (questionList[UserWrongAnswersIndex[0]].GetTicketNumber() == questionList[UserWrongAnswersIndex[1]].GetTicketNumber())
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                if (UserWrongAnswersIndex.Count == 0)
                {
                    return 1;
                }
                else { return -1; }
            }
            return -1;
        }

        private void OutNewQuestion()
        {
            for (int i = 21; i <= questionList.Count; i++)
            {
                Button button = new Button()
                {
                    Name = $"changeQuestionButton{i}",
                    Text = $"{i}",
                    BackColor = Color.DarkGray,
                    ForeColor = SystemColors.ControlText,
                    Size = new Size(45, 20)
                };
                button.Click += buttonChangeQuestion_click;
                flowLayoutPanel1.Controls.Add(button);
                UserAnswerIndex.Add(-1);
            }

        }

        private void Finale()
        {

            bool passOrNor = false;
            if (TicketOrExam == false)
            {
                passOrNor = TicketPass();
            }
            else
            {
                int st = ExamPass();
                switch (st)
                {
                    case -1:
                        passOrNor = false;
                        break;
                    case 0:
                        if (UserWrongAnswersIndex.Count == 1)
                        {
                            questionList = TicketsWork.AddQuestionsLikeMistakes(questionList, UserWrongAnswersIndex[0]);
                            labelTime.Text = "5:00";
                        }
                        else
                        {
                            questionList = TicketsWork.AddQuestionsLikeMistakes(questionList, UserWrongAnswersIndex[0], UserWrongAnswersIndex[1]);
                            labelTime.Text = "10:00";
                        }
                        UserWrongAnswersIndex.Clear();
                        OutNewQuestion();
                        QuestionOut(questionList[activeQuestionIndex]);
                        return;
                    case 1:
                        passOrNor = true;
                        break;
                    default:
                        break;
                }
            }

            TasksEndScreen f1 = new TasksEndScreen(passOrNor, correctAnswersCount, questionList.Count, labelTime.Text);
            Hide();
            timer1.Stop();
            labelTime.Text = "00:00";
            f1.ShowDialog();
            if (f1.UserChouse == 1)
            {
                Show();
                ShowAnswers();
                Button buttonToMenu = new Button
                {
                    Text = "Выйти в меню",
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };
                buttonToMenu.Click += buttonToMenu_click;
                tableLayoutPanel1.Controls.Add(buttonToMenu, 17, 4);
                tableLayoutPanel1.SetColumnSpan(buttonToMenu, 2);
                tableLayoutPanel1.SetRowSpan(buttonToMenu, 2);

            }
            else if (f1.UserChouse == 2)
            {
                Close();
            }
        }

        private void buttonToMenu_click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonChangeQuestion_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int newActiveIndex = Convert.ToInt32(button.Text) - 1;
            activeQuestionIndex = newActiveIndex;
            QuestionOut(questionList[activeQuestionIndex], button);
        }

        private void LinkLabelAnswer_click(object sender, EventArgs e)
        {
            Button button = (Button)flowLayoutPanel1.Controls[activeQuestionIndex];
            LinkLabel linkLabel = (LinkLabel)sender;
            bool correct = questionList[activeQuestionIndex].CheckResponse(linkLabel.Text);
            UserAnswerIndex[activeQuestionIndex] = questionList[activeQuestionIndex].FindAnswerIndex(linkLabel.Text);
            if (correct == true)
            {
                correctAnswersCount++;
                if (TicketOrExam == true)
                {
                    button.BackColor = Color.Gray;
                }
                else
                {
                    button.BackColor = Color.Green;
                }

            }
            else
            {
                UserWrongAnswersIndex.Add(activeQuestionIndex);
                if (TicketOrExam == true)
                {
                    button.BackColor = Color.Gray;
                }
                else
                {
                    MessageBox.Show(questionList[activeQuestionIndex].answer_tip, "Вы ответили неверно");
                    button.BackColor = Color.Red;
                }
            }
            activeQuestionIndex += 1;
            int num = Convert.ToInt32(labelFinishedQuestios.Text);
            num += 1;
            labelFinishedQuestios.Text = num.ToString();
            if (num == questionList.Count)
            {
                Finale();
                return;
            }
            activeQuestionIndex = FindNearestNotAnsweredQestion(activeQuestionIndex);
            QuestionOut(questionList[activeQuestionIndex]);
        }

        private int FindNearestNotAnsweredQestion(int index)
        {
            if (index == questionList.Count)
            {
                index = 0;
            }

            if (UserAnswerIndex[index] == -1)
            {
                return index;
            }
            else
            {
                index += 1;
                return FindNearestNotAnsweredQestion(index);
            }
        }

        private void QuestionInfoOut()
        {
            labelTicketNumber.Text = questionList[activeQuestionIndex].ticket_number;
            labelQuestionNumber.Text = questionList[activeQuestionIndex].title;
            labelQuestionType.Text = "Тип билета " + questionList[activeQuestionIndex].topic[0];
        }

        private void QuestionOut(Question question)
        {
            tableLayoutPanel2.Controls.Clear();

            int rowsCount = 1;
            tableLayoutPanel2.Controls.Clear();
            QuestionInfoOut();

            PictureBox pictureBox = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Image = Image.FromFile(question.image)
            };
            tableLayoutPanel2.Controls.Add(pictureBox, 1, 0);

            //красим кнопку сверху, в перегрузке ниже эта функция не нужна,т.к. она используется
            //как раз при нажатии нужной кнопки что уже приведет её к фокусу
            flowLayoutPanel1.Controls[activeQuestionIndex].Focus();

            //Отображаем вопрос
            Label label = new Label() { Dock = DockStyle.Fill, Text = question.question, Name = "QuestionTextLabel" };
            label.ForeColor = Color.White;
            tableLayoutPanel2.Controls.Add(label, 0, rowsCount);
            tableLayoutPanel2.SetColumnSpan(label, 3);
            rowsCount++;

            //Отображаем вариванты ответа
            for (int i = 0; i < question.answers.Count; i++)
            {
                LinkLabel label1 = new LinkLabel() { Dock = DockStyle.Fill, Text = question.answers[i].answer_text, Name = "AnswerLabel1" };
                label1.ForeColor = Color.White;
                label1.LinkColor = Color.White;
                label1.Click += LinkLabelAnswer_click;
                tableLayoutPanel2.Controls.Add(label1, 0, rowsCount);
                tableLayoutPanel2.SetColumnSpan(label1, 3);
                rowsCount++;
            }
        }

        private void QuestionOut(Question question, Button button)
        {

            //В этой перегрузке мы меняем выводим уже отвеченный вопрос
            tableLayoutPanel2.Controls.Clear();

            int rowsCount = 1;
            tableLayoutPanel2.Controls.Clear();

            QuestionInfoOut();

            PictureBox pictureBox = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Image = Image.FromFile(question.image)
            };
            tableLayoutPanel2.Controls.Add(pictureBox, 1, 0);

            //Отображаем вопрос
            Label label = new Label() { Dock = DockStyle.Fill, Text = question.question, Name = "QuestionTextLabel" };
            label.ForeColor = Color.White;
            tableLayoutPanel2.Controls.Add(label, 0, rowsCount);
            tableLayoutPanel2.SetColumnSpan(label, 3);
            rowsCount++;

            if (button.BackColor != Color.White)
            {
                for (int i = 0; i < question.answers.Count; i++)
                {
                    Label label1 = new Label() { Dock = DockStyle.Fill, Text = question.answers[i].answer_text };
                    if (question.answers[i].is_correct == false)
                    {
                        if (UserAnswerIndex[Convert.ToInt32(button.Text) - 1] == i && TicketOrExam == false)
                        {
                            label1.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (TicketOrExam == false)
                        {
                            label1.ForeColor = Color.Green;
                        }
                    }

                    tableLayoutPanel2.Controls.Add(label1, 0, rowsCount);
                    tableLayoutPanel2.SetColumnSpan(label1, 3);
                    rowsCount++;
                }

            }
            else
            {
                for (int i = 0; i < question.answers.Count; i++)
                {
                    LinkLabel label1 = new LinkLabel() { 
                        Dock = DockStyle.Fill, 
                        Text = question.answers[i].answer_text,
                        ForeColor = Color.White,
                        LinkColor = Color.White
                    };
                    label1.Click += LinkLabelAnswer_click;
                    tableLayoutPanel2.Controls.Add(label1, 0, rowsCount);
                    tableLayoutPanel2.SetColumnSpan(label1, 3);
                    rowsCount++;
                }
            }
        }

        private void timer1_TickTicker(object sender, EventArgs e)
        {
            string[] time = labelTime.Text.Split(":");
            int minute = Convert.ToInt32(time[0]);
            int seconds = Convert.ToInt32(time[1]);
            if (seconds != 59)
            {
                seconds += 1;
            }
            else
            {
                minute += 1;
                seconds = 0;
            }

            labelTime.Text = minute.ToString() + ":" + seconds.ToString();
        }

        private void timer1_TickExam(object sender, EventArgs e)
        {

            string[] time = labelTime.Text.Split(":");
            int minute = Convert.ToInt32(time[0]);
            int seconds = Convert.ToInt32(time[1]);

            if (minute == 0 && seconds == 0)
            {
                Finale();
            }


            if (seconds != 0)
            {
                seconds -= 1;
            }
            else
            {
                minute -= 1;
                seconds = 59;
            }

            labelTime.Text = minute.ToString() + ":" + seconds.ToString();

        }

        private void buttonUseHint_Click(object sender, EventArgs e)
        {
            if (TicketOrExam == true)
            {
                MessageBox.Show(".|.");
            }
            else
            {
                MessageBox.Show(questionList[activeQuestionIndex].answer_tip);
            }
        }


    }
}

