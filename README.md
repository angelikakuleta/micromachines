# Micromachines - Part I

## Story

You are asked to create an internal web shop like portal, which provides micromachinery from a catalog of products. The company already has multiple services which run across it's enterprise operation. Many services are shared by various application 

Services provide information such as:
- Users
- Products
- Orders
- Transactions
- Reporting
- Stock
- Departments

You will only need to consume some of them and some of them will need to develop.

Just like in any shop you will want to be able to purchase products available in the catalog. You can purchase any product as long as you have the necessary account balance and the product is in stock.

## What are you going to learn?

- Implement an app in a Service Oriented fashion (SOA)
- Place your and run solution in a single Docker container (Containerization)
- Decompose a monolithic app into a Microservices approach
- Place each microservice in to seperate container
- Define and run your multi-container solution using Docker Compose

## Tasks

1. The High Level Design requires you to complete the following user stories on top of some technical steps that we describe below    
    - As a `User` I want to be able to browse products
    - As a `User` I want to browse the history and status of my orders
    - As a `User` I want to browse the history of my purchases
    - As a `User` I want to filter products by category
    - As a `User` I want to have multiple Balance Account
    - As a `User` I can purchase a product from the Stock
    - As a `User` I can purchase a product from the Stock only if I have enough balance in my account and there is enough stock supplied
    - As a `User` I can purchase a product by creating an order. Orders consist of an itenarary. An order can be accepted only if all products are available. Otherwise an order is denied.        
    - As a `User` I can make a transfer to any account apart from the "outgoing" Account
    - An Accounts' balance cannot get below 0        
    - A Products' stock cannot get below 0 and the price must be above 0.

2. In this task, you will create an abstract Web API for your Micromachines Webshop. You do not need to implement all models, controllers and repositories, but at least 4 to get you going. Have a look a the `IUser`,  `IUserRepository` and `UserController` implementations for reference. 
    - Get familiar with the project structure
    - Implement the Models and repository store. You may use Entity Framework InMemory store for this task.
    - Implement the API Controllers for each model and make sure they provide the User Stories features.
    - Create a Docker configuration file and run your application from within a container.

3. Good job! By now you should have a functional Web API for you internal Webshop. You fiddle with it using Swagger or Postman. With our functioning application in place we want our system to be more agile and reliable. Microservice architeture organizes our solution into independent entities/services which have "a life of their own" - each of which are standalone apps, deployed independently of other services.
    - Create a new Web API project for each of your model.
    - Move the approriate controllers, models, repositories into the appropriote project.
    - Create a class library with the common dependencies ie. model interfaces.
    - Now each service has it's own URL (endpoint). Update the service references to consume the newly created endpoints instead of repository class (to which by now you should have lost access, since they are placed in a different app service 😃 )
    - Configure Docker Compose for each microservice and give it a spin.

4. You ported you monolithic Web API into a decoupled yet functional set of smaller Web APIs. A next step would be to introduce a proxy API and some client apps, such as an Angular Web Client or Mobile application, but let's leave this task for another time. Play around with your API and see how it work.
    - Test your Microservices using Postman
    - Debug 2 or 3 services in parallel in your Docker Container to make sure the workflow proceeds as expected. Set some breakpoints and test corner cases

## General requirements

- Build the project, and resolve any errors.
- Each microservice should be a standalone web api.
- Place each service in it's own container.
- Deploy your multi-container app to Azure.