#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43426112

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|student  |                         |                     |                     |              |+375             |

Feature:  5.18.1 To receive notification e-mail "Account created"
  In order I can know news about my account
  As authorized user
  I should have possibility to receive notification e-mail "Account created"

Background:
  Given Admin created my account in Profile system

Scenario: Student receives e-mail informing that my account was created
   When I receive e-mail with header "Profile account created"
   Then I see text
     |Text                                       |
     |Dear <Name><Surname>!                      |
     |Your account in Profile system was created.|
     |Your login is <email>                      |
     |Please follow the #link# to set password.  |
     |The next step is to create your resume.    |
     |Best regards,                              |
     |Educational Center of HTP                  |
     |#link to Profile#                          |
