Feature: TestShowProductSByDate
	In order to show productS by date
	As a user
	I want to show productS by date info

@mytag
Scenario: Get according productS by date successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show category
	When it will be successful
	When User try to show products date by Date: 14.12.2019
	Then it will be successful
