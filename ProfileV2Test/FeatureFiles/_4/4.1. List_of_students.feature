Feature: 4.1 To see list of students
To obtain information about students and status of reviews
As trainer
I should see list of students (name, surname, feedback status, feedback submit time, feedback request date)
 
Background:
	Given as unauthorised user I come to the landing page of Profile
	And I login as trainer
	And I see page Trainer's students

Scenario Outline: Trainer can view list of students on Trainer's students page (student with feedback)
	When Some Students already have feedback
	Then I see page header "My students"
	And I see "<number>" at column with header "№"
	And I see "<NameSurname>" of student related to me at column with header "Student"
	And I see button with name equal feedback submit date "<FeedbackSubmitDate>" at column with header "Status"
	And I see date of the student's account creation "<RequestDate>" at column with header "Request date"
	Examples:
	| option  | number | NameSurname | FeedbackSubmitDate | RequestDate |
	| option1 | 1      | Ivan Ivanov | 22.12.18           | 22.12.18    |
	| option2 | 2      | Petr Petrov | 15.11.18           | 12.11.18    |

Scenario: Trainer can view list of student on Trainer's students page (student without feedback)
	When Some Students haven't got feedback
	Then I see button "Leave feedback" at column with header "Status"