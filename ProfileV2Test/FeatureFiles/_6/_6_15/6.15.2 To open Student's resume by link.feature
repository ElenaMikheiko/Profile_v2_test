#http://confluence.it-academy.by:8090/display/PROF/US+6.15.2+To+open+Student%27s+resume+by+link
#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature: To open Student's resume by link
In order I can read and check resume
As HR
I should have possibility to open Student's resume

Background:
I have link for Student's resume in my email

Scenario: HR Opens Student's resume
When I click on link for Student's resume in my email
Then I move to Student's resume in Profile account
And Student's resume opens in new window

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
