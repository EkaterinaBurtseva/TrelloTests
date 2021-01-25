# General info
Test automation solution to verify https://petstore.swagger.io/#/

# Environment
* Nunit
* Specflow
* C#

# Additional plugins 
* Selenium
* RestSharp
* Allure

# Execution
* locally via IDE
* using next command
```
dotnet test
```

# TODO
* extend current test coverage
* add more detailed logging
* add more detailed configuration or/and change reporting to ExtentReport

# Reporting
* Allure report can be generated using in the allure location
```
allure serve
```

# Troubleshooting
- problems with building Specflow project.
Reinstall specflow dependencies and rebuild project.
- error during running tests in Selenium (ChromeDriver or Firefox Driver not found)
Make sure that /bin/Debug contains mentioned drivers
- error during execution allure report
Make /bin/Debug contains allure.json and nuget packages configured properly.

# Manual tests and plan
Located in /TrelloAssignment/TrelloAssignment/ManualActivities folder
