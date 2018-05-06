@US_3.2
As a student
    Scenario: Checking message
       When I as a Student get message
       Then I get message with text
       |address to   |%User.email%|
       |subject      |Данные вашей учетной записи в Системе PROFILE Образовательного центра ПВТ|
       |body| Здравствуйте, @User.name.ru@ @User.surname.ru@. Для вас была создана учетная запись в системе PROFILE. |
            |Для входа в систему используйте ваш пароль - @User.password@.                                           |
