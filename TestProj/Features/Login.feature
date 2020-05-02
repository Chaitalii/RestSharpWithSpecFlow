Feature: Login


@mytag
Scenario: Get the token after login for given endpoint
	Given I have endpoint to hit /login-v1/
	And I hit post request with Testing768, Welcome_2_gametwist
	Then I verify HTTP status code
	And I extract the token from the response
		 
		 