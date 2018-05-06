#http://confluence.it-academy.by:8090/display/PROF/US+6.6+To+add+a+company
#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To add company
  In order I can save time in my further work
  As HR
  I should have possibility to add a company

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I stay on home page

Scenario: HR Sees table "Companies"
 Given I press "ADD COMPANY" button on home page
 Then I see table "Companies"
 And I see column with value "№"
 And I see column with value "Company name"
 And I see column with value "Contact person"
 And I see column with value "Phone number"
 And I see column with value "E-mail"
 And I see column with value "Comments"
 And I see button "ADD COMPANY"
 And I see button with cross in column "Company name"
 And I see button with plus in column "Contact person"
 And I can type text in input field in column "Company name"
 And I can type text in input field in column "Contact person"
 And I can type text in input field in column "Phone number"
 And I can type text in input field in column "E-mail"
 And I can type text in input field in column "Comments"

Scenario Outline: HR checks language filter
  When I write "Абў" in "<field>"
  #were "Аб" written on Russian keyboard layout and "ў" on Belarussian keyboard layout
  Then I see written "Абў"
   Examples:
    |option |field         |
    |option1|Company name  |
    |option2|Contact person|
    |option3|Comments      |

Scenario Outline: HR checks language filter
  When I write "Абў" in "<field>"
  #were "Аб" written on Russian keyboard layout and "ў" on Belarussian keyboard layout
  Then I see written ""
   Examples:
    |option |field  |
    |option1|E-mail |

#Scenario: Allowed symbols in fields
#E-mail: A-Z a-z 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~
#http://qaru.site/questions/1744/what-characters-are-allowed-in-an-email-address
#Phone number 0-9 space
#Company name: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space
#Contact person: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space
#Comments: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space

Scenario: HR saves text in input field
 Given I wrote text in input fields "Company name", "Contact person", "Phone number", "E-mail", "Comments" 
 When I press button with tick
 Then text is saved in input fields "Company name", "Contact person", "Phone number", "E-mail", "Comments"
 
Scenario: HR Deletes text in input field
 Given I wrote text in input fields "Company name", "Contact person", "Phone number", "E-mail", "Comments" 
 When I press button with cross
 Then text is deleted in input fields "Company name", "Contact person", "Phone number", "E-mail", "Comments"
 
Scenario: HR Saves information about company
 Given I wrote text in input field in column "Company name"
 And I wrote text in input field in column "Contact person"
 And I wrote text in input field in column "Phone number"
 And I wrote text in input field in column "E-mail"
 And I wrote text in input field in column "Comments"
 When I press button "ADD COMPANY"
 #Then Information is saved
 And I stay on page "Companies"
 And I see new company in table

Scenario: HR Closes table "Companies"
 When I press "BACK" button on page "Companies"
 Then I move to home page

Scenario: HR can Check table "Companies" on error
 Given I leave field "Company name" empty
 And I leave field "Contact person" empty
 And I leave field "Phone number" empty
 And I leave field "E-mail" empty
 And I leave field "Comments" empty
 When I press "ADD COMPANY" button
 Then Text field "Company name" is encircled red
 And Text field "Contact person is encircled red
 And Text field "Phone number" is encircled red
 And Text field "E-mail" is encircled red
 And I stay in table "Companies" 

Scenario: HR sees Companies displayed in alphabetical order in table "Companies"
 Then I see company names in alptabetical order (A-Z, a-z) in table "Companies"

Scenario: HR checks Phone mask validation
 When I type text in column "Phone number"
 Then I text should adjust to mask "+375-XX-XXX-XX-XX"

Scenario: HR checks Email mask validation
 When I type text in column "E-mail"
 Then I text should adjust to mask "a@b.com"

Scenario: HR Adds more contact persons
When I press button with plus in table column "Contact person"
Then I see empty line in table
And I can type text in column "Contact person"
And I can type text in column "Phone number"
And I can type text in column "Email"
And I can type text in column "Comments"

Scenario: HR Deletes company
 Given I added company
 When I press button with cross in last table column 
 Then text is deleted in input field in column "Company name"
 And text is deleted in input field in column "Contact person"
 And text is deleted in input field in column "Phone number"
 And text is deleted in input field in column "E-mail"
 And text is deleted in input field in column "Comments"

Scenario: HR Confirms Delete company
 When I press button with cross in table column "Company name"
 Then I see pop-up window with text
 |Pop-up message text                |
 |Do you want to delete <company>?   |
 And I can choose option "Yes"
 And I can choose option "No"

Scenario: HR sees Confirmation Delete company success
 When I choose "Yes" in pop-up window in table column "Company name"
 Then information about company is deleted from database
 And pop-up window is closed

Scenario: HR sees Confirmation Delete company deny
 When I choose "No" in pop-up window in table column "Company name"
 Then information about company stays in database
 And pop-up window is closed
 
Scenario: HR Deletes contact person
 Given I added contact person
 When I put cursor in input field in column "Contact person"
 And I put cursor in input field in column "Phone number"
 And I put cursor in input field in column "E-mail"
 And I put cursor in input field in column "Comments"
 Then I can delete text in input field in column "Contact person"
 And I can delete text in input field in column "Phone number"
 And I can delete text in input field in column "E-mail"
 And I can delete text in input field in column "Comments" 