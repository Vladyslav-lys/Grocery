Feature: TestShowProvider
	In order to show provider
	As a user
	I want to show provider info

@mytag
Scenario: Get according tare changes successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show provider
	Then it will be successful
