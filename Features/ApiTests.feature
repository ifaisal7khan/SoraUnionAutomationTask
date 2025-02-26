Feature: Verificaiton of API Scenarios


@api_scenario
Scenario: Verify employee salary
  Given I call the employees API
  Then I verify that employee "Michael Silva" has a salary of 198500

@api_scenario
Scenario: Verify employee details by ID
  Given I call the employee API for ID 5
  Then I verify the response is valid
