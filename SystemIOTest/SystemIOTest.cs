using System;
using Xunit;
using Lab03SystemIO;
using static Lab03SystemIO.Program;
using System.IO;

namespace SystemIOTest
{
    public class UnitTest1
    {
        [Fact]
        public void FileCreated()
        {
            string path = "../../../myfile.txt";

            CreateFile(path);
            Assert.True(File.Exists("../../../myfile.txt"));
        }

        [Fact]
        public void FileAppenededAddWord()
        {
            string path = "../../../myfile.txt";
    
            AppendToFile(path, "test1");
            Assert.Contains("test1", ReadFile(path));
        }

        [Fact]
        public void FileAppenededDeletedWord()
        {
            string path = "../../../myfile.txt";

            DeleteLineFromFile(path, "2");
            Assert.DoesNotContain("Microsoft", ReadFile(path));
        }
    }
}
