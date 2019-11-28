using NUnit.Framework;

namespace Zephyr.DotsExperiments.Tests
{
    public struct StructWithInt
    {
        public int Id;
    }
    
    public class TestStruct : TestBase
    {
        private StructWithInt ChangeId(StructWithInt str, int newId)
        {
            str.Id = newId;
            return str;
        }

        private void ChangeId(ref StructWithInt str, int newId)
        {
            str.Id = newId;
        }
        
        [Test]
        public void Assignment_IsCopy()
        {
            var str0 = new StructWithInt{Id = 0};
            var str1 = str0;
            str1.Id = 1;
            
            Assert.AreEqual(0, str0.Id);
            Assert.AreEqual(1, str1.Id);
        }

        [Test]
        public void PassParameterToMethod_IsCopy()
        {
            var str0 = new StructWithInt{Id = 0};
            var str1 = ChangeId(str0, 1);
            
            Assert.AreEqual(0, str0.Id);
            Assert.AreEqual(1, str1.Id);
        }

        [Test]
        public void RefParameterToMethod_IsRef()
        {
            var str0 = new StructWithInt{Id = 0};
            ChangeId(ref str0, 1);
            
            Assert.AreEqual(1, str0.Id);
        }
    }

}