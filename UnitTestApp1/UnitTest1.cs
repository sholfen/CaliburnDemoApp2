using System;
using Caliburn.Micro;
using CaliburnDemoApp2;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.UI.Xaml.Controls;

namespace UnitTestApp1
{
    [TestClass]
    public class UnitTest1
    {
        private string initStr;
        //private INavigationService navigation;
        private WinRTContainer _container;
        [TestInitialize]
        public void Init()
        {
            this.initStr = "aaa3";
            this._container = new WinRTContainer();  
        }

        [TestCleanup]
        public void CleanUp()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            
            Assert.AreEqual(true, true);
            Assert.AreEqual(this.initStr, "aaa3");
        }

        [TestMethod]
        public void TestMethod2()
        {
            MainPageViewModel model = new MainPageViewModel(null);
            int result = model.Add(3, 4);
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod3()
        {
            MainPageViewModel model = Caliburn.Micro.IoC.Get<MainPageViewModel>();
            int result = model.Add(3, 4);
            //Assert.AreEqual(result, 9);
            model.GoToSecondPage();
        }

        [TestMethod]
        public void TestMethod4()
        {
            MainPage page = new MainPage();
            Button button = page.FindName("VisibleButton") as Button;
            
        }
    }
}
