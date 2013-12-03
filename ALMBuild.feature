Feature: ALMBuild
	In order to check if ALM portal builds are working properly


Scenario: A build can be built from the Alm portal interface
	Given I have typed Main-ALMFETDS in the build definitions search box
	When I finished typing
	Then The returned result will display Main-ALMFETDS as the first option
	And I can click on it to display the queue button 
	And I click on it to go to Queue Build for Main-ALMFETDS screen
	And I click on queue build at the bottom of the page to queue the build
	And I can see the Build summary screen

	Scenario Outline: 
	Given I am on ASOS ALM portal
	When I enter environment name <env_name> in the search box
	Then The returned result will display environment name <env_name> as the first option
	  
	Examples: 
	| env_name      |
	| Main-ALMFETDS |

	Scenario: search for build
	Given I am deploying main alm build
	When I search for MAIN-ALMBUILD
	Then I should get compiled buils


	Scenario: build searched build
	Given I have found the compiled deploy
	Then I can queue it by pressing queue build button


	 
