using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.IO;

namespace PinterestUnitTest_31_Minh
{
    [TestClass]
    public class PinterestUnitTest_31_Minh
    {
        private IWebDriver driver_31_Minh;

        //Địa chỉ trang web
        private string url_31_Minh = "https://www.pinterest.com/";

        //Tên tài khoản
        private string email_31_Minh = "ducminh2004@gmail.com";

        //Mật khẩu
        private string password_31_Minh = "minhpro123";

        //Tên người dùng
        private string username_31_Minh = "Ducminh";

        //Từ khóa
        private string keySearch_31_Minh = "Cat";

        //Đường dẫn hình ảnh
        private string link_31_Minh = "https://pin.it/";

        [TestInitialize]
        public void SetUp_31_Minh()
        {
            //Khởi tạo đối tượng ChromeDriver
            driver_31_Minh = new ChromeDriver();

            ChromeDriverService chrome_31_Minh = ChromeDriverService.CreateDefaultService();

            //Đóng Command Prompt khi thực thi kiểm thử
            chrome_31_Minh.HideCommandPromptWindow = true;

            //Mở trình duyệt ở chế độ toàn màn hình
            driver_31_Minh.Manage().Window.Maximize();
        }

        //Test case 1: Đăng nhập với thông tin hợp lệ
        //email_31_Minh = 'ducminh2004@gmail.com'
        //password_31_Minh = 'minhpro123'
        [TestMethod]
        public void TC1_LoginAccountSuccess_31_Minh()
        {
            //Điều hướng trình duyệt tới trang web
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.Eqh.Jea.KS5.s7I.zI7.iyn.Hsu > div.H-G.zI7.iyn.Hsu > button")).Click();
            Thread.Sleep(10000);

            //Điền tên đăng nhập vào ô "Email" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("email")).SendKeys(email_31_Minh);

            //Điền mật khẩu vào ô "Password" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("password")).SendKeys(password_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút submit "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào "Hồ sơ của bạn" bằng cách sử dụng FindElement XPath
            driver_31_Minh.FindElement(By.XPath("//*[@id=\"HeaderContent\"]/div/div/div[2]/div/div/div/div[2]/div/div/div/a")).Click();
            Thread.Sleep(10000);

            //Tìm kiếm và lấy tên người dùng hiện tại bằng cách sử dụng FindElement XPath
            IWebElement currentUser_31_Minh = driver_31_Minh.FindElement(By.XPath("//*[@id=\"__PWS_ROOT__\"]/div[1]/div/div[2]/div/div/div/div/div[1]/div/div[1]/div[1]/div[2]/div/div[2]/div[1]/div"));

            //Chuyển kiểu dữ liệu của currentUser_31_Minh thành string
            string actualUserName_31_Minh = currentUser_31_Minh.Text;

            //So sánh kết quả mong muốn (username_31_Minh) và kết quả thực tế (actualUserName_31_Minh)
            Assert.AreEqual(username_31_Minh, actualUserName_31_Minh, "Đăng nhập thất bại");

        }

        //Test case 2: Đăng nhập với mật khẩu sai
        //email_31_Minh = 'ducminh2004@gmail.com'
        //password_31_Minh = 'minhpro321'
        [TestMethod]
        public void TC2_LoginAccountWrongPassword_31_Minh()
        {
            //Điều hướng trình duyệt tới trang web
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.Eqh.Jea.KS5.s7I.zI7.iyn.Hsu > div.H-G.zI7.iyn.Hsu > button")).Click();
            Thread.Sleep(10000);

            //Điền tên đăng nhập vào ô "Email" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("email")).SendKeys(email_31_Minh);

            //Điền mật khẩu vào ô "Password" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("password")).SendKeys(password_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút submit "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(10000);

            //Tìm kiếm và lấy thông báo mật khẩu không đúng bằng cách sử dụng FindElement CSS Selector
            IWebElement error_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#password-error > div > div > div:nth-child(2)"));

            //Chuyển kiểu dữ liệu của error_31_Minh thành string
            string errorMessage_31_Minh = error_31_Minh.Text;

            //So sánh kết quả thực tế (errorMessage_31_Minh) giống kết quả mong muốn ("The password you entered is incorrect.")
            Assert.IsTrue(errorMessage_31_Minh.Contains("The password you entered is incorrect."));
        }

