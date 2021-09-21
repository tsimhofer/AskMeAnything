using System;
using System.IO;
using System.Collections;
using System.Text;
namespace AskMeAnything
{

    class AmA
    {
        static void Main(string[] args)
        {
            string fileName = Path.GetTempFileName();
            init(fileName);

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Contains("?"))
                {
                    string[] inputs = input.Split("?");
                    //Console.WriteLine("Inputs[1] size=" + inputs[1].Length);
                    if (inputs[1].Length > 0) // Case 1: Question defined
                    {
                        AmA.DefineQuestion(fileName, input);

                    }
                    else // Case 2: Question asked 
                    {
                        Question q = AmA.FindQuestion(inputs[0], fileName);
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
        public static void init(string path)
        {
            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Create the file.
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "What is Peters favorite food? \"Pizza\" \"Spaghetti\" \"Ice Cream\"\r\n");
            }
            Console.WriteLine("Initialized temporary file '" + path + "'.");
            Console.WriteLine("Welcome to AmA! Ask me anything ... \r\n");

        }

        public static void DefineQuestion(string path, string input)
        {
            //Question question = LineToQuestion(input);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(input);
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        public static Question FindQuestion(string q, string filename)
        {
            Question question = null;
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            string line;

            while ((line = file.ReadLine()) != null)
            {
                if (line.Split("?")[0].Equals(q))
                {
                    question = LineToQuestion(line);
                }
            }

            file.Close();
            return question;
        }
        public static Question LineToQuestion(string line)
        {
            string[] qa = line.Split("?");
            Question q = new Question(qa[0]);
            string[] answers = qa[1].Split("\"");

            for (int i = 1; i < answers.Length; i += 2)
            {

                if (answers[i].Length > 0)
                {
                    q.addAnswer(answers[i].Substring(0, answers[i].Length));
                }

            }
            return q;
        }
    }

    class Question
    {
        string question = "";
        ArrayList answers = new ArrayList();
        public Question(string question)
        {
            this.question = question;
        }
        public void addAnswer(string answer)
        {
            this.answers.Add(answer);
        }

        public void printAnswers()
        {
            foreach (string answer in answers)
            {
                Console.Write($"{answer} \r\n");
            }
        }

    }
}
