Feature: Login

Scenario: 1 Verify login is successful with valid username and password
	Given I have endpoint to hit /login-v1/
	And I build login post request with Testing768 and Welcome_2_gametwist
	Then I hit the request 
	Then I verify HTTP status code
	And I extract the token from the response


Scenario Outline: 5 POST Purchase-v1 API
Given I have purchase page endpoint to hit /purchase-v1
Then I build the post request for purchase for <item>, <paymentTypeId>, <country>, <landingURl>
Then I hit the request
Then I verify HTTP status code
And I extract the value of paymentRedirectUrl



Examples: 

| item | paymentTypeId | country | landingURl                               |
| m    | adyenEPS      | AT      | https://www.gametwist.com/en/?modal=shop |