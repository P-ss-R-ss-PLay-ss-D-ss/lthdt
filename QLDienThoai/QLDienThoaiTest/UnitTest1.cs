using NUnit.Framework;
using QLDienThoai;
using System.Collections;

namespace QLDienThoai.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            string result = "-  Ngan hang: dong a\n-  So tai khoan: 0111155390";
            ATM aTM = new ATM("0111155390", "dong a");
            Assert.AreEqual(result,aTM.ToString());
        }
        [Test]
        public void Test2()
        {
            string result = "-  Ngan hang: Unknow\n-  So tai khoan: Unknow";
            ATM aTM = new ATM("", "");
            Assert.AreEqual(result, aTM.ToString());
        }
        [Test]
        public void Test3()
        {
            string result = "-  Ngan hang: Unknow\n-  So tai khoan: Unknow";
            ATM aTM = new ATM(null, null);
            Assert.AreEqual(result, aTM.ToString());
        }
        [Test]
        public void Test4()
        {
            int[] result = { 1, 2 };
            List<int> arr = new List<int>(2);
            arr.Arr[0] = result[0];
            arr.Arr[1] = result[1];
            Assert.AreEqual(arr.Arr, result);
        }
        [Test]
        public void Test5()
        {
            int[] result = { 1, 2 };
            List<int> arr = new List<int>();
            arr.Arr[0] = result[0];
            arr.Arr[1] = result[1];
            arr.Arr[2] = 2;
            Assert.AreEqual(result,arr.Arr);
        }
    }
}