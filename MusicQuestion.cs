using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP2_LAB4_U4_05
{
    public class MusicQuestion : Question
    {
        public string MediaFilePath { get; private set; }

        /// <summary>
        /// By default compares text.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public override int CompareTo(object value)
        {
            if (value is MusicQuestion musicQuestion)
                return musicQuestion.MediaFilePath.CompareTo(MediaFilePath);
            else if (value is Question)
                return base.CompareTo(value);
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// By default compares text.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public override bool Equals(Question question) =>
            question is MusicQuestion musicQuestion && musicQuestion.MediaFilePath == MediaFilePath;

        public MusicQuestion(string subject, string group, string author, string text, string answer, int complexity, int reward, string media)
        {
            Subject = subject;
            AuthorGroup = group;
            Author = author;
            Text = text;
            CorrectAnswer = answer;
            Complexity = complexity;
            RewardPoints = reward;
            MediaFilePath = media;
        }
    }
}