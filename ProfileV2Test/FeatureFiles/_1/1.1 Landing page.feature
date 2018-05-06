# http://confluence.it-academy.by:8090/pages/viewpage.action?pageId=42861107

Feature: 1.1 Landing page
  In order to understand the value of the service
  As unauthorized user
  I want to see information about system

  Background:
    Given As unauthorised user I come to landing page of Profile

  Scenario: Verification text fields
    Then I see welcome text
    |text                                                                             |
    |Уважаемые выпускники!                                                            |
    |Данное приложение – это Ваш помощник в составлении резюме.                       | 
    |При заполнении CV помните:                                                       |
    |- Заполнять информацию необходимо на английском языке,                           |
    |- Воспользуйтесь рекомендациями по составлению резюме,                           |
    |- Не пропускайте блоки.                                                          |
    |                                                                                 |
    |После заполнения не забудьте сохранить Ваше CV и информировать об этом HR.       |
    |При появлении вопросов пишите: Hr@it-academy.by                                  |

  Scenario: Verification input fields
    Then I see input field with Input placeholder "e-mail"
    And I see input field with Input placeholder "password"

  Scenario: Verification elements of system (button)
    Then I see button with name "Log in"

#
#  Scenario: Verification elements of system (link)
#   Then I see link with value "Forgot your password?"