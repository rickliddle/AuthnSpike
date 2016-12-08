Feature: AuthenticationManager
	As a valid user
	I want to have my credentials verified 
	Because I need a token to access the system

@authN
Scenario: Authenticate valid credentials
	Given I have an instance of the authentication manager
	When I call authenticate with these credentials
		| Field    | Value    |
		| Username | username |
		| Password | password |
	Then I should receive a token
	But an exception should not be thrown

@authN
Scenario: Authenticate invalid credentials
	Given I have an instance of the authentication manager
	When I call authenticate with these credentials
		| Field    | Value   |
		| Username | baduser |
		| Password | badpass |		
	Then An exception should be thrown
	But I should not receive a token