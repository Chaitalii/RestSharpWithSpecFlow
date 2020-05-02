Feature: purchase

Scenario: 1 Verify login is successful with valid username and password
	Given I have endpoint to hit /login-v1/
	And I build login post request with Testing768 and Welcome_2_gametwist
	Then I hit the request 
	Then I verify HTTP status code
	And I extract the token from the response
		 
Scenario Outline: 2 Validate logged in user is able to send consent types
	Given I have endpoint to hit /consent/consent-v1
	And I build consent type post request for consent type <consentType> and accepted value as <accepted>
	And I store the <consentType> and accepted <accepted>
	Then I hit the request
	Then I verify HTTP status code

	Examples: 
	| consentType               | accepted |
	| GeneralTermsAndConditions | true |
	| DataPrivacyPolicy         | false |
	| MarketingProfiling        | true |

Scenario Outline: Validate  GET Consent-v1 API
	Given I have endpoint to hit /consent/consent-v1
	And I build consent type get request for consent type <consentType>
	Then I hit the request
	Then I verify HTTP status code
	And I fetch the accepted value for <consentType>
	And I validate the value of wasAccepted field

	Examples: 
	| consentType               |
	| GeneralTermsAndConditions |
	| MarketingProfiling        |
	| DataPrivacyPolicy         |