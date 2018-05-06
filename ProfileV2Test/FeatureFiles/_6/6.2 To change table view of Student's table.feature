#http://confluence.it-academy.by:8090/display/PROF/US+6.2+To+change+table+view+of+Student%27s+table

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To change table view of Students table
In order I can work with table with more comfort
As HR
I should have possibility to change table view of Students table

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I see page HR's list of students

#Scenario: HR chooses columns to be displayed
#Then I can choose columns to be displayed

#Scenario: HR chooses columns to be hidden
#Then I can choose columns to be hidden

#Scenario Outline: HR sees Order of options in drop-down in "Show columns" field
#When I open drop-down list in "Show columns" field
#Then I see that "<column>" is "<number>" in drop-down in "Show columns" field
#Examples:
#|option  |Column                        |number|
#|option1 |Show all                      |1     |
#|option2 |Stream                        |2     |
#|option3 |Name rus                      |3     |
#|option4 |Surname rus                   |4     |
#|option5 |Date of birth                 |5     |
#|option6 |E-mail                        |6     |
#|option7 |Phone                         |7     |
#|option8 |Trainer                       |8     |
#|option9 |Date of graduate              |9     |
#|option10|Final score                   |10    |
#|option11|Companies, where recommended  |11    |
#|option12|Employer company              |12    |
#|option13|Recommendation/employment date|13    |
#|option14|Resume status                 |14    |
#|option15|Comments                      |15    |
#|option16|Education                     |16    |
#|option17|Language                      |17    |
#|option18|Language level                |18    |
#|option19|Skills                        |19    |
#|option20|Looking for a job             |20    |

Scenario Outline: HR sees Displayed table columns
When I choose "<checkbox_status>" "<column_name>"
Then "<column_name>" is "<column_status>"
Examples:
|option |checkbox_status|column_name|column_status|
|option1|tick           |Phone      |displayed    |
|option2|tick           |Trainer    |displayed    |
|option3|empty          |Comments   |hidden       |

