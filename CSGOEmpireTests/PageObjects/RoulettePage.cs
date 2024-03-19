using SeleniumExtras.PageObjects;

namespace CSGOEmpireTests.PageObjects
{
    public class RoulettePage
    {
        private IWebDriver _driver;
        public RoulettePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "((//span[contains(text(),'Sign In')])/ancestor::button)[1]")]
        private IWebElement _signInButton;
        public IWebElement GetSignInButton() { return _signInButton; }

        [FindsBy(How = How.XPath, Using = "((//span[contains(text(), 'Deposit')])/ancestor::button)[1]")]
        private IWebElement _depositButton;
        public IWebElement GetDepositButton() { return _depositButton; }

        [FindsBy(How = How.XPath, Using = "((//span[contains(text(), 'Withdraw')])/ancestor::button)[1]")]
        private IWebElement _withdrawButton;
        public IWebElement GetWithdrawButton() { return _withdrawButton; }

        [FindsBy(How = How.XPath, Using = "(//span[contains(text(), 'Sound on')])/ancestor::button")]
        private IWebElement _soundOnButton;
        public IWebElement GetSoundOnButton() { return _soundOnButton; }

        [FindsBy(How = How.XPath, Using = "(//span[contains(text(), 'Sound off')])/ancestor::button")]
        private IWebElement _soundOffButton;
        public IWebElement GetSoundOffButton() { return _soundOffButton; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Enter bet amount...']")]
        private IWebElement _betAmountInputField;
        public IWebElement GetBetAmountInputField() { return _betAmountInputField; }

        [FindsBy(How = How.XPath, Using = "//img[@src='https://csgoempire.com/assets/coin-ct-G_G8dKtJ.png']/ancestor::button")]
        private IWebElement _placeBetOnCtButton;
        public IWebElement GetPlaceBetOnCtButton() { return _placeBetOnCtButton; }

        [FindsBy(How = How.XPath, Using = "//img[@src='https://csgoempire.com/assets/coin-t-lwGCCRZz.png']/ancestor::button")]
        private IWebElement _placeBetOnTerroristButton;
        public IWebElement GetPlaceBetOnTerroristButton() { return _placeBetOnTerroristButton; }

        [FindsBy(How = How.XPath, Using = "//img[@src='https://csgoempire.com/assets/coin-bonus-u3uE7Jsu.png']/ancestor::button")]
        private IWebElement _placeBetOnDiceButton;
        public IWebElement GetPlaceBetOnDiceButton() { return _placeBetOnDiceButton; }

        [FindsBy(How = How.CssSelector, Using = ".font-numeric.text-2xl.font-bold")]
        private IWebElement _timer;
        public IWebElement GetTimer() { return _timer; }

        [FindsBy(How = How.XPath, Using = "//div[@class='vfm__content']//button//span[contains(text(), 'Sign in')]")]
        private IWebElement _popUpSignInButton;
        public IWebElement GetPopUpSignInButton() { return _popUpSignInButton; }

        private By _byPopUpSignInButton = By.XPath("//div[@class='vfm__content']//button//span[contains(text(), 'Sign in')]");
        public By GetByPopUpSignInButton() { return _byPopUpSignInButton; }

        [FindsBy(How = How.CssSelector, Using = ".bets-container")]
        private IList<IWebElement> _betContainers;
        public IList<IWebElement> GetBetContainers() { return _betContainers; }

        [FindsBy(How = How.XPath, Using = "//div[@class='mb-lg px-lg -mx-lg mt-xxl']")]
        private IWebElement _raceTable;
        public IWebElement GetRaceTable() { return _raceTable; }

        private By _raceTableLocator = By.XPath("//div[@class='mb-lg px-lg -mx-lg mt-xxl']");
        public By GetRaceTableLocator() { return _raceTableLocator; }

        [FindsBy(How = How.XPath, Using = "//div[@class='mb-lg px-lg -mx-lg mt-xxl']//h3")]
        private IWebElement _raceTableName;
        public IWebElement GetRaceTableName() { return _raceTableName; }

        [FindsBy(How = How.XPath, Using = "//div[@class='mb-lg px-lg -mx-lg mt-xxl']//table/tr")]
        private IList<IWebElement> _raceTableRows;
        public IList<IWebElement> GetRaceTableRows() { return _raceTableRows; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), '2')]//ancestor::button[contains(@class, 'btn-tertiary')]")]
        private IWebElement _raceTablePageTwoButton;
        public IWebElement GetRaceTablePageTwoButton() { return _raceTablePageTwoButton; }

        [FindsBy(How = How.XPath, Using = "//p[normalize-space()='11th']")]
        private IWebElement _eleventhPlace;
        public IWebElement GetEleventhPlace() { return _eleventhPlace; }

        [FindsBy(How = How.XPath, Using = "//table[contains(@class, 'base-table')]/tr/td[1]//p")]
        private IList<IWebElement> _raceTablePlaces;
        public IList<IWebElement> GetRaceTablePlaces() { return _raceTablePlaces; }
    }
}
