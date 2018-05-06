#http://confluence.it-academy.by:8090/display/PROF/US+6.3+To+sort+out+information+in+the+list+of+Students

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To sort out information in list of Students
In order I can find information in list of Students
As HR
I should have possibility to sort out information in list of Students

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I see page HR's list of students 

Scenario Outline: HR Sorts out information in table columns
When I press "Sort out" button in table column "<column>"
Then "<type>" information in table columns is sorted out in "<sort_order>" order "<from_to>"
Examples:
|option  |column                        |type    |sort_order  |from_to|
|option1 |Stream                        |letters |alphabetical|A-Z    |
|option3 |Name rus                      |letters |alphabetical|A-Z    |
|option5 |Surname rus                   |letters |alphabetical|A-Z    |
|option8 |Date of birth                 |numbers |numerical   |0-9    |
|option9 |E-mail                        |letters |alphabetical|A-Z    |
|option10|E-mail                        |numbers |numerical   |0-9    |
|option12|Phone                         |numbers |numerical   |0-9    |
|option13|Trainer                       |letters |alphabetical|A-Z    |
|option16|Date of graduate              |numbers |numerical   |0-9    |
|option18|Final score                   |numbers |numerical   |0-9    |
|option19|Companies, where recommended  |letters |alphabetical|A-Z    |
|option21|Employer company              |letters |alphabetical|A-Z    |
|option24|Recommendation/employment date|numbers |numerical   |0-9    |
|option25|Resume status                 |letters |alphabetical|A-Z    |
|option27|Comments                      |letters |alphabetical|A-Z    |
|option28|Comments                      |numbers |numerical   |0-9    |
|option29|Education                     |letters |alphabetical|A-Z    |
|option31|Language                      |letters |alphabetical|A-Z    |
|option33|Language level                |letters |alphabetical|A-Z    |
|option35|Skills                        |letters |alphabetical|A-Z    |