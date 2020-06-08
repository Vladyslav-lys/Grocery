Feature: TestAddSale
	In order to add sale
	As a user
	I want to add sale info

@mytag
Scenario: Add according sale successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show category
	When it will be successful
	When User try to show class
	When it will be successful
	When User try to show provider
	When it will be successful
	When User try to show tare changes
	When it will be successful
	When User try to show products by Department: department
	When it will be successful
	When User try to get sale by Department: department
	When it will be successful
	When User try to add sale by Sale: sale
	Then it will be successful
