#http://confluence.it-academy.by:8090/display/PROF/US+6.15+To+open+Student%27s+resume
#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |


Feature: To open Student's resume from HR's home page
In order I can read and check resume
As HR
I should have possibility to open Student's resume

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I stay on home page

Scenario: HR Opens Student's resume by name
When I click on Student's Name in column "Name rus"
Then Student's resume opens in new window

Scenario: HR Opens Student's resume by surname
When I click on Student's Surname in column "Surname rus"
Then Student's resume opens in new window

@ignore
Scenario: HR Sees completed resume
    Given I opened Student's resume
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
