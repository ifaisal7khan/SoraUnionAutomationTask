Overview
This project is an automation framework built using ReqnRoll for both UI and API testing. It leverages Selenium for web automation and RestSharp for API testing, ensuring efficient and scalable test execution.

Prerequisites
Before running the tests, ensure that you have the following installed:

- Visual Studio (latest version recommended)
- NET SDK (compatible with ReqnRoll)
- ReqnRoll extension for Visual Studio
- Git (for cloning the repository)

Installation Steps
1. Clone the repository:
  git clone https://github.com/ifaisal7khan/SoraUnionAutomationTask.git
  cd SoraUnionAutomationTask
2. Install required dependencies:
Open the project in Visual Studio and install the following packages using NuGet Package Manager:

- ReqnRoll (for BDD test execution)
- NUnit (test framework)
- Selenium WebDriver (for UI automation)
- ReqnRoll.MsTest (for integrating ReqnRoll with MSTest)
- RestSharp (for API testing)

Once the project dependencies are installed
execute the scenarios through CMD "dotnet test"
or from top navigation click on Test -> Run All Tests
