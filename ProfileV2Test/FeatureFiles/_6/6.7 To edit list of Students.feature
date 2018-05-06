#http://confluence.it-academy.by:8090/display/PROF/US+6.7+To+edit+list+of+Students
#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To edit list of Students
  In order I can work with list of Students
  As HR
  I should have possibility to edit list of Students

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I stay on home page

Scenario: HR Checks possibility to see list of Students
 Then I can see list of Students
 And I can choose option in table cells
 And I can type text in table cells

  Scenario Outline: HR checks language filter
  When I write "Абв" in "<field>"
  #were "Аб" written on Russian keyboard layout and "в" on Belarussian keyboard layout
  Then I see written "Абв"
   Examples:
    |option |field                      |
    |option1|Companies where recommended|
    |option2|Employer company           |
    |option3|Comments                   |

#	Scenario: Allowed symbols in fields
#   Companies where recommended: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space
#   Employer company: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space
#   Comments: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space

#table cells "Companies where recommended", "Employer company", "Recommendaton/Employment date", "Comments" are empty by default

Scenario: HR Adds data in table cells "Companies where recommended", "Employer company", "Comments"
 When I press on table cell in columns "Companies where recommended", "Employer company", "Comments"
 Then I can type text in table cells "Companies where recommended", "Employer company", "Comments"
 And I can choose option in selector

Scenario: HR sees all companies in table cells "Companies where recommended", "Employer company"
Given I typed information in table cells "Companies where recommended", "Employer company"
When I hover on table cell
Then I see whole list of companies
And I can scroll companies

Scenario: HR sees Shorted list of companies in table cells "Companies where recommended", "Employer company"
Given list of companies is long
Then display first #n companies
And hide others as "..."

Scenario: HR sees Companies separation in table cells "Companies where recommended", "Employer company"
 When I add several companies in table cells "Companies where recommended", "Employer company"
 Then I can see companies separated by ","

Scenario: HR Adds data in "Recommendaton/Employment date" column
 When I see table column "Recommendaton/Employment date"
 Then selector opens
 And I can choose option

Scenario: HR Checks data in "Recommendaton/Employment date" cell
 Given table cell "Companies where recommended" is filled in
 And table cell "Employer company" is empty
 Then data in "Recommendaton/Employment date" cell = "recommendation date"
 But
 Given table cell "Employer company" is filled in
 And table cell "Companies where recommended" is empty
 Then data in "Recommendaton/Employment date" cell = "employment date"

Scenario: HR Checks selector value in "Recommendaton/Employment date" column
 When I open selector in column "Recommendaton/Employment date"
 Then I see calendar with current month and year

Scenario: HR Checks current day is highlighted in calendar drop-down
 When I open calendar selector in column "Recommendaton/Employment date"
 Then I see current day is highlighted

Scenario: HR Checks data in "Resume status" column
 When I see table column "Resume status"
 Then I see Student's Resume status from database

Scenario: HR Saves data in table cells "Companies where recommended", "Employer company", "Comments"
 Given I type in table cells "Companies where recommended", "Employer company", "Comments"
 When I click on button with tick
 Then Information is saved 
 And I see typed text is present

Scenario: HR Deletes data in table cells "Companies where recommended", "Employer company", "Comments"
 Given I type in table cells "Companies where recommended", "Employer company", "Comments"
 When I click on button wih cross
 #Then Information is not saved
 And I see table cells are empty

Scenario: HR Checks data in "Education" table cells
 When I see table column "Education"
 Then I can see text from HR's comments in resume

Scenario: HR Checks data in "Language" table cells
 When I see table column "Language"
 Then I can see text from Student's resume

Scenario: HR Checks data in "Language level" table cells
 When I see table column "Language level"
 Then I can see text from Student's resume

Scenario: HR Checks data in "Skills" table cells
 When I see table column "Skills"
 Then I can see text from Student's resume

Scenario: HR sees all skills in "Skills" table cell
When I hover on "Skills" table cell
Then I see whole list of skills
And I can scroll skills

Scenario: HR sees Shorted list of skills in table cell "Skills"
Given list of skills in table cell "Skills" is long
Then display first #n skills
And hide others as "..."