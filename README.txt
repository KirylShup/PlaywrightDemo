# PlaywrightDemo. Small demo project for test automation tool Playwright. For C#.




1. Allure Reporting.

- Each test-class should has attribute [NunitAllure].
- In the project is palced JSON file "allureConfig" which contains property: "directory". On base of this property will be created folder with JSON files as results of test run.
- JSON "allureConfig" file in the project should be set to be copied in output directory always (can be done in properties of the file).
- To create XML report on the base of JSON files with results of run you should do next:
		a. Install "scoop" via PowerShell(command to execute in Shell: "iwr -useb get.scoop.sh | iex")
		b. Via "Scoop" you should be ale to install allure (command to execute in Shell: "scoop install allure")
		c. Command to PowerShell to generate report on base of results (command: "allure generate <directory-with-json-results> -o <directory-to-put-report>")
		d. Command to open generated report (command: "allure open <directory-with-generated-report>")

- It's always possible to add more different allure attributes to tests (cathegorize them, ignore, place into suites, etc.) and this will be shown in the report. But it's not necessary.