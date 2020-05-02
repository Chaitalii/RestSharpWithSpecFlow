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
	| DataPrivacyPolicy         | true |
	| MarketingProfiling        | true |

Scenario Outline: 3 Validate  GET Consent-v1 API
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


Scenario: 4 POST UpgradeToFullRegistrationGT-v1 API
	Given I have endpoint to hit /player/upgradeToFullRegistrationgt-v1
	Then I build the upgrade to full registration post request using Jaya, Dey
	#using <firstName>, <lastName>,  <isMale>, <countryCode>, <city> ,<zip> ,<street> ,<phonePrefix> ,<phoneNumber>, <securityQuestionTag> ,<securityAnswer> 
	Then I hit the request
	Then I verify HTTP status code


	#Examples: 
	#| firstName | lastName | 
	#isMale | countryCode | city   | zip  | street                 | phonePrefix | phoneNumber | securityQuestionTag         | securityAnswer |
	#| Jayashree  | Dey     | 
	#true   | AT          | Vienna | 1050 | Wiedner Hauptstraße 94 | 43          | 12345678    | squestion_make_of_first_car |  Ferrari       | 

Scenario Outline: 5 POST Purchase-v1 API
Given I have endpoint to hit purchase page api/purchase-v1
Then I build the post request for purchase for <item>, <paymentTypeId>, <country>, <landingURl>
Then I hit the request
Then I verify HTTP status code



Examples: 

| item | paymentTypeId | country | landingURl                               |
| m    | adyenEPS      | AT      | https://www.gametwist.com/en/?modal=shop |



	













