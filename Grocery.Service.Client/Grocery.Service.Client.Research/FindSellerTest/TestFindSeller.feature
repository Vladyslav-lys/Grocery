Feature: TestFindSeller
	In order to find seller
	As a user
	I want to find seller info

@mytag
Scenario: Get according seller successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	Then it will be successful
