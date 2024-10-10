﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

class TicketsWork
{                                                   //Билет 11 -пример   
    public static List<Question> GetTicketFromFile(string TicketNumber, bool CategoryId)
    {
        string path = "questions";
        if (CategoryId == true)
        {
            path += "\\A_B\\";
        }
        else
        {
            path += "\\C_D\\";
        }

        path += "tickets\\" +TicketNumber + ".json";

        string jsn = File.ReadAllText(path);
            
        List<Question> questions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Question>>(jsn);
        return questions;
    }


    public static List<Question> AddQuestionsLikeMistakes(List<Question> questions, int wrongAnswerIndex1, int wrongAnswerIndex2) {

        questions = AddQuestionsLikeMistakes(questions, wrongAnswerIndex1);
        questions = AddQuestionsLikeMistakes(questions, wrongAnswerIndex2);

        return questions;
    }
   
    //Корчое, функция добавляет вопросы при ошибке пользователя с нужными темами
    public static List<Question> AddQuestionsLikeMistakes(List<Question> questions, int wrongAnswerIndex)
    {
        string[] topicOfQuestion = questions[wrongAnswerIndex].topic;
        string path = "questions\\";
        if (questions[0].ticket_category == "A,B") path += "A_B\\";
        else path += "C_D\\";
        path += "topics\\" + topicOfQuestion[0] + ".json";

        string jsn = File.ReadAllText(path);
        Question[] que = Newtonsoft.Json.JsonConvert.DeserializeObject<Question[]>(jsn);

        if (que.Length <= 5)
        {
            if (topicOfQuestion.Length == 2)
            {
                path = "questions\\";
                if (questions[0].ticket_category == "A,B") path += "A_B\\";
                else path += "C_D\\";
                path += "topics\\" + topicOfQuestion[1] + ".json";

                jsn = File.ReadAllText(path);
                que = Newtonsoft.Json.JsonConvert.DeserializeObject<Question[]>(jsn);
            }
        }

        int iter = 5;
        for (int i = 0; i < iter; i++)
        {
            bool k = false;
            foreach (var item in questions)
            {
                if (item.id == que[i].id)
                {
                    iter++;
                    k = true;
                    break;
                }
            }
            
            if (k == true)
            {
                continue;
            }

            questions.Add(que[i]);
        }

        return questions;
    }

    private static List<Question> GetFiveQuestionsFromFileToExam(List<Question> questions, string path)
    {
        Random random = new Random();
        int num = 0;
        bool nxt = false;
        while (nxt == false) 
        { 
            num = random.Next(1,40);
            nxt = true;
            for (int i = 1; i < questions.Count / 5; i++)
            {
                if (questions[(5 * i) - 1].GetTicketNumber() == num)
                {
                    nxt = false;
                    break;
                }
            }
        }

        path += $"Билет {num}.json";
        string jsn = File.ReadAllText(path);
        Question[] que = Newtonsoft.Json.JsonConvert.DeserializeObject<Question[]>(jsn);

        int minIndex = 0;
        int maxIndex = 0;
        switch (questions.Count)
        {
            case 0:
                minIndex = 0;
                maxIndex = 4;
                break;
            case 5:
                minIndex = 5;
                maxIndex = 9;
                break;
            case 10:
                minIndex = 10;
                maxIndex = 14;
                break;
            case 15:
                minIndex = 15;
                maxIndex = 19;
                break;
            default:
                break;
        }


        for (int i = minIndex; i <= maxIndex; i++)
        {
            questions.Add(que[i]);
        }
        return questions;
    }

    public static List<Question> GetQuestionsForExam(bool Category) {
        string path = "questions";
        if (Category == true)
        {
            path += "\\A_B\\";
        }
        else
        {
            path += "\\C_D\\";
        }
        path += "tickets\\";

        List<Question> questions = new List<Question>();
        for (int i = 0; i < 4; i++)
        {
            questions = GetFiveQuestionsFromFileToExam(questions, path);
        }
        return questions;
    }
}


