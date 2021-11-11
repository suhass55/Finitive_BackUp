Feature: FinitiveDataValidationUser
	#InvoiceCodingRule, LoginandLogout, MyAccountDataValidation, UserAdminFeature, Covid19, TaxExDataValidation

	@312 @Regression @Smoke
Scenario: 312: Finitive_Signup process in the Application
	Given Navigate to Finitive url And Verify 'Finitive(UAT)'
	Then Click On Signup Button In The Header
	And Verify User Navigates to 'Sign Up' Page
	Then Enter Valid Signup Details
	And Enter Company Name And Your Use From FinitivePlatform
	Then Verify The Expected Question 'Are you an institutional investor?' Is Desplayed
	Then Select The Institutional Investor Checkbox As 'Yes'
	And Verify Describe Company Question 'Which of the following best describe your company? Please check all that apply.' Is Displayed
	Then Select The Option Describing The Company
	Then Click On Signup
	Then Login And Click On Verify Button From Registered Email
	Given Navigate to Finitive url And Verify 'Finitive(UAT)'
	Then Login And Verify User Created In The Admin Portal
	