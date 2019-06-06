using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;

namespace Server
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestServer()
    {
      Form1 fm = new Form1();
      Server.Player pl = new Server.Player(1,2);
      fm.ChangeWay(pl,pl.NextWay);
      Assert.IsTrue(fm.newWaysTest());
    }    

    
  }
}
