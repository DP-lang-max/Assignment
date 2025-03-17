# TechnicalTask

## Overview
This project contains automated tests for the TechnicalTask application. The tests are written in C# using the NUnit framework and cover both API and UI functionalities.

## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or later
- Chrome WebDriver (if running UI tests)

## Setup
1. Clone the repository:
   https://github.com/DP-lang-max/Assignment
2. Restore the NuGet packages:
   dotnet restore
   
## Running the Tests
### Using Visual Studio
1. Open the solution in Visual Studio.
2. Build the solution to ensure all dependencies are resolved.
3. Open the Test Explorer (Test > Test Explorer).
4. Click "Run All" to execute all tests.

### Using .NET CLI
1. Open a terminal and navigate to the project directory.
2. Run the following command to execute all tests:
   dotnet test

## Project Structure
- `TechnicalTask/API/ApiClient.cs`: Contains the API client for interacting with the backend.
- `TechnicalTask/Pages/DragAndDropPage.cs`: Contains the page object model for the Drag and Drop page.
- `TechnicalTask/Tests/ApiTests.cs`: Contains the API tests.
- `TechnicalTask/Tests/DragAndDropTest.cs`: Contains the UI tests for drag and drop functionality.

## Logging
The project uses NLog for logging. Logs are written to the console and can be configured in the `NLog.config` file.

## Dependencies
- [NUnit](https://nunit.org/): Test framework for .NET.
- [RestSharp](https://restsharp.dev/): Simple REST and HTTP API client for .NET.
- [Selenium.WebDriver](https://www.selenium.dev/): Browser automation framework.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

 

   
