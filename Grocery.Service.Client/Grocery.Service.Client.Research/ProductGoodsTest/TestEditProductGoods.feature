Feature: TestEditProductSGoods
	In order to edit product goods
	As a user
	I want to edit product goods info

@mytag
Scenario: Edit according product goods successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: TopSeller1 and password: qetuo13579 through Client
	When it will be successful
	When User try to find seller by User: user
	When it will be successful
	When User try to show category
	When it will be successful
	When User try to show class
	When it will be successful
	When User try to show provider
	When it will be successful
	When User try to show tare changes
	When it will be successful
	When User try to edit product goods by Product: product and ArrivedGoods: arrivedGoods
	Then it will be successful
