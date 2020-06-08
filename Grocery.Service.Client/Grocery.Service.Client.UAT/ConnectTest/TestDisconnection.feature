Feature: TestDisconnection
	In order to enter the page
	As a user
	I want to be disconnected

@mytag
Scenario: Disconnect to the system successful
	Given User try to connect the server
	When it will be successful
	When User try to disconnect the server
	Then it will be successful
