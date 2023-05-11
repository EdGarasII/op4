using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace OP2_LAB4_U4_05
{
    struct AuthorQuestionCount
    {
        public string Group;
        public string Author;
        public int QuestionCount;
    }

    class AnalyticsQueries
    {
        /// <summary>
        /// method for finding author with most questions
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static AuthorQuestionCount AuthorWithMostQuestions(List<Question> questions)
        {
            if (questions.Count == 0)
                throw new InvalidOperationException();

            return questions

                // Grouping by author names
                .GroupBy(question => question.Author)

                // Converting author's question group into object with it's name, group and question count
                .Select(group => new AuthorQuestionCount()
                {
                    Author = group.First().Author,
                    Group = group.First().AuthorGroup,
                    QuestionCount = group.Count()
                })

                // Ordering by question count
                .OrderBy(author => author.QuestionCount)

                // Selecting first occurence (with the most questions)
                .FirstOrDefault();
        }
        /// <summary>
        /// method to find author with most questions in each group
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public static AuthorQuestionCount[] AuthorWithMostQuestionsInEachGroup(List<Question> questions)
        {
            return questions
                // Grouping questions by author groups
                .GroupBy(question => question.AuthorGroup)

                // Converting author groups to author with most questions data object
                .Select(questionsInAuthorGroup => questionsInAuthorGroup
                    // Grouping each question in author group by author
                    .GroupBy(question => question.Author)

                    // Converting groups of each author's questions into objects with stats
                    .Select(questionsByEachAuthor => new AuthorQuestionCount()
                    {
                        Group = questionsByEachAuthor.First().AuthorGroup,
                        Author = questionsByEachAuthor.First().Author,
                        QuestionCount = questionsByEachAuthor.Count()
                    })

                    // Ordering by most questions
                    .OrderBy(author => author.QuestionCount)

                    // Selecting first (with most questions)
                    .FirstOrDefault())

                // Ordering by most questions
                .OrderBy(author => author.QuestionCount)
                .ToArray();
        }
        /// <summary>
        /// method to find author with most music questions in each group
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public static AuthorQuestionCount[] AuthorWithMostMusicQuestionsInEachGroup(List<Question> questions)
        {
            return AuthorWithMostQuestionsInEachGroup(questions.Where(question => question is MusicQuestion).ToList());
        }
        /// <summary>
        /// method for sorting test questions
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public static TestQuestion[] SortTestQuestions(List<Question> questions)
        {
            return questions
                .Where(question => question is TestQuestion)
                .Select(question => question as TestQuestion)
                .OrderBy(question => question.Subject)
                .ThenBy(question => question.Complexity)
                .ToArray();
        }
        /// <summary>
        /// method for sorting music questions
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public static MusicQuestion[] SortMusicQuestions(List<Question> questions)
        {
            return questions
                .Where(question => question is MusicQuestion)
                .Select(question => question as MusicQuestion)
                .OrderBy(question => question.MediaFilePath)
                .ToArray();
        }
        /// <summary>
        /// method for sorting all questions
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public static Question[] SortAllQuestions(List<Question> questions)
        {
            return 
                SortTestQuestions(questions)
                .Select(question => question as Question)
                .Concat(
                    SortMusicQuestions(questions)
                    .Select(question => question as Question))
                .ToArray();
        }
        /// <summary>
        /// method for sorting questions by subject
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static Question[] QuestionsBySubject(List<Question> questions, string subject)
        {
            return questions
                .Where(question => question.Subject == subject)
                .OrderBy(question => question.AuthorGroup)
                .ThenBy(question => question.Author)
                .ToArray();
        }
    }
}