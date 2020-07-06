using NUnit.Framework;
using QLDienThoai;

namespace dttest
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
            string dc = "025-thien ho duong-thu duc-tphcm";
            Address a = Address.docFileDiaChi(dc);
            string dcs = $"-  so 025, duong thien ho duong, quan thu duc, thanh pho tphcm.";
            Assert.AreEqual(dcs, a.ToString());
        }
        [Test]
        public void Test2()
        {
            string dc = "025-thien ho duong-thu duc-tphcm";
            Address a = new Address("025", "thien ho duong", "thu duc", "tphcm");
            string dcs = $"-  so 025, duong thien ho duong, quan thu duc, thanh pho tphcm.";
            Assert.AreEqual(dc, a.xuatFileDiaChi());
        }
        [Test]
        public void Test3()
        {
           
        }
    }
}