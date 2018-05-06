# http://confluence.it-academy.by:8090/x/XYSFAg

Feature: 2.2 To upload photo
In order to other users can view my avatar
As authorized user
I should have possibility to upload my photo

Background:
Given As unauthorized user I come to landing page of Profile
And I log in as Student

Scenario: Open form for upload foto
Given I put cursor in photo area
When I click on photo area
Then I see the close button
And I see "Choose image" button
And I see upload photo text hint
|Text                                                                |
|It will be easier to get to know you if you upload your real photo. |
|You can download the image in JPG, JPEG, PNG, BMP format.           |
|The file size must not exceed 3 Mbyte.								 |

Scenario: Student upload photo
Given I put cursor in photo area
And I click on photo area
And I click "Choose image" button
And I choose img with size smaller than 3 Mbyte from local storage
When I click "Upload photo"
Then I see student's profile page with uploaded img

Scenario: Upload photo bigger then 3 Mbyte
	Given I put cursor in photo area
	And I click on photo area
	And I click "Choose image" button
	And I choose img with size bigger than 3 Mbyte from local storage
	And img size is bigger than 3 Mbyte
	Then I see upload error message
	|Error message											 |
	|Download failed.										 |
	|Check the size and format of the file.					 |
	|You can upload the image in JPG, JPEG, PNG, BMP formats.|
	|File size should not exceed 3 Mbyte.			         |