        //Test case 3: Đăng nhập với Email không tồn tại
        //email_31_Minh = 'minhzzzzzz@gmail.com'
        //password_31_Minh = ''
        [TestMethod]
        public void TC3_LoginAccountNonExistentEmail_31_Minh()
        {
            //Điều hướng trình duyệt tới trang web
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.Eqh.Jea.KS5.s7I.zI7.iyn.Hsu > div.H-G.zI7.iyn.Hsu > button")).Click();
            Thread.Sleep(10000);

            //Điền tên đăng nhập vào ô "Email" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("email")).SendKeys(email_31_Minh);

            //Điền mật khẩu vào ô "Password" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("password")).SendKeys(password_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút submit "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(10000);

            //Tìm kiếm và lấy thông báo Email không tồn tại bằng cách sử dụng FindElement CSS Selector
            IWebElement error_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#email-error > div > div > div:nth-child(2)"));

            //Chuyển kiểu dữ liệu của error_31_Minh thành string
            string errorMessage_31_Minh = error_31_Minh.Text;

            //So sánh kết quả thực tế (errorMessage_31_Minh) giống kết quả mong muốn ("The email you entered does not belong to any account.")
            Assert.IsTrue(errorMessage_31_Minh.Contains("The email you entered does not belong to any account."));
        }

        //Test case 4: Đăng nhập với Email không hợp lệ
        //email_31_Minh = 'ducminh2004gmail.com'
        //password_31_Minh = 'minhpro123'
        [TestMethod]
        public void TC4_LoginAccountInvalidEmail_31_Minh()
        {
            //Điều hướng trình duyệt tới trang web
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.Eqh.Jea.KS5.s7I.zI7.iyn.Hsu > div.H-G.zI7.iyn.Hsu > button")).Click();
            Thread.Sleep(10000);

            //Điền tên đăng nhập vào ô "Email" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("email")).SendKeys(email_31_Minh);

            //Điền mật khẩu vào ô "Password" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("password")).SendKeys(password_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút submit "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(10000);

            //Tìm kiếm và lấy thông báo Email không hợp lệ bằng cách sử dụng FindElement CSS Selector
            IWebElement error_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#email-error > div > div > div:nth-child(2)"));

            //Chuyển kiểu dữ liệu của error_31_Minh thành string
            string errorMessage_31_Minh = error_31_Minh.Text;

            //So sánh kết quả thực tế (errorMessage_31_Minh) giống kết quả mong muốn ("Hmm...that doesn't look like an email address.")
            Assert.IsTrue(errorMessage_31_Minh.Contains("Hmm...that doesn't look like an email address."));

        }

        //Test case 5: Để trống thông tin đăng nhập
        //email_31_Minh = ''
        //password_31_Minh = ''
        [TestMethod]
        public void TC5_LoginAccountEmptyFields_31_Minh()
        {
            //Điều hướng trình duyệt tới trang web
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.Eqh.Jea.KS5.s7I.zI7.iyn.Hsu > div.H-G.zI7.iyn.Hsu > button")).Click();
            Thread.Sleep(10000);

            //Điền tên đăng nhập vào ô "Email" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("email")).SendKeys(email_31_Minh);

            //Điền mật khẩu vào ô "Password" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("password")).SendKeys(password_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút submit "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(10000);

            //Tìm kiếm và lấy thông báo không hợp lệ bằng cách sử dụng FindElement CSS Selector
            IWebElement error_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#email-error > div > div > div:nth-child(2)"));

            //Chuyển kiểu dữ liệu của error_31_Minh thành string
            string errorMessage_31_Minh = error_31_Minh.Text;

            //So sánh kết quả thực tế (errorMessage_31_Minh) giống kết quả mong muốn ("You missed a spot! Don't forget to add your email.")
            Assert.IsTrue(errorMessage_31_Minh.Contains("You missed a spot! Don't forget to add your email."));

        }

