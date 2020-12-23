Feature: ProductTest
	As a user of the website
	I want to log into the website
	So i can create a product

Scenario: Create a product
	Given I open "http://localhost:5000" url
	When I log into with username "user" and password "user" 
	And I click on send button
	Then I should be at the home page
	When I click on the all products link
	And I click on create new button
	And I create a product with fields "Tea", "Beverages", "Tokyo Traders", "100", 10, 200, 20, 10, "true"
	And I click on send button product
	Then The form of creation disappeared
	And The product should be on all products page