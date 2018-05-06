#http://confluence.it-academy.by:8090/display/PROF/US+6.13.1+To+receive+notification+e-mail+%27New+resume+submitted%27+for+HR

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To receive notification e-mail "New resume submitted"
  In order I can see new resumes and work with them
  As HR
  I should have possibility to receive notification e-mail "New resume submitted"

Acceptance criteria
I can receive e-mail informing about new resume submitted

Background:
Given Admin created my account in Profile system
And Student submitted resume

Scenario: HR receives e-mail informing about new resume submitted
Then I receive e-mail with header "New resume submitted"
And I see text
|TEXT                                      |
|Dear HR manager!                          |
|<Name><Surname> has submitted the resume. |
|Please check the Resume <link>            |
|Best regards,                             |
|Educational Center of HTP                 |
|#link to Profile#                         |
