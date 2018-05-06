#http://confluence.it-academy.by:8090/display/PROF/US+6.4+To+search+information+in+table

#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|HR       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |

Feature:  To search information in table
In order I can find information I need
As HR
I should have possibility to search information in table

Background:
Given As unauthorised user I come to landing page of Profile
And I log in as HR
And I see page HR's list of students

Scenario: HR Searches information
When I click in "Search" field
Then I can type text

  Scenario Outline: HR checks language filter
  When I write "Абв" in "<field>"
  #were "Аб" written on Russian keyboard layout and "в" on Belarussian keyboard layout
  Then I see written "Абв"
   Examples:
    |option |field      |
    |option1|Search     |

#	Scenario: Allowed symbols in field
#   Search: A-Z a-z А-Я а-я 0-9 ! " # $ % & ' ( ) * + , - . / : ; < = > ? @ [ \ ] ^ _ ` { | } ~ space

Scenario: HR starts Search
When I click on icon with magnifier or press button "Enter" on keyboard
Then search starts

Scenario Outline: HR sees Search results positive
When I type "<number_letters>" "<letters>" in "Search" field
Then I see occuring "<number_highlighted>" is highlighted in <phrase>
Examples:
|option |number_letters|letters|number_highlighted|phrase                                    |
|option1|3             |абв    |0                 |                                          |
|option2|5             |ивано  |5                 |ивано, иванов, иванова, иванович, ивановна|
|option3|7             |english|7                 |english                                   |

Scenario: HR sees Search results negative
When occuring <number_highlighted> =0
Then I see notification "No match is found" in "Search" field

@UI
Scenario: HR Removes highlighting on words
When I press on any place on page
Then highlighting on words is hidden
