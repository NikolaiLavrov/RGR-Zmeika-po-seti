using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Tests
{
  [TestClass()]
  public class GameFormTests
  {
    [TestMethod()]
    public void GameFormTest()
    {
      GameForm gg = new GameForm();
      Assert.IsNotNull(gg);
    }  
  }
}