        //Test case 6: Đăng nhập và tải hình ảnh về thành công
        //keySearch_31_Minh = 'Cat'
        //email_31_Minh = 'ducminh2004@gmail.com'
        //password_31_Minh = 'minhpro123'
        [TestMethod]
        public void TC6_LoginAndSearchImageAndDownload_31_Minh()
        {
            //Điều hướng trình duyệt tới trang web
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.Eqh.Jea.KS5.s7I.zI7.iyn.Hsu > div.H-G.zI7.iyn.Hsu > button")).Click();
            Thread.Sleep(10000);

            //Điền tên đăng nhập vào ô "Email" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("email")).SendKeys(email_31_Minh);

            //Điền mật khẩu vào ô "Password" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("password")).SendKeys(password_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút submit "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(10000);

            //Tìm kiếm ô "Tìm kiếm" bằng cách sử dụng FindElement Name
            IWebElement searchImage_31_Minh = driver_31_Minh.FindElement(By.Name("searchBoxInput"));
            //Điền tên hình ảnh muốn tìm
            searchImage_31_Minh.SendKeys(keySearch_31_Minh);
            Thread.Sleep(10000);

            //Mô phỏng nhấn phím Enter trên bàn phím
            new Actions(driver_31_Minh).KeyDown(Keys.Enter).Build().Perform();
            Thread.Sleep(10000);

            //Đường dẫn của ảnh trong máy khi được tải về 
            string downloadsPath_31_Minh = "C:\\Users\\Tran Nguyen Duc Minh\\Downloads";

            //Đếm số lượng tập tin trong thư mục trước khi tải ảnh về
            int initialFileCount_31_Minh = Directory.GetFiles(downloadsPath_31_Minh).Length;
            Thread.Sleep(10000);

            //Tìm kiếm và click vào bức ảnh đầu tiên bằng cách sử dụng FindElement XPath
            IWebElement firstImage_31_Minh = driver_31_Minh.FindElement(By.XPath("//*[@id=\"__PWS_ROOT__\"]/div[1]/div/div[2]/div/div/div[4]/div/div/div/div/div[2]/div/div/div/div[1]/div[1]"));
            firstImage_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "..." bằng cách sử dụng FindElement CSS Selector
            IWebElement seeMore_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#gradient > div > div > div.ujU.zI7.iyn.Hsu > div > div > div > div > div > " +
                "div > div > div > div > div.Jea.jzS.zI7.iyn.Hsu > div:nth-child(1) > div > div > div > div.DUt.Jea.KS5.b8T.imm.zI7.iyn.Hsu > div > div:nth-child(3) > " +
                "div > div > div > div > div > div > div > div > div > button > div > div"));
            seeMore_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Tải xuống hình ảnh" bằng cách sử dụng FindElement CSS Selector
            IWebElement btnDownload_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#pin-action-dropdown-item-0"));
            btnDownload_31_Minh.Click();
            Thread.Sleep(10000);

            //Đếm số lượng tập tin trong thư mục sau khi tải ảnh về
            int currentFileCount_31_Minh = Directory.GetFiles(downloadsPath_31_Minh).Length;

