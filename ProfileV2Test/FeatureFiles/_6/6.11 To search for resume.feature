#http://confluence.it-academy.by:8090/display/PROF/US+6.11+To+search+for+resume

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To search for resume
  In order I can find information I need
  As HR
  I should have possibility to search for resume

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I stay on home page

Scenario: HR Chooses option
When I go to header of table with Students list
Then I can choose option in columns in header of table

Scenario: HR Chooses option in "Stream" column
 When I see column "Stream"
 Then I see selector in column "Stream"
 And I see placeholder text "Stream"
 And I can choose option
 And I can choose several options
 And I can type text in "Stream" column

  Scenario Outline: HR checks language filter
  When I write "Абў" in "<field>"
  #were "Аб" written on Russian keyboard layout and "ў" on Belarussian keyboard layout
  Then I see written ""
   Examples:
    |option |field      |
    |option1|Stream     |
    |option2|Language   |
    |option3|Skills     |
    |option4|Final score|

#Scenario: Allowed symbols in fields
#Stream: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Language: A-Z a-z 0-9 . , ? ! " ' : ; . – / space
#Skills: A-Z a-z 0-9 . , ? ! " ' : ; . – / space 
#Final score: 0-9
#Companies where recommended: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space
#Employer company: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space

Scenario: HR Checks selector value in column "Stream"
 When I open selector in column "Stream"
 Then I see value "AD",
 And I see value "AT",
 And I see value "BA",
 And I see value "CD",
 And I see value "FD",
 And I see value "JD",
 And I see value "ND",
 And I see value "ID",
 And I see value "PD",
 And I see value "PT",
 And I see value "PT2",
 And I see value "ST",
 And I see value "UI/UX"

Scenario: HR Chooses option in "Final score" column
 When I see column "Final score"
 Then I see selector in column "Final score"
 And I see placeholder text "Final score"
 And I can choose option
 And I can choose several options
 And I can type text in column "Final score"

Scenario: HR Checks selector value in column "Final score"
 When I open selector in column "Final score"
 Then I see value "7"
 And I see value "8"
 And I see value "9"
 And I see value "10"

Scenario: HR Chooses option in "Companies where recommended" and "Employer company" columns
 When I see "Companies where recommended" and "Employer company" columns
 Then I see selector in "Companies where recommended" and "Employer company" columns
 And I see placeholder text "Company"
 And I can choose option
 And I can choose several options
 And I can type text in "Companies where recommended" and "Employer company" columns

Scenario: HR Checks selector value in "Companies where recommended" and "Employer company" columns
 When I open selector in "Companies where recommended" and "Employer company" columns
 Then I see company names from database

Scenario: HR Chooses option in "Recommendaton/Employment date" column
 When I see "Recommendaton/Employment date" column
 Then I see selector in "Recommendaton/Employment date" column
 And I can choose option "From"
 And I can choose option "To"

Scenario: HR Checks selector value in "Recommendaton/Employment date" column
 When I open selector in "Recommendaton/Employment date" column in fields "From" and "To"
 Then I see calendar with current month and year
 And I see current day is highlighted

Scenario: HR Chooses option in "Resume status" column
 When I see column "Resume status"
 Then I see selector in column "Resume status"
 And I see placeholder text "Resume status"
 And I can choose option

Scenario: HR Checks selector value in column "Resume status"
 When I open selector in column "Resume status"
 Then I see value "New"
 And I see value "Submitted"
 And I see value "Review"
 And I see value "Approved"
 And I see value "Recommended"
 And I see value "Employed"
 And I see value "Archive Employed"
 And I see value "Archive Unemployed"
 And I see value "Archive Didn't participate in the program"

Scenario: HR Chooses option in "Education" column
 When I see column "Education"
 Then I see selector in column "Education"
 And I see placeholder text "Education"
 And I can choose option

Scenario: HR Checks selector value in column "Education"
 When I open selector in column "Education"
 Then I see value "Technical"
 And I see value "Non-technical"

Scenario: HR Chooses option in "Language" column
 When I see column "Language"
 Then I see selector in column "Language"
 And I see placeholder text "Language"
 And I can choose option
 And I can type text in "Language" column

Scenario Outline: HR Sees hint in column "Language"
 Given I type word for language in column "Language"
 When I enter "<letter>" in column "Language"
 Then I can see "<language>" starting from this letter in database
 Examples:
  |option |letter|language                             |
  |option1|a     |Afrikaans, Albanian, Arabic, Armenian|
  |option2|e     |English,Estonian                     |
  |option3|b     |Belarusian, Bulgarian                |
  |option4|y     |                                     |

Scenario: HR sees Language separation in column "Language"
 When I enter several languages in column "Language"
 Then I can see languages separated by ","

Scenario: HR Chooses option in "Language level" column
 When I see column "Language level"
 Then I see selector in column "Language level"
 And I see placeholder text "Language level"
 And I can choose option
 And I can type text in "Language level" column
 
Scenario: HR Checks selector value in column "Language level"
 When I open selector in column "Language level"
 Then I see value "A1 Elementary"
 And I see value "A2 Pre-Intermediate"
 And I see value "B1 Intermediate"
 And I see value "B2 Upper-Intermediate"
 And I see value "C1 Advanced"
 And I see value "C2 Proficiency"

Scenario: HR Chooses option in "Skills" column
 When I see column "Skills"
 Then I see selector in column "Skills"
 Then I see placeholder text "Skills"
 And I can choose option
 And I can type text in "Skills" column

Scenario Outline: HR Sees hint in column "Skills"
 Given I type word for language in column "Skills"
 When I enter "<letter>" in column "Skills"
 Then I can see "<language>" starting from this letter in database
  Examples:
  |option |letter|skills                                                               |
  |option1|f     |Figma, Flask, Flux, Frameworks, FTP, Functional testing              |
  |option2|h     |Hibernate, HSQLDB, HTML, Hyper-V                                     |
  |option3|i     |IDEA, Injection, Interaction design, Interface Builder, Invision, iOS|

Scenario: HR sees Skills separation in column "Skills"
 When I enter several skills in column "Skills"
 Then I can see skills separated by ","

Scenario: HR Chooses option in column "Looking for a job"
 When I see column "Looking for a job"
 Then I see slider button is inactive by default
 And I can set slider active

Scenario: HR Clears filters
 When I press button "CLEAR ALL" on home page
 Then all filters are cleared