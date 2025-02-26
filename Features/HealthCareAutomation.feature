Feature: Verificaiton of Title Verification for page

  @ui_scenario
  Scenario: Verify Health Care Homepage Title
    Given I open the health care homepage
    When user clicks on button with id "btn-make-appointment"
    And user fills input box with id "txt-username" and value "John Doe"
    And user fills input box with id "txt-password" and value "ThisIsNotAPassword"
    And user clicks on button with id "btn-login"
    And user clicks on dropdown with id "combo_facility" and selects "Hongkong CURA Healthcare Center"
    And user clicks on checkbox or radio button with id "chk_hospotal_readmission"
    And user clicks on checkbox or radio button with id "radio_program_medicaid"
    And user select today date from input id "txt_visit_date"
    And user fills input box with id "txt_comment" and value "This is a test comment"
    And user clicks on checkbox or radio button with id "btn-book-appointment"
    Then user should see text "Appointment Confirmation" is present on the page
    When user clicks on a tag that contains text "Go to Homepage"
    Then page title should be "CURA Healthcare Service"