            //So sánh kết quả mong muốn (1) và kết quả thực tế (currentFileCount_31_Minh - initialFileCount_31_Minh)
            Assert.AreEqual(1, currentFileCount_31_Minh - initialFileCount_31_Minh, "Chỉ nên tải xuống 1 ảnh");
        }

        //Test case 7: Tải hình ảnh xuống khi không đăng nhập
        //keySearch_31_Minh = 'Cat'
        [TestMethod]
        public void TC7_SearchImageAndDownload_31_Minh()
        {
            //Điều hướng trình duyệt tới trang web
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào "Explore" bằng cách sử dụng FindElement CSS Selector
            IWebElement explore_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.KS5.hs0.un8.C9i.TB_ > div.Eqh.fev.zI7.iyn.Hsu > a > div > div"));
            explore_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm ô "Tìm kiếm" bằng cách sử dụng FindElement Name
            IWebElement searchImage_31_Minh = driver_31_Minh.FindElement(By.Name("searchBoxInput"));
            //Điền tên hình ảnh muốn tìm
            searchImage_31_Minh.SendKeys(keySearch_31_Minh);
            Thread.Sleep(10000);

            //Mô phỏng nhấn phím Enter trên bàn phím
            new Actions(driver_31_Minh).KeyDown(Keys.Enter).Build().Perform();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào bức ảnh đầu tiên bằng cách sử dụng FindElement CSS Selector
            IWebElement firstImage_31_Minh = driver_31_Minh.FindElement(By.CssSelector("div[data-test-id=\"pin\"]"));
            firstImage_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "..." bằng cách sử dụng FindElement CSS Selector
            IWebElement seeMore_31_Minh = driver_31_Minh.FindElement(By.CssSelector("div[data-test-id=\"ellipsis-button\"]"));
            seeMore_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Download image" bằng cách sử dụng FindElement CSS Selector
            IWebElement btnDownload_31_Minh = driver_31_Minh.FindElement(By.Id("desktop-context-menu-item-0"));
            btnDownload_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm thông báo yêu cầu đăng nhập để tải ảnh bằng cách sử dụng FindElement XPath
            IWebElement request_31_Minh = driver_31_Minh.FindElement(By.XPath("//*[@id=\"__PWS_ROOT__\"]/div[1]/div[4]/div/div/div/div/div[1]/div[3]/h1"));
            //Chuyển kiểu dữ liệu của request_31_Minh thành string
            string requestLogin_31_Minh = request_31_Minh.Text;

            Assert.AreEqual(requestLogin_31_Minh, "Sign up to download");
        }

        //Test case 8: Kiểm tra link hợp lệ khi đăng nhập và chia sẻ hình ảnh bằng cách copy link
        //keySearch_31_Minh = 'Cat'
        //email_31_Minh = 'ducminh2004@gmail.com'
        //password_31_Minh = 'minhpro123'
        [TestMethod]
        public void TC8_LoginAndShareLinkImage_31_Minh()
        {
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh); //Điều hướng trình duyệt tới trang web
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.Eqh.Jea.KS5.s7I.zI7.iyn.Hsu > div.H-G.zI7.iyn.Hsu > button")).Click();
            Thread.Sleep(10000);

            //Điền tên đăng nhập vào ô "Email" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("email")).SendKeys(email_31_Minh);
            //Điền mật khẩu vào ô "Password" bằng cách sử dụng FindElement Id
            driver_31_Minh.FindElement(By.Id("password")).SendKeys(password_31_Minh);
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút submit "Log in" bằng cách sử dụng FindElement CSS Selector
            driver_31_Minh.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(10000);

            //Tìm kiếm ô "Tìm kiếm" bằng cách sử dụng FindElement Name
            IWebElement searchImage_31_Minh = driver_31_Minh.FindElement(By.Name("searchBoxInput"));
            //Điền tên hình ảnh muốn tìm
            searchImage_31_Minh.SendKeys(keySearch_31_Minh);
            Thread.Sleep(10000);

            //Mô phỏng nhấn phím Enter trên bàn phím
            new Actions(driver_31_Minh).KeyDown(Keys.Enter).Build().Perform();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào bức ảnh đầu tiên bằng cách sử dụng FindElement CSS Selector
            IWebElement firstImage_31_Minh = driver_31_Minh.FindElement(By.CssSelector("div[data-test-id=\"pin\"]"));
            firstImage_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Share" bằng cách sử dụng FindElement CSS Selector
            IWebElement btnShare_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#gradient > div > div > div.ujU.zI7.iyn.Hsu > div > div > div > div > div > div > div > div > " +
                "div > div.Jea.jzS.zI7.iyn.Hsu > div.qiB > div > div > div > div.DUt.Jea.KS5.b8T.imm.zI7.iyn.Hsu > div > div:nth-child(2) > " +
                "div > div > div > div > div > button > div > div > svg"));
            btnShare_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Copy link" bằng cách sử dụng FindElement XPath
            IWebElement copy_31_Minh = driver_31_Minh.FindElement(By.XPath("//*[@id=\"gradient\"]/div/div/div[2]/div/div/div/div/div/div/div/div/div/div[2]/div[1]/div/div/div/div[1]/div/div[2]/div[2]/div/div/div/div/div/div[2]/div[1]/div/div/div[1]/div/div[1]/div/div/button/div/div"));
            copy_31_Minh.Click();
            Thread.Sleep(10000);

            //Ép kiểu driver thành IJavaScriptExecutor (một interface của Selenium cho phép thực thi JavaScript trong trình duyệt)
            IJavaScriptExecutor drv_31_Minh = (IJavaScriptExecutor)driver_31_Minh;
            //Đọc dữ liệu đã được sao chép từ clipboard (bộ nhớ tạm của hệ điều hành) bằng API của JavaScript (return navigator.clipboard.readText();) rồi gán cho copiedLink
            string copiedLink_31_Minh = drv_31_Minh.ExecuteScript("return navigator.clipboard.readText();").ToString();

            //So sánh kết quả mong muốn (copiedLink_31_Minh) và kết quả thực tế (link_31_Minh)
            Assert.IsTrue(copiedLink_31_Minh.StartsWith(link_31_Minh), "Link không khớp");
        }

        //Test case 9: Kiểm tra link hợp lệ khi chia sẻ hình ảnh bằng cách copy link mà không đăng nhập
        //keySearch_31_Minh = 'Cat'
        [TestMethod]
        public void TC9_ShareLinkImage_31_Minh()
        {
            driver_31_Minh.Navigate().GoToUrl(url_31_Minh); //Điều hướng trình duyệt tới trang web
            Thread.Sleep(10000);

            //Tìm kiếm và click vào "Explore" bằng cách sử dụng FindElement CSS Selector
            IWebElement explore_31_Minh = driver_31_Minh.FindElement(By.CssSelector("#__PWS_ROOT__ > div:nth-child(3) > div:nth-child(2) > div.QLY._he.p6V.zI7.iyn.Hsu > div > div.KS5.hs0.un8.C9i.TB_ > div.Eqh.fev.zI7.iyn.Hsu > a > div > div"));
            explore_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm ô "Tìm kiếm" bằng cách sử dụng FindElement Name
            IWebElement searchImage_31_Minh = driver_31_Minh.FindElement(By.Name("searchBoxInput"));
            //Điền tên hình ảnh muốn tìm
            searchImage_31_Minh.SendKeys(keySearch_31_Minh);
            Thread.Sleep(10000);

            //Mô phỏng nhấn phím Enter trên bàn phím
            new Actions(driver_31_Minh).KeyDown(Keys.Enter).Build().Perform();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào bức ảnh đầu tiên bằng cách sử dụng FindElement CSS Selector
            IWebElement firstImage_31_Minh = driver_31_Minh.FindElement(By.CssSelector("div[data-test-id=\"pin\"]"));
            firstImage_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Share" bằng cách sử dụng FindElement CSS Selector
            IWebElement btnShare_31_Minh = driver_31_Minh.FindElement(By.CssSelector("div[data-test-id=\"share-button\"]"));
            btnShare_31_Minh.Click();
            Thread.Sleep(10000);

            //Tìm kiếm và click vào nút "Copy link" bằng cách sử dụng FindElement CSS Selector
            IWebElement copy_31_Minh = driver_31_Minh.FindElement(By.CssSelector("div[data-test-id=\"copy-link-share-icon\"]"));
            copy_31_Minh.Click();
            Thread.Sleep(10000);

            //Ép kiểu driver thành IJavaScriptExecutor (một interface của Selenium cho phép thực thi JavaScript trong trình duyệt)
            IJavaScriptExecutor drv_31_Minh = (IJavaScriptExecutor)driver_31_Minh;
            //Đọc dữ liệu đã được sao chép từ clipboard (bộ nhớ tạm của hệ điều hành) bằng API của JavaScript (return navigator.clipboard.readText();) rồi gán cho copiedLink
            string copiedLink_31_Minh = drv_31_Minh.ExecuteScript("return navigator.clipboard.readText();").ToString();

            //So sánh kết quả mong muốn (copiedLink_31_Minh) và kết quả thực tế (link_31_Minh)
            Assert.IsTrue(copiedLink_31_Minh.StartsWith(link_31_Minh), "Link không khớp");
        }

        [TestCleanup]
        public void Quit()
        {
            //Đóng tất cả cửa sổ liên kết
            driver_31_Minh.Quit();
        }
    }
}
