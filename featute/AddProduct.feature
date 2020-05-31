Feature: Add New Product
		As a user 
		I want to create a new product in the database
		So I can create product

		Scenario: Add product 

		
		Given I open "http://localhost:5000" url
		Then I should be at the "Login" Login page
		When I type the value "user" Name
		When I type the value "user" Password
		When I click the login button 
		Then I should be at the "Home page" Home page  
		When I click on the link All Products
		And I click the Create new button
		Then I should be at the "Product editing" Product editing page
		When I type the value "King prawns" ProductName
		When I select "Seafood" Category
		When I select "Pavlova, Ltd." Supplier
		When I type the value "500" UnitPrice
		When I type the value "24 pieces" QuantityPerUnit	
		When I type the value "20" UnitsInStock
		When I type the value "3" UnitsOnOrder
		When I type the value "2" ReorderLevel
		When I click the Send button 
		Then Product Name schould be "King prawns"
		When I close the application
