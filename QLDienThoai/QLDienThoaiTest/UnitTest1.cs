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

        //[Test]
        //public void Test1()
        //{
        //    string result = "-  Ngan hang: dong a\n-  So tai khoan: 0111155390";
        //    ATM aTM = new ATM("0111155390", "dong a");
        //    Assert.AreEqual(result,aTM.ToString());
        //}
        //[Test]
        //public void Test2()
        //{
        //    string result = "-  Ngan hang: Unknow\n-  So tai khoan: Unknow";
        //    ATM aTM = new ATM("", "");
        //    Assert.AreEqual(result, aTM.ToString());
        //}
        //[Test]
        //public void Test3()
        //{
        //    string result = "-  Ngan hang: Unknow\n-  So tai khoan: Unknow";
        //    ATM aTM = new ATM(null, null);
        //    Assert.AreEqual(result, aTM.ToString());
        //}
        //[Test]
        //public void Test4()
        //{
        //    int[] result = { 1, 2 };
        //    List<int> arr = new List<int>(2);
        //    arr.Arr[0] = result[0];
        //    arr.Arr[1] = result[1];
        //    Assert.AreEqual(arr.Arr, result);
        //}
        [Test]
        public void TestConstructor1()
        {
            List l = new List();
            Assert.AreEqual(l.Capacity, 0);
            Assert.AreEqual(l.Size, 0);
        }
        [Test]
        public void TestConstructor2()
        {
            List l = new List(2);
            Assert.AreEqual(l.Capacity, 2);
            Assert.AreEqual(l.Size, 0);
        }
        [Test]
        public void TestIsEmply()
        {
            //int[] arr = { 1, 2, 3, 4 };
            List l = new List(2);
            Assert.AreEqual(true, l.IsEmple());
        }
        [Test]
        public void TestIsFull1()
        {
            //int[] arr = { 1, 2, 3, 4 };
            List l = new List(2);
            Assert.AreEqual(false, l.IsFull());
        }
        [Test]
        public void TestIsFull2()
        {
            //int[] arr = { 1, 2, 3, 4 };
            List l = new List(2);
            l.Add(1);
            l.Add(2);
            l.Add(4);
            Assert.AreEqual(true, l.IsFull());
        }
        [Test]
        public void TestAdd1()
        {
            int[] arr = { 1, 2, 3, 4 };
            List l = new List(2);
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            Assert.AreEqual(arr, l.ToArray());
        }
        [Test]
        public void TestAdd2()
        {
            string[] arr = { "1", "2", "3", "4" };
            List l = new List(2);
            l.Add("1");
            l.Add(1);
            l.Add("3");
            l.Add(true);
            Assert.AreEqual("1", l.GetIndex(0));
            Assert.AreEqual(1, l.GetIndex(1));
            Assert.AreEqual("3", l.GetIndex(2));
            Assert.AreEqual(true, l.GetIndex(3));
        }
        [Test]
        public void TestInsert()
        {
            int[] arr = { 1, 2, 3, 4 };
            List l = new List(4);
            l.Insert(0, 1);
            l.Insert(1, 2);
            l.Insert(2, 3);
            l.Insert(3, 4);
            Assert.AreEqual(arr, l.ToArray());
        }
        [Test]
        public void TestRemove()
        {
            int[] arr = { 1, 2, 3};
            List l = new List(4);
            l.Insert(0, 1);
            l.Insert(1, 2);
            l.Insert(2, 3);
            l.Insert(3, 4);
            l.Remove(4);
            Assert.AreEqual(arr, l.ToArray());
            l.Remove(3);
            arr =new int[] {1,2 };
            Assert.AreEqual(arr, l.ToArray());
        }
        [Test]
        public void TestContent()
        {
            int[] arr = { 1, 2, 3, 4 };
            List l = new List(4);
            l.Insert(0, 1);
            l.Insert(1, "2");
            l.Insert(2, 3);
            l.Insert(3, 4);
            Assert.AreEqual(true,l.Content("2"));
        }
    }
}