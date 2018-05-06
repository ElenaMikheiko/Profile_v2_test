#http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=43418997
#|Role     |name                     |surname              |e-mail                  |password      |phone number     |
#|student  |Vlad                     |Davies               |daviesvlad555@gmail.com |vlad123456    |+375 29 123 33 49|

Feature: 5.5 To fill in block "Skills"
	In order to inform employer
	As authorized user
	I should have possibility to fill in block "Skills"

Scenario: Student checking resume block title of page
	Given As unauthorised user I come to landing page of Profile
	And I log in as Vlad Davies
	And I open my personal menu
	And I select button "Resume"
	And I go to block "Skills"
	Then I see resume block title "Skills"
	And I see notification "Mandatory field"
	And I see that tab name "Skills" is active

 Scenario: Student saves information
    Given As unauthorised user I come to landing page of Profile
    And I log in as Vlad Davies
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Skills"
    And I filled in field "Skills"
    When I press "NEXT" button
    And I press "BACK" button
    Then I can see data "Skills" is present
    
 Scenario: Student can Check "Skills" block on error
    Given As unauthorised user I come to landing page of Profile
    And I log in as Vlad Davies
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Skills"
    And I leave block "Skills" empty
    When I press "NEXT" button
    Then Text field "Skills" is encircled red
    And I stay in block "Skills"
 
 Scenario: Student deletes skills
    Given As unauthorised user I come to landing page of Profile
    And I log in as Vlad Davies
    And I open my personal menu
    And I select button "Resume"
    And I go to block "Skills"
    And I wrote skills in field "Skills"
    When I press cross near skill
    Then This skill is deleted

 Scenario Outline: Student can search skills
    Given I type word for skills
    When I enter "<letter>" in field "Skills"
    Then I can see "<skills>" starting from this letter in database
    Examples:
    |option |letter|skills                             |
    |option1|f     |Figma, Flask, Flux, Frameworks     |
    |option2|h     |Hibernate, HSQLDB, HTML, Hyper-V   |
    |option3|i     |IDEA, Injection, Interaction design|   
    
Scenario: Student check language filter
	When I write "Абв" in field "Summary"
	#were "Аб" written on the Russian keyboard layout and "в" on the Belorussian keyboard layout
	Then I see the written ""
    
#Scenario: Allowed symbols in fields
#Skills A-Z a-z !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ space
#https://www.owasp.org/index.php/Password_special_characters 

#Scenario: Student can convert word to tag
#Given I type word for skill in field "Skills"
#When I press button with plus sign
#Then written word is converted to tag
   
Scenario Outline: Student Checks default skills
	Given As unauthorised user I come to landing page of Profile
	And I log in as student
	And I open my personal menu
	And I select button
	And For the first time I go to block "Skills"
	When My stream is <"stream">
	Then I can see "<default skills>" default skills
	Examples:
	|stream                   |default skills                                  |
	|Android Developer        | Java Core, Android SDK, RxJava, RxAndroid      |
	|Java Automated Testing   | Java, Selenium Webdriver, XML, HTML, CSS       |
	|Business Analyst         | Analyzing Requirements, Vision&Scope, BPMN     |
	|C++ Developer            | С++, Qt Framework, STL                         |
	|Front-end Developer      | HTML, CSS, JavaScript,  jQuery                 |
	|Java Developer           | Java Core, Servlets, Spring                    |
	|ASP.NET Developer        | С#, ASP.NET MVC,SOLID                          |
	|IOS Developer            | Swift, SOLID, Xcode                            |
	|PHP Developer            | PHP, Symfony, MySQL                            |
	|Python Developer         | Python, Django, UnitTest                       |
	|Python Automated Testing | Python, Linux, Automation                      |
	|Software Testing         | Functional testing, TestRail, Jira             |
	|UI/UX Designer           | Adobe Photoshop, Adobe Illustrator, Axure      |