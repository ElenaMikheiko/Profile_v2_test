#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43427472
#|Role     |name                     |surname              |e-mail                    |password      |phone number     |
#|student  |Brea                     |Breens			   |breabreens555@gmail.com   |brea123456    |+375 25 784 55 66|

Feature:  5.18.4 To receive notification e-mail "I was recommended"
  In order I can know news about my resume
  As authorized user
  I should have possibility to receive notification e-mail "I was recommended"

Background:
    Given HR sent my resume to company
     
Scenario: Student receives e-mail informing I was recommended to company
    When I receive email with header "Recommendation to company"
    Then I see text
    |Text                                                                            |
    |Dear <Name><Surname>!                                                           |
    |Your resume has been sent to <COMPANY_NAME>.                                    |
    |Please, read the information about <COMPANY_NAME> and prepare for the interview.|
    |Let us know the interview results.                                              |
    |Good luck!                                                                      |
    |Best regards,                                                                   |
    |Educational Center of HTP                                                       |
    |#link to Profile#                                                               |


