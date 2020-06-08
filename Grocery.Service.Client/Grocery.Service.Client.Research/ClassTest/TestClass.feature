Feature: TestShowClass
	In order to show class
	As a user
	I want to show class info

@mytag
Scenario: Get according department successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show class
	Then it will be successful
