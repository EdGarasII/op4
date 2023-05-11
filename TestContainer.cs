using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OP2_LAB4_U4_05
{
    public class TestContainer
    {
        public List<TestQuestion> AllTests;

        public TestContainer(List<TestQuestion> allTests)
        {
            AllTests = new List<TestQuestion>();
            foreach (TestQuestion tests in allTests)
            {
                this.AllTests.Add(tests);
            }
        }
        public TestContainer()
        {
            AllTests = new List<TestQuestion>();
        }
        public int GetCount()
        {
            return AllTests.Count;
        }
        public void Add(TestQuestion testQuestion)
        {
            AllTests.Add(testQuestion);
        }
        public TestQuestion Get(int index)
        {
            return AllTests[index];
        }
    }
}