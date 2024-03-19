namespace CSGOEmpireTests.Utilities
{
    public class Base
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;
        private RoulettePage _roulettePage;


        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://csgoempire.com/roulette";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _roulettePage = new RoulettePage(_driver);
        }

        public IWebDriver GetDriver() { return _driver; }
        public WebDriverWait GetWait() { return _wait; }
        public RoulettePage GetRoulettePage() { return _roulettePage; }

        [TearDown]
        public void AfterTest()
        {
            _driver.Quit();
        }
    }
}
