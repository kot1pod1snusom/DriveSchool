﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveSchool
{
    public partial class NewMainMenu : Form
    {
        //true - A,B   false = C,D 
        private bool CategoryId;


        public NewMainMenu()
        {
            InitializeComponent();
            comboBoxChouseCategory.Items.Add("A/B");
            comboBoxChouseCategory.Items.Add("C/D");
            comboBoxChouseCategory.SelectedIndex = 0;
            comboBoxChouseCategory.SelectedIndexChanged += comboBoxChouseCategory_changedSelectionIndex;
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
            TicketsForm ticketsForm = new TicketsForm(ques, false);
            Hide();
            ticketsForm.ShowDialog();
            Show();
        }

        private void buttonStartTicket_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<Question> ques = TicketsWork.GetTicketFromFile(button.Text, CategoryId);
            TicketsForm ticketsForm = new TicketsForm(ques, false);
            Hide();
            ticketsForm.ShowDialog();
            Show();
        } 

        private void buttonStartExam_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<Question> ques = TicketsWork.GetQuestionsForExam(CategoryId);
            TicketsForm ticketsForm = new TicketsForm(ques, true);
            Hide();
            ticketsForm.ShowDialog();
            Show();
        }
    }
}