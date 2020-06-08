Feature: TestShowReportDetailed
	In order to show report detailed
	As a user
	I want to show report detailed info

@mytag
Scenario: Get according report detailed successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show category
	When it will be successful
	When User try to show report detailed by Category: category and SinceDate: 12.12.2019 and ToDate: 15.12.2019
	Then it will be successful
