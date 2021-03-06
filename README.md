# Token Login
Token Login is project that was aiming to create a usable skeleton for web developers in C#.  
The project aim is to develop a skeletion that provides a token based access using OWIN, ASP.NET Identity, WebAPI and Dependency Injection.

## Initializing the Project
Before starting to use the project, please verify that you have SQL Express installed on the computer (or SQL).  
Open the project and using the "Package Console Manager", write the "Update-Database" (without the quotes) in order  
to initialize the database.

## Project Status
The project is currently still in early stages of development.
- **Signup** [80%%] - The Signup page is working correctly, however it does not have protection against duplicate registration.
- **Login** [100%%] - The Login page is working correctly.
- **Landing Page** [80] - The Landing page is currently using a temporary design, which needs to be replaced.
- **Refresh Tokens** [80%] - Currently I do not display the option to connect with refresh tokens, due to an error in the RepositoryBase, which I need to solve.
- **Unit Testing** [0%] - The project is missing unit tests for checking that everything works correctly.

## Design
The project utilizes the [AngularJSAutentication] (https://github.com/tjoudeh/AngularJSAuthentication) layout, but will be replace in future versions.

## Environment and Tools
- **Environment** - [Windows 10](https://www.microsoft.com/en-us/windows/get-windows-10).  
- **Editor** - [Visual Studio 2015](https://www.visualstudio.com/en-us/products/vs-2015-product-editions.aspx).  
- **Markup** - HTML5.  
- **Style Sheet** - CSS3.  

## Design Patterns and Concepts
- [**Unit of Work**](http://www.codeproject.com/Articles/581487/Unit-of-Work-Design-Pattern)
- [**Repository Pattern**](https://msdn.microsoft.com/en-us/library/ff649690.aspx)
- [**Database Factory Pattern**](http://coding-geek.com/design-pattern-factory-patterns/)
- [**Dependency Injection**](https://en.wikipedia.org/wiki/Dependency_injection)
- [**Access Token**](https://en.wikipedia.org/wiki/Access_token)
- [**Refresh Token**](https://auth0.com/blog/refresh-tokens-what-are-they-and-when-to-use-them/)

## Client Side
For the client side I have decided to use the following technologies:  
1. [**AngularJS**](https://angularjs.org/).  

## Server Side
For the server side I have decide to use **Ruby on Rails** with the following gems:  
1. [**C#**](https://en.wikipedia.org/wiki/C_Sharp_(programming_language))  
2. [**WebAPI**](http://www.asp.net/web-api).  
3. [**OWIN**](http://owin.org/).  
4. [**ASP.NET Identity**](http://www.asp.net/identity).  
5. [**AutoFac**](https://autofac.org/).  
6. [**EntityFramework**](https://en.wikipedia.org/wiki/Entity_Framework).  
