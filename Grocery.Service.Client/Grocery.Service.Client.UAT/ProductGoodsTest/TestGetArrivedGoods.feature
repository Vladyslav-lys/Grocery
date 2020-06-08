Feature: TestShowArrivedGoods
	In order to show arrived goods
	As a user
	I want to show arrived goods info

@mytag
Scenario: Get according arrived goods successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show arrived goods by Department: department
	Then it will be successful
