Feature: Consent
	

@mytag



	Scenario Outline: Acceptance test  for the given consent type
	Given I have endpoint to hit /consent/consent-v1
	And I hit consent type post request for consent type <consentType> and accepted value as <accepted>
	Then I verify HTTP status code

	Examples: 
	| consentType               | accepted |
	| GeneralTermsAndConditions | true |
	| DataPrivacyPolicy         | true |
	| MarketingProfiling        | true |
	