#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43427470

#|Role     |name                     |surname              |e-mail                    |password      |phone number     |
#|student  |Brea                     |Breens			   |breabreens555@gmail.com   |brea123456    |+375 25 784 55 66|

Feature:  5.18.3 To receive notification e-mail "Resume approved"
  In order I can know news about my resume
  As authorized user
  I should have possibility to receive notification e-mail "Resume approved"

Background:
    Given HR approved my resume

Scenario: Student receives e-mail informing that my resume was approved
    When I receive e-mail with header "Approved resume"
    Then I see text
    |Text                                                                                                 |
    |Dear <Name><Surname>!                                                                                |
    |Your Resume was approved by HR.                                                                      |
    |Now it's time to find a job!                                                                         |
    |You will be informed every time when you are recommended to a company.                               |
    |After notification you need to prepare for the interview and read information about the company.     |
    |Please, let us know when you are employed. This information is important to the Educational center.  |
    |Good luck!                                                                                           |
    |Best regards,                                                                                        |
    |Educational Center of HTP                                                                            |
    |#link to Profile#                                                                                    |
