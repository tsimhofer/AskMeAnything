using Microsoft.VisualStudio.TestTools.UnitTesting;
using AskMeAnything;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AskMeAnything.Tests
{
    [TestClass()]
    public class AmATests
    {

        [TestMethod()]
        public void DefineQuestionReturnsTrue()
        {
            string q = "What is Peters favorite food?";
            string a = " \"Pizza\" \"Spaghetti\" \"Ice cream\"";

            AmA myAmATest = new AmA();

            Assert.IsTrue(myAmATest.DefineQuestion(q + " " + a));

        }
        [TestMethod()]
        public void DefineQuestionReturnsFalse()
        {
            string q = "What is Peters favorite food ";
            string a = " \"Pizza\" \"Spaghetti\" \"Ice cream\"";

            AmA myAmATest = new AmA();

            Assert.IsFalse(myAmATest.DefineQuestion(q + " " + a));

        }
        [TestMethod()]
        public void DefineQuestionFindQuestion()
        {
            string q = "What is Peters favorite food?";
            string a = " \"Pizza\" \"Spaghetti\" \"Ice cream\"";

            AmA myAmATest = new AmA();

            Console.WriteLine("[" + q + " " + a + "]");
            myAmATest.DefineQuestion(q + " " + a);

            Console.WriteLine("questions=" + myAmATest.GetQuestions().Count);
            Assert.AreEqual(myAmATest.GetQuestions().Count, 1);

            Console.WriteLine("answers=" + ((Question)myAmATest.GetQuestions()[0]).getAnswers().Count);

            Assert.AreEqual(((Question)myAmATest.GetQuestions()[0]).getAnswers().Count, 3);

        }
        [TestMethod()]
        public void DefineQuestion_QuestionTooLong_Throws()
        {
            string q = "What is Peters aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabsolute favorite food?";
            string a = " \"Pizza\" \"Spaghetti\" \"Ice cream\"";

            AmA myAmATest = new AmA();

            Assert.ThrowsException<System.ArgumentException>(() => myAmATest.DefineQuestion(q + " " + a));
        }

        [TestMethod()]
        public void DefineQuestion_AnswerTooLong_Throws()
        {
            string q = "What is Peters absolute favorite food?";
            string a = " \"Pizzaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\" \"Spaghetti\" \"Ice cream\"";

            AmA myAmATest = new AmA();

            Assert.ThrowsException<System.ArgumentException>(() => myAmATest.DefineQuestion(q + " " + a));
        }

        [TestMethod()]
        public void FindQuestion()
        {
            string q = "What is Peters absolute favorite food?";
            string a = " \"Pizzaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\" \"Spaghetti\" \"Ice cream\"";

            AmA myAmATest = new AmA();

            Assert.ThrowsException<System.ArgumentException>(() => myAmATest.DefineQuestion(q + " " + a));
        }
    }
}