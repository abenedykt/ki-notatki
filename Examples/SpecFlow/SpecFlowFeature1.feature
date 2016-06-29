Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Other adding scenario
	Given I have entered 1500 into the calculator
	And I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 1620 on the screen

	 
Scenario:  other failing
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press multiply
	Then the result should be 120 on the screen
