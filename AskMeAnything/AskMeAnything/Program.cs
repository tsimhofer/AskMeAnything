using System;
using System.IO;
using System.Collections;
using System.Text;
namespace AskMeAnything
{

    public class AmA
    {
        ArrayList Questions = new ArrayList();

        static void Main(string[] args)
        {
            AmA myAmA = new AmA();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Contains("?"))
                {
                    string[] inputs = input.Split("?");
                    if (inputs[1].Length > 0) // Case 1: Question defined
                    {
                        myAmA.DefineQuestion(input);
                    }
                    else // Case 2: Question asked 
                    {
                        Question q = myAmA.FindQuestion(inputs[0]);
                        if (q != null)
                        {
                            q.printAnswers();
                        }
                        else Console.WriteLine("the answer to life, universe and everything is 42");
                    }

                }
                else
                {
                    //Console.WriteLine("Usage: <question>? \"<answer1>\" \"<answer2>\" ... \"<answerN>\"");
                }

            }
        }
      
        public ArrayList GetQuestions()
        {
            return this.Questions;
        }

        public Boolean DefineQuestion(string input)
        {
            Question question = null;
            try
            {
                question = LineToQuestion(input);
            }catch(ArgumentException e)
            {
                throw new ArgumentException("Argument is too long! ", e);
            }
            
            
            if (question != null)
            {
                this.Questions.Add(question);
                return true;
            }
            
            return false;
        }

        public Question FindQuestion(string q)
        {
            foreach(Question question in Questions)
            { 
                if (question.getQuestion().Equals(q))
                {
                    return question;
                }
            }

            return null;
        }
        public static Question LineToQuestion(string line)
        {
            
            string[] qa = line.Split("?");

            if (qa[0].Length > 255)
            {
                throw new ArgumentException("Question must be less than 255 characters long!");
            }
            Question q = new Question(qa[0]);

            if (qa.Length < 2) // Usage Error - '?' missing
                return null;

            string[] answers = qa[1].Split("\"");

            /* @TODO Handle usage errors*/

            for (int i = 1; i < answers.Length; i += 2)
            {
                if(answers[i].Length > 255)
                {
                    throw new ArgumentException("Answer is too long (max. 255 characters)");
                }
                if (answers[i].Length > 0)
                {
                    q.addAnswer(answers[i].Substring(0, answers[i].Length));
                }
                else
                {
                    // Usage ...
                    return null;
                }
            }
            return q;
        }
    }

    public class Question
    {
        string question = "";
        ArrayList answers = new ArrayList();
        public Question(string question)
        {
            this.question = question;
        }
        public void addAnswer(string answer)
        {
            answers.Add(answer);
        }

        public void printAnswers()
        {
            foreach (string answer in answers)
            {
                Console.Write($"{answer} \r\n");
            }
        }

        public string getQuestion()
        {
            return this.question;
        }

        public ArrayList getAnswers()
        {
            return answers;
        }
    }
}
