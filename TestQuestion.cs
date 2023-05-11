using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace OP2_LAB4_U4_05
{
    public class TestQuestion : Question
    {
        public string[] PossibleAnswers { get; private set; }

        /// <summary>
        /// By default compares subject and complexity.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public override int CompareTo(object value)
        {
            if (value is TestQuestion testQuestion)
            {
                if (testQuestion.Subject.CompareTo(Subject) != 0)
                    return testQuestion.Subject.CompareTo(Subject);
                else
                    return testQuestion.Complexity.CompareTo(Complexity);
            }
            else if (value is Question)
                return base.CompareTo(value);
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// By default compares subject and complexity.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public override bool Equals(Question question) =>
            question is TestQuestion testQuestion && testQuestion.Subject == Subject && testQuestion.Complexity == Complexity;
        
        public TestQuestion(string subject, string group, string author, string text, string answer, int complexity, int reward, params string[] possibleAnswers)
        {
            Subject = subject;
            AuthorGroup = group;
            Author = author;
            Text = text;
            CorrectAnswer = answer;
            Complexity = complexity;
            RewardPoints = reward;

            PossibleAnswers = new string[possibleAnswers.Length];
            for (int i = 0; i < possibleAnswers.Length; i++)
                PossibleAnswers[i] = possibleAnswers[i];
        }

    }
}