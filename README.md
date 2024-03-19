This was done for the Moonrail Limited | CSGOEmpire knowledge assesment.

The answer for the Question 1 ("How would you approach the testing of roulette? Describe the tests that you would do and the things you'd pay attention to.") can be found in the Question1.txt file in the repo.

You will find the Automation tests in the CSGOEmpireTests folder. They were written in C# using Selenium framework with NUnit. Additional NuGet packages were installed: DotNetSeleniumExtras.PageObjects, DotNetSeleniumExtras.PageObjects.Core, DotNetSeleniumExtras.WaitHelpers, WebDriverManager.
When you open the solution, you will see that there are 3 folders:
- PageObjects folder contains locators for each page (in this case only locators for RoulettePage).
- Test folder, as name suggests, contains the autotests, also per page basis(in this case only locators for RoulettePage).
- Utilities folder contains two classes. Base class contains [SetUp] and [TearDown] instructions - what happens before and after each test. Helper class is used for creating common functionalities frequently used across the tests.

In case you have any further questions, please reach out via the email.
Looking forward to your response!
