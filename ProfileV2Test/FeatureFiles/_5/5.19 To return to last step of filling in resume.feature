 Feature: 5.19 To return to last step of filling in resume
    In order I can finish to fill in my resume
    As Student
    I should have possibility to return to my last step in resume

 Scenario Outline: Student returns to last step of his resume
    Given As unauthorised user I come to landing page of Profile
    And I log in as '<student>'
    And I open my personal menu
    And I select button "Resume"
    And I start or continue filling in my resume
    And I pressed button “CANCEL” in '<block_name>'
    And I open my personal menu
    And I select button "Resume"
    Then I move to block '<block_name>'
    Examples:
    |option  |student        |block_name                           |
    |option2 |Pavel Jones    |Objective                            |
    |option3 |Nikola Brown   |Summary                              |
    |option4 |Vlad Davies    |Skills                               |
    |option5 |Victor Willians|Foreign languages                    |
    |option6 |Sveta Evans    |Education                            |
    |option7 |Nadejda Moore  |Professional development, courses    |
    |option8 |Lena Taylor    |Electronic certificates, tests, exams|
    |option9 |Emily Tomas    |Work experience                      |
    |option10|Sophie Miler   |Portfolio                            |
    |option11|Ruby Javovich  |Military status                      |
    |option12|Oliver Wilson  |Additional information               |
    |option13|Jack Daniel's  |Recommendations                      |