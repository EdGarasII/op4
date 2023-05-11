using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OP2_LAB4_U4_05
{
    public class InOut
    {

        public static TestContainer ReadFile( string file)
        {
            TestContainer container = new TestContainer();
            string[] lines = File.ReadAllLines(file);
            foreach(string line in lines)
            {
                string[] values = line.Split(';');
                string subject = values[0];
                string group = values[1];
                string author = values[2];
                string text = values[3];
                string answer = values[4];
                int complexity = int.Parse(values[5]);
                int reward = int.Parse(values[6]);
                string[] possibleAnswers = new string[3];
                for(int i = 0; i < possibleAnswers.Length; i++)
                {
                    possibleAnswers[i] = values[i+7];
                }

                TestQuestion testQuestion = new TestQuestion(subject, group, author, text, answer, complexity, reward, possibleAnswers);
                container.Add(testQuestion);
            }
            return container;
            
             
        }
    }
}