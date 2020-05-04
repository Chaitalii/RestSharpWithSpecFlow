Feature: Login

Scenario Outline: 1 Verify login is successful with valid username and password
	#Given I have login endpoint to hit <endpoint>
	And I execute login request with userId <userId> and password <password>
	Then I verify response code is OK
	
	Examples: :
	| endpoint | userId     | password            |
	|/login-v1/| Testing768 | Welcome_2_gametwist |

Scenario Outline: 2 Validate logged in user is able to send consent types

	#Given I have endpoint to hit /consent/consent-v1
	And I execute post request for given consent type <consentType> and accepted value as <accepted>
	And I store the <consentType> and accepted <accepted>
	Then I verify response code is OK

	Examples: 
	| consentType               | accepted |
	| GeneralTermsAndConditions | true |
	| DataPrivacyPolicy         | true |
	| MarketingProfiling        | true |

Scenario Outline: 3 Validate  GET Consent-v1 API
#	Given I have endpoint to hit /consent/consent-v1
	And I execute get request for consent type <consentType>
	And I fetch the accepted value for <consentType>
	And I validate the value of wasAccepted field

	Examples: 
	| consentType               |
	| GeneralTermsAndConditions |
	| MarketingProfiling        |
	| DataPrivacyPolicy         |




Scenario Outline: 4 POST UpgradeToFullRegistrationGT-v1 API
	#Given I have endpoint to hit /player/upgradeToFullRegistrationgt-v1
	Then I execute UpgradeToFullRegistrationGT request using <firstName>,<lastName>,<isMale>,<countryCode>,<city>,<zip>,<street>,<phonePrefix>,<phoneNumber>,<securityQuestionTag>,<securityAnswer> 
	Then I verify response code is OK


	Examples: 
	| firstName | lastName | isMale | countryCode | city   | zip  | street                 | phonePrefix | phoneNumber | securityQuestionTag         | securityAnswer |
	| Johnatha  | Doey     | true   | AT          | Vienna | 1050 | Wiedner Hauptstraße 94 | 43          | 12345678    | squestion_make_of_first_car |Ferrari       | 




Scenario Outline: 5 POST Purchase-v1 API
#Given I have purchase page endpoint to hit /purchase-v1
Then I execute post request for purchase for <item>, <paymentTypeId>, <country>, <landingURl>
Then I verify response code is OK
And I extract the value of paymentRedirectUrl

Examples: 

| item | paymentTypeId | country | landingURl                               |
| m    | adyenEPS      | AT      | https://www.gametwist.com/en/?modal=shop |




Scenario: 6 Login to browser
Given I have navigated to paymentRedirectUrl
#And I wait until Next button is displayed
Then I click on Next button
And I select the bank
Then I click on Continue button
And I add random values to the two input boxes
Then I click on the login button
Then I verify the failure message
And I click on Cancel button
Then I take the screenshot