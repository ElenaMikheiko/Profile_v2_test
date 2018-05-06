# http://confluence.it-academy.by:8090/x/HoOWAg
# error - Server error: can’t create a new accounts. Please try again later.’
# Link example of trainer's tablet https://goo.gl/Ci6ezw
# Link example of student's student https://goo.gl/hLPoCD
 
#|Role     |name                     |surname              |e-mail               |password      |phone number     |
#|student  |Ivan                     |Ivanov               |Ivan@profile.com     |student       |+375 44 123 45 67|
#|hr       |Maria                    |Zaporoschenko        |hr@it-academy.by     |              |                 |
#|Admin    |                         |                     |admin@profile.com    |admin123      |                 |
#|trainer  |                         |                     |trainer@profile.com  |trainer       |                 |



Feature: 3.2 Create accounts
  In order to provide access to system for new users
  As administrator
  I should have possibility to create new accounts in system


  Background:
    Given As unauthorized user I come to the landing page of Profile
    And I login as Admin
    And	I press "Accounts" button
    And I press "Import" button
    And	I see import form

@ignore
  Scenario: Fill in link to google table
      Then I can insert link to google tab

@ignore
  Scenario: Import list of users
      Then I can import list of Users in DB

@ignore
    Scenario: Success import (except the student)
      Given I insert link in field
      When	I press "Import" button
      Then	I see a notification about the process progress
      And	System creates accounts in DB
      And	System assigns each account a password consisting of 6 characters (at least 1 number and at least 1 letter)
      And	System sends mail to emails of new accounts
      And	I see a notification of the successful completion of the process
      And	I see admin panel

@ignore
  Scenario: Role student
    Given I insert link in field
    When I press "Import" button
    Then I see a notification about the process progress
        # And in the field "role" is written "student"
        # And All fields are filled
    And	System creates accounts in DB
    And	System assigns each account a password consisting of 6 characters (at least 1 number and at least 1 letter)
    And	System sends mail to emails of new accounts
    And	I see a notification of the successful completion of the process
    And	I see admin panel

@ignore
  Scenario: Cancel import form
      When	I press "Close" button
      Then	The import form is closed

@ignore
    Scenario: Leave from import form
      When	I click in out of form’s area
      Then	I don't see the form

@ignore
    Scenario: Import hint
      Then	I see text 
      |TEXT|
      |In order to create accounts - specify the link to the Google table with the data corresponding to the specified sample.|

@ignore
    Scenario:  Example of Import table
      Then	I see example of google table

@ignore
    Scenario: Link label
      Then I see label "Link to the Google table with Edit permissions"

@ignore
   # Scenario: Checking mandatory fields
     # Then Field Role is mandatory field
     # And Field Name(rus)is mandatory field
     # And Field Surname(rus)is mandatory field
     # And Field Name(eng)is mandatory field
     # And Field Surname(eng)is mandatory field
     # And Field Email is mandatory field
     # And Field Phone is mandatory field
  # Как лучше описать что поля обязательны для заполнения? ниже глянь может так?

@ignore
  #  Scenario Outline: Verification max symbols
  #      When I import data in <fields>
  #      Then I import max <number> symbols in field
   #     Examples:
    #      |fields                             |number   |
     #     |Role                               |25       |
      #    |name(rus)                          |25       |
       #   |surname(rus)                       |25       |
        #  |patronymic(rus)                    |25       |
         # |name(eng)                          |25       |
#          |surname(eng)                       |25       |
 #         |date of birthday(for student)      |10       |
  #        |date of graduate(for student)      |10       |
   #       |email                              |64       |
    #      |phone                              |12       |
     #     |stream(for student)                |10       |
      #    |trainer(for student)               |25       |

@ignore
  Scenario Outline: Import validation
      When I import <data> in <fields>
      Then I see <symbols> program response # добавить ссылки на колонки google doc
      Examples:
        |fields                             |data          |symbols     |
        |Role                               |student       |student     |
        |Role                               |trainer       |trainer     |
        |Role                               |HR            |HR          |
        |Role                               |admin         |admin       |
        |Role                               |#monkey       |# error     |
        |name(rus)                          |Ая.-`         |Ая.-`       |
        |name(rus)                          |Az!@#$%^&*()  |# error     |
        |surname(rus)                       |Ая.-`         |Ая.-`       |
        |surname(rus)                       |Az!@#$%^&*()  |# error     |
        |patronymic(rus)                    |Ая.-`         |Ая.-`       |
        |patronymic(rus)                    |Az!@#$%^&*()  |            |
        |name(eng)                          |Az .-`        |Az .-`      |
        |name(eng)                          |Ая!@#$%^&*( ) |# error     |
        |surname(eng)                       |Az .-`        |Az .-`      |
        |surname(eng)                       |Aя!@#$%^&*()  |# error     |
        |date of birthday(for student)      |AzАя!@#$%^&*()|            |
        |date of birthday(for student)      |1234567890.   |1234567890. |
        |date of graduate(for student)      |1234567890.   |1234567890. |
        |date of graduate(for student)      |AzАя!@#$%^&*()|            |
        |phone                              |Az Ая         |# error     |
        |phone                              |0123456789    |0123456789  |
        |stream(for student)                |Az+/.         |Az+/.       |
        |stream(for student)                |!@#$%^&*(),Ая |            |
        |trainer(for student)               |Ая .-`        |Ая .-`      |
        |trainer(for student)               |Az!@#$%^&*()  |Az!@#$%^&*()|

@ignore
    Scenario: Import failed(server)
      Given	I press "Import" button
      When	Server can’t create new accounts
      Then	I see error text 
      |Text|
      |Server error: can’t create a new accounts. Please try again later.|
      And	I see import form

@ignore
    Scenario: Import failed(invalid link)
      Given	I press "Import" button
      When	I fill invalid link
      Then	I see error text 
      |Text|
      |Link, that i inserted, isn't link on the Google table with editing rights.|
      And	I see import form

@ignore
    Scenario: Insert .jpeg in input field                   # Любой файл отличающийся от google doc.
       Then I see error text
       |Text|
       |Link, that i inserted, isn't link on the Google table with editing rights.|

@ignore    @UI
      Scenario: Button "Import" is highlighted on hover
        When I hover on the "Import" button
        Then Button is highlighted

@ignore    @UI
     Scenario: Button "Cancel" is highlighted on hover
       When I hover on the cancel button
       Then Button is highlighted
