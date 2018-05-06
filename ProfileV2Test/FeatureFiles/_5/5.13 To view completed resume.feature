#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43419602
#|Role     |name                     |surname              |e-mail                    |password      |phone number     |
#|student  |Brea                     |Breens               |breabreens555@gmail.com   |brea123456    |+375 25 784 55 66|

 Feature: 5.13 To view completed resume
    In order I can check view of my resume
    As authorized user
    I should have possibility to view my completed resume

 Background:
    Given As unauthorised user I come to landing page of Profile
    And I log in as Brea Breens
    And I open my personal menu
    And I select button "Resume"

 Scenario: Student can see congratulation message
    Given I press "NEXT" button in block "Recommendations"
    Then I see congratulation message
    |Message                                        |
    |Congratulations!                               |
    |You have just finished to fill in your resume. |
    |Please check you resume                        |
    |before you submit it to our HR.                |

 Scenario: Student can check resume page
    When I am on congratulation message page
    Then I see button "BACK"
    And I see button "CHECK"

Scenario: Student Checks information
Given I see congratulation message
When I press button "CHECK"
Then I am on completed resume page
And I see information I entered while filling in resume blocks

 Scenario: Student checks buttons
    When I press button "CHECK"
    Then I am on completed resume page
    And I see button "SUBMIT"
    And I see button "EDIT"
    And I see button "BACK"

 Scenario: Student Checks block “Personal and contact information” in completed resume
    Given I write “Brea” in field “Name” in block “Personal and contact information”
    And I write “Breens” in field “Surname” in block “Personal and contact information”
    And I write “+375 25 784 55 66” in field “Phone” in block “Personal and contact information”
    And I write “Breens_skype” in field “Skype” in block “Personal and contact information”
    And I write “Brea Breens” in field “Linkedin” in block “Personal and contact information”
    And I write “bla bla bla” in field “Summary” in block “Summary”
    And I write “Business English”, “Agile”, “HTML” in field “Skills” in block “Skills”
    And I choose “English” in field “Languages” in block “Foreign languages”
    And I choose “B2 Upper-Intermediate” in field “Proficiency” in block “Foreign languages”
    And I choose “Bachelor” in field “Level” in block “Education”
    And I write “Belarusian state university” in field “Name of educational institution” in block “Education”
    And I write “Marketing” in field “Department” in block “Education”
    And I write “Marketing in IT” in field “Specialization” in block “Education”
    And I choose “2009” in field “Year of admission” in block “Education”
    And I choose “2012” in field “Year of graduation” in block “Education”
    And I write “Educational center of HTP” in field “Responsible organization” in block “Professional development, courses”
    And I write “Business Analysis” in field “Specialization” in block “Professional development, courses”
    And I write “2016” in field “Year of graduation” in block “Professional development, courses”
    And I write “Streamline” in field “Responsible organization” in block “Electronic certificates”
    And I write “Business English” in field “Certificate title” in block “Electronic certificates”
    And I write “2014” in field “Year of attestation” in block “Electronic certificates”
    And I choose “June” and “2017” in field “Start of work” in block “Work experience”
    And I choose “To present” in field “Start of work” in block “Work experience”
    And I write “EPAM” in field “Organization” in block “Work experience”
    And I write “Marketing specialist” in field “Position” in block “Work experience”
    And I write “bla bla bla” in field “Responsibilities, tasks, activities” in block “Work experience”
    And I write “http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43419570” in field “Add a link” in block “Portfolio”
    And I choose “Doesn't apply” in block “Military status”
    And I write “bla bla bla” in field “Additional information” in block “Additional information”
    And I write “Maria Zaporoschenko” in field “Name Surname” in block “Recommendations”
    And I write “HR, IT-Academy” in field “Company/Position” in block “Recommendations”
    And I write “+375 29 123 45 67” in field “Contacts/Link” in block “Recommendations”
    When I am no completed resume page
    Then I see value of field "Name" equal "Brea" in block “Personal and contact information”
    And I see value of field "Surname" equal "Breens" in block “Personal and contact information”
    And I see value of field "Phone" equal “+375 25 784 55 66" in block “Personal and contact information”
    And I see value of field "Skype" equal "Breens_skype" in block “Personal and contact information”
    And I see value of field “Linkedin” equal “Brea Breens” in block “Personal and contact information”
    And I see value of field “I am applying for a position of” equal “Business Analyst” in block “Objective”
    And I see value of field “Summary” equal “bla bla bla” in block “Summary”
    And I see value of field “Skills” equal “Business English, Agile, HTML” in block “Skills”
    And I see value of field “Languages” equal “English” in block “Foreign languages”
    And I see value of field “Proficiency” equal “B2 Upper-Intermediate” in block “Foreign languages”
    And I see value of field “Year of admission” equal “2009” in block “Education”
    And I see value of field “Year of graduation” equal “2012” in block “Education”
    And I see value of field “Name of educational institution” equal “Belarusian state university” in block “Education”
    And I see value of field “Department” equal “Marketing” in block “Education”
    And I see value of field “Specialization” equal “Marketing” in block “Education”
    And I see value of field “Year of graduation” equal “2016” in block “Professional development, courses”
    And I see value of field “Responsible organization” equal “Educational center of HTP” in block “Professional development, courses”
    And I see value of field “Specialization” equal “Business Analysis” in block “Professional development, courses”
    And I see value of field “Year of attestation” equal “2014” in block “Electronic certificates”
    And I see value of field “Responsible organization” equal “Streamline” in block “Electronic certificates”
    And I see value of field “Certificate title” equal “Business English” in block “Electronic certificates”
    And I see value of field “Start of work” equal “June” and “2017” in block “Work experience”
    And I see value of field “Start of work” equal “To present” in block “Work experience”
    And I see value of field “Organization” equal “EPAM” in block “Work experience”
    And I see value of field “Position” equal “Marketing specialist” in block “Work experience”
    And I see value of field “Responsibilities, tasks, activities” equal “bla bla bla” in block “Work experience”
    And I see value of field “Add a link” equal “http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43419570” in block “Portfolio”
    And I see value equal “Doesn't apply” in block “Military status”
    And I see value of field “Additional information” equal “bla bla bla” in block “Additional information”
    And I see value of field “Name Surname” equal “Maria Zaporoschenko” in block “Recommendation”
    And I see value of field “Company/Position” equal “HR, IT-Academy” in block “Recommendation”
    And I see value of field “Contacts/Link” equal “+375 25 784 55 66” in block “Recommendation”

 Scenario: Student Checks LinkedIn link is clickable
    When I press LinkedIn link
    Then I see linked page

 Scenario: Student Checks electronic certificate link is clickable
    When I press electronic certificate link
    Then I see linked page

 Scenario: Student Checks portfolio link is clickable
    When I press portfolio link
    Then I see linked page

 Scenario: Student Checks Recommendation letter link is clickable
    When I press recommendation letter link
    Then I see linked page
    
