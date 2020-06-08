Feature: TestGetSale
	In order to get sale
	As a user
	I want to get sale info

@mytag
Scenario: Add according get successful
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
	When User try to show sales by Department: department
	When it will be successful
	When User try to show sales clases by Class: class and SinceDate: 11.12.2019 and ToDate: 21.12.2019
	Then it will be successful
