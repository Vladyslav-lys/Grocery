Feature: TestShowReportSimple
	In order to show report simple
	As a user
	I want to show report simple info

@mytag
Scenario: Get according report simple successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show report simple by SinceDate: 12.12.2019 and ToDate: 15.12.2019
	Then it will be successful
