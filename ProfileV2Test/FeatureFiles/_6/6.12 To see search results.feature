#http://confluence.it-academy.by:8090/display/PROF/6.12+To+see+search+results

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To see search results
  In order I can find information I need
  As HR
  I should have possibility to see search results

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I stay on home page
Given I chose search options in Students table

Scenario: HR Starts search
 When I start to choose search option in another table column
 Then search filter is applied immediately

Scenario: HR Checks data in "№" column in search result table
 When I see column "№" in search result table
 Then I see Student's index number in list

Scenario: HR Ticks option in column "Choose" in search result table
 When I see column "Choose" in search result table
 Then I can tick option

Scenario: HR Checks data in "Stream" column in search result table
 When I see column "Stream" in search result table
 Then I see Stream information from database corresponding to the search option

Scenario: HR Checks data in "Name rus" column in search result table
 When I see column "Name rus" in search result table
 Then I see Name information from database

Scenario: HR Checks data in "Surname rus" column in search result table
 When I see column "Surname rus" in search result table
 Then I see Surname information from database

Scenario: HR Checks data in "Date of birth" column in search result table
 When I see column "Date of birth" in search result table
 Then I see  Date of birth information from database

Scenario: HR Checks data in "E-mail" column in search result table
 When I see column "E-mail" in search result table
 Then I see E-mail information from database

Scenario: HR Checks data in "Phone" column in search result table
 When I see column "Phone" in search result table
 Then I see Phone information from database

Scenario: HR Checks data in "Trainer" column in search result table
 When I see column "Trainer" in search result table
 Then I see Trainer information from database

Scenario: HR Checks data in "Date of graduate" column in search result table
 When I see column "Date of graduate" in search result table
 Then I see Date of graduate information from database

Scenario: HR Checks data in "Final score" column in search result table
 When I see column "Final score" in search result table
 Then I see Score information from database corresponding to the search option

Scenario: HR Checks data in "Companies, where recommended" column in search result table
 When I see column "Companies, where recommended" in search result table
 Then I see Company information from database corresponding to the search option

Scenario: HR Checks data in "Employer company" column in search result table
 When I see column "Employer company" in search result table
 Then I see Company information from database corresponding to the search option

Scenario: HR Checks data in "Recommendation/employment date" column in search result table
 When I see column "Recommendation/employment date" in search result table
 Then I see dates from database corresponding to search option

Scenario: HR Checks data in "Resume status" column in search result table
 When I see column "Resume status" in search result table
 Then I see Status information from database corresponding to the search option

Scenario: HR Checks data in "Comments" column in search result table
 When I see column "Comments" in search result table
 Then I see Comments information from database

Scenario: HR Checks data in "Education" column in search result table
 When I see column "Education" in search result table
 Then I see Education information from database corresponding to search option

Scenario: HR Checks data in "Language" column in search result table
 When I see column "Language" in search result table
 Then I see Language information from database corresponding to search option

Scenario: HR Checks data in "Language level" column in search result table
 When I see column "Language level" in search result table
 Then I see Language level information from database corresponding to search option

Scenario: HR Checks data in "Skills" column in search result table
 When I see column "Skills" in search result table
 Then I see Skills information from database corresponding to search option

Scenario: HR Checks data in "Looking for a job" column in search result table
 When I see column "Looking for a job" in search result table
 Then I see information from database corresponding to search option

#не знаю как описать поиск
#Scenario: Search result order
#When I see search result table
#Then I see most coinciding information in alphabetical order (A-Z, a-z)
#The Students having coincidences in chosen search options should be displayed at the top of the table.
#Maximum coincidences go first in alphabetical order, decreasing later.

Scenario: HR chooses Search options
 When I chose search options in search table
 Then not all options should be chosen
