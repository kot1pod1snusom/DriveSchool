

class MainClass
{
    public static void Main()
    {
        string[] files = Directory.GetFiles("C:\\Users\\home33\\Desktop\\Driveeeer\\DriveSchool\\DriveSchool\\questions\\A_B\\topics");
        for (int i = 0; i < files.Length; i++)
        {
            string jsn = File.ReadAllText(files[i]);
            Question[] que = Newtonsoft.Json.JsonConvert.DeserializeObject<Question[]>(jsn);
            Console.WriteLine(files[i] + " -------> "+ que.Length );
           

        }
    }
}

public class Question
{
    public bool CheckResponse(string answerText)
    {
        for (int i = 0; i < answers.Count; i++)
        {
            if (answers[i].answer_text == answerText)
            {
                if (answers[i].is_correct == true)
                {
                    return true;
                }
                return false;
            }
        }
        return false;
    }

    public bool CheckResponse(int index)
    {
        if (answers[index].is_correct == true) return true;
        return false;
    }

    public int FindAnswerIndex(string str)
    {
        for (int i = 0; i < answers.Count; i++)
        {
            if (answers[i].answer_text == str) return i;
        }
        return -1;
    }

    public int GetTicketNumber()
    {
        return Convert.ToInt32(ticket_number[ticket_number.Length - 2] + ticket_number[ticket_number.Length - 1]);
    }

    public string title;
    public string ticket_number;
    public string ticket_category;
    public string image;
    public string question;
    public List<Answer> answers;
    public string correct_answer;
    public string answer_tip;
    public string[] topic;
    public string id;
}



public class Answer
{
    public string answer_text;
    public bool is_correct;
}