Feature: TestShowProductS
	In order to show productS
	As a user
	I want to show productS info

@mytag
Scenario: Get according productS successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show products by Department: department
	Then it will be successful
