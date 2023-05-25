Feature: Add/Update Cart

To verify user is able to add/edit the cart 

Scenario: User is able to add,edit items in to and from the cart

	Given I add four random items to my cart
	When I view my cart
	Then I find total four items listed in my cart
	When I search for lowest price item
	And I am able to remove the lowest price item from my cart
	Then I am able to verify three in my cart