@ignore
 Scenario: Student Checks resume blocks order
    When I am on completed resume page
    Then I see information in specific order 
    |number|resume block                     |lines                                                                       |
    |1     |Personal and contact information |Name Surname                                                                |
    |      |                                 |                                                                            |
    |      |                                 |Email icon+email                                                            |
    |      |                                 |Phone icon+phone                                                            |
    |      |                                 |Skype icon+Skype                                                            |
    |      |                                 |LinkedIn icon+LinkedIn                                                      |
    |2     |Objective                        |I am applying for a position of+#Stream_title                               |
    |3     |Summary                          |Summary                                                                     |
    |      |                                 |Text of summary                                                             |
    |4     |Skills                           |Skills                                                                      |
    |      |                                 |Tags                                                                        |
    |5     |Foreign languages                |Foreign languages                                                           |
    |      |                                 |Language+"-"+proficiency level                                              |
    |6     |Education                        |Education                                                                   |
    |      |                                 |Year of admission+"-"+year of graduation+","+Name of educational institution|
    |      |                                 |Specialization                                                              |
    |7     |Professional development, courses|Professional development, courses                                           |
    |      |                                 |Year of graduation+","+Name of the educational institution                  |
    |      |                                 |Specialization                                                              |
    |8     |Electronic certificates          |Electronic certificates                                                     |
    |      |                                 |Year of attestation+","+Name of the educational institution                 |
    |      |                                 |Certificate title                                                           |
    |      |                                 |link to certificate                                                         |
    |9     |Tests, examinations              |Year of attestation+","+Name of the educational institution                 |
    |      |                                 |Test/examination title                                                      |
    |10    |Work experience                  |Work experience                                                             |
    |      |                                 |Start of work+"-"+End of work+","+Name of the Organization                  |
    |      |                                 |Position title                                                              |
    |      |                                 |Responsibilities, tasks, activities                                         |
    |11    |Portfolio                        |Portfolio                                                                   |
    |      |                                 |link to certificate                                                         |
    |12    |Military status                  |Military status                                                             |
    |      |                                 |Status                                                                      |
    |13    |Additional information           |Additional information                                                      |
    |      |                                 |Text of additional information                                              |
    |14    |Recommendations                  |Recommendations                                                             |
    |      |                                 |Person who can give recommendation                                          |
    |      |                                 |Name Surname                                                                |
    |      |                                 |Company/Position                                                            |
    |      |                                 |Contacts/Link                                                               |