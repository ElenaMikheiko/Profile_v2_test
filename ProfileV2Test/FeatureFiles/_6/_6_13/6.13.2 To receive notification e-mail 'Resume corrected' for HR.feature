#http://confluence.it-academy.by:8090/display/PROF/US+6.13.2+To+receive+notification+e-mail+%27Resume+corrected%27+for+HR

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To receive notification e-mail "Resume corrected"
  In order I can see new resumes and work with them
  As HR
  I should have possibility to receive notification e-mail "Resume corrected"

Acceptance criteria
I can receive e-mail informing about resume corrected

Background:
Given Admin created my account in Profile system
And Student corrected resume

Scenario: HR receives e-mail informing about resume corrected
Then I receive e-mail with header "Resume corrected"
And I see text
|TEXT                                      |
|Dear HR manager!                          |
|<Name><Surname> has corrected the resume. |
|Please check the Resume <link>            |
|Best regards,                             |
|Educational Center of HTP                 |
|#link to Profile#                         |
