namespace CSGOEmpireTests.Tests
{
    public class RoulettePageTests : Base
    {
        [Test]
        public void VerifyPageTitle()
        {
            string expectedPageTitle = "CSGOEmpire | The most trusted CSGO Skin Gambling Site";
            string actualPageTitle = GetDriver().Title;
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle));
        }

        [Test]
        public void VerifyPageUrl()
        {
            //In case the site is hacked, give a 2sec time for redirect to happen to whatever page the hacker has set
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string expectedUrl = "https://csgoempire.com/roulette";
            string actualUrl = GetDriver().Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void CheckSignInButton()
        {
            GetRoulettePage().GetSignInButton().Click();
            string expectedUrl = "https://steamcommunity.com/openid/loginform";
            GetWait().Until(ExpectedConditions.UrlContains(expectedUrl));
            string actualUrl = GetDriver().Url;
            Assert.That(actualUrl, Does.Contain(expectedUrl));
        }

        [Test]
        public void CheckDepositButton()
        {
            GetRoulettePage().GetDepositButton().Click();
            string expectedUrl = "https://csgoempire.com/deposit";
            GetWait().Until(ExpectedConditions.UrlToBe(expectedUrl));
            string actualUrl = GetDriver().Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void CheckWithdrawButton()
        {
            GetRoulettePage().GetWithdrawButton().Click();
            string expectedUrl = "https://csgoempire.com/withdraw";
            GetWait().Until(ExpectedConditions.UrlToBe(expectedUrl));
            string actualUrl = GetDriver().Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void CheckSoundButtonOffAndOn()
        {
            GetRoulettePage().GetSoundOnButton().Click();
            Assert.IsTrue(GetRoulettePage().GetSoundOffButton().Displayed);
            GetRoulettePage().GetSoundOffButton().Click();
            Assert.IsTrue(GetRoulettePage().GetSoundOnButton().Displayed);
        }

        [Test]
        public void CheckPlacingBetOnCt()
        {
            string randomNumber = Helper.RandomNumber().ToString();
            GetRoulettePage().GetBetAmountInputField().SendKeys(randomNumber);
            double timerValue = 0;
            int timesTried = 0;
            while (timerValue == 0 && timesTried < 12) //timesTried is <12 because for every try we get 1 second, and I've noticed that the unclickability period on bets between the 2 rolls is usually around 8-9 seconds.
            {
                string timerValueString = GetRoulettePage().GetTimer().Text;

                if (!string.IsNullOrEmpty(timerValueString) && double.TryParse(timerValueString, out timerValue) && timerValue > 0)
                {
                    break;
                }

                Thread.Sleep(1000);
                timesTried++;
            }
            GetRoulettePage().GetPlaceBetOnCtButton().Click();
            GetWait().Until(ExpectedConditions.ElementIsVisible(GetRoulettePage().GetByPopUpSignInButton())); 
            Assert.IsTrue(GetRoulettePage().GetPopUpSignInButton().Displayed);
        }

        [Test]
        public void CheckPlacingBetOnDice()
        {
            string randomNumber = Helper.RandomNumber().ToString();
            GetRoulettePage().GetBetAmountInputField().SendKeys(randomNumber);
            double timerValue = 0;
            int timesTried = 0;
            while (timerValue == 0 && timesTried < 12)
            {
                string timerValueString = GetRoulettePage().GetTimer().Text;

                if (!string.IsNullOrEmpty(timerValueString) && double.TryParse(timerValueString, out timerValue) && timerValue > 0)
                {
                    break;
                }

                Thread.Sleep(1000);
                timesTried++;
            }
            GetRoulettePage().GetPlaceBetOnDiceButton().Click();
            GetWait().Until(ExpectedConditions.ElementIsVisible(GetRoulettePage().GetByPopUpSignInButton()));
            Assert.IsTrue(GetRoulettePage().GetPopUpSignInButton().Displayed);
        }

        [Test]
        public void CheckPlacingBetOnTerrorist()
        {
            string randomNumber = Helper.RandomNumber().ToString();
            GetRoulettePage().GetBetAmountInputField().SendKeys(randomNumber);
            double timerValue = 0;
            int timesTried = 0;
            while (timerValue == 0 && timesTried < 12)
            {
                string timerValueString = GetRoulettePage().GetTimer().Text;

                if (!string.IsNullOrEmpty(timerValueString) && double.TryParse(timerValueString, out timerValue) && timerValue > 0)
                {
                    break;
                }

                Thread.Sleep(1000);
                timesTried++;
            }
            GetRoulettePage().GetPlaceBetOnTerroristButton().Click();
            GetWait().Until(ExpectedConditions.ElementIsVisible(GetRoulettePage().GetByPopUpSignInButton()));
            Assert.IsTrue(GetRoulettePage().GetPopUpSignInButton().Displayed);
        }

        [Test]
        public void VerifyBetsContainersArePresent()
        {
            IList<IWebElement> betContainers = GetRoulettePage().GetBetContainers();
            Assert.That(betContainers.Count, Is.EqualTo(3));
            foreach(IWebElement container in betContainers)
            {
                Assert.IsTrue(container.Displayed);
            }
        }

        [Test]
        public void VerifyRaceTableIsPresent()
        {
            GetWait().Until(ExpectedConditions.ElementExists(GetRoulettePage().GetRaceTableLocator()));
            Assert.IsTrue(GetRoulettePage().GetRaceTable().Displayed);
            string actualTableName = GetRoulettePage().GetRaceTableName().Text;
            string expectedTableName = "Monthly Roulette Race";
            Assert.That(actualTableName, Is.EqualTo(expectedTableName));
        }

        [Test]
        public void VerifyRaceTableHasElevenRows()
        {
            GetWait().Until(ExpectedConditions.ElementExists(GetRoulettePage().GetRaceTableLocator()));
            IList<IWebElement> rows = GetRoulettePage().GetRaceTableRows();
            Console.WriteLine(rows);
            Assert.That(rows.Count, Is.EqualTo(11));
        }

        [Test]
        public void VerifyRaceTablePagination()
        {
            GetWait().Until(ExpectedConditions.ElementExists(GetRoulettePage().GetRaceTableLocator()));
            GetRoulettePage().GetRaceTablePageTwoButton().Click();
            IList<IWebElement> rows = GetRoulettePage().GetRaceTableRows();
            Assert.That(rows.Count, Is.EqualTo(11));
            Assert.That(GetRoulettePage().GetEleventhPlace().Displayed, Is.True);
            IList<IWebElement> places = GetRoulettePage().GetRaceTablePlaces();
            int counter = 11;
            Thread.Sleep(1000);
            for(int i = 1; i <= 10; i++)
            {
                string actualPlace = places[i].Text;
                string expectedPlace = counter + "th";
                Assert.That(actualPlace, Is.EqualTo(expectedPlace));
                counter++;
            }
        }
    }
}