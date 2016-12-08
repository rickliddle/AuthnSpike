Feature: AuthenticationManager
	In order to access the system
	As a valid user
	I need my credentials verified so that I can get a token

@authN
Scenario: Authenticate valid credentials
	Given I have an instance of the authentication manager
	When I call authenticate with these credentials
		| Field    | Value    |
		| Username | username |
		| Password | password |
	Then I should receive a token

@authN
Scenario: Authenticate invalid credentials
	Given I have an instance of the authentication manager
	When I call authenticate with these credentials
		| Field    | Value   |
		| Username | baduser |
		| Password | badpass |		
	Then An exception should be thrown