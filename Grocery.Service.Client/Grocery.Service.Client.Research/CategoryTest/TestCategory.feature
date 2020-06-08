Feature: TestShowCategory
	In order to show category
	As a user
	I want to show category info

@mytag
Scenario: Get according category successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show category
	Then it will be successful
