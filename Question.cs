using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP2_LAB4_U4_05
{
    public abstract class Question: IComparable, IEquatable<Question>
    {
        /// <summary>
        /// By default compares text.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual int CompareTo(object value)
        {
            if (value is Question question)
                return question.Text.CompareTo(Text);
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// By default compares text.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public virtual bool Equals(Question question) => Text == question.Text;

        public string Subject { get; protected set; }
        public string AuthorGroup { get; protected set; }
        public string Author { get; protected set; }
        public string Text { get; protected set; }
        public string CorrectAnswer { get; protected set; }
        public int Complexity { get; protected set; }
        public int RewardPoints { get; protected set; }
    }
}