Feature: SignUp

Testing the Sign up flow

@signup
Scenario: Select only one country
	Given Logged in with test user
	Then Sign up page displayed
	When Set Where is your business loacated to 'Hungary'
	And Select random primary countries '3'
	And Click all Get VAT number buttons
	And Click Next step button
	Then Business details page displayed
	When Set Legal status to 'Company'
	And Set Full legal name
	And Set random Incorporation number
	And Pick current date
	And Set random State
	And Set random ZIP
	And Set random City
	And Set random Street
	And Set random House number
	And Click Next step button

