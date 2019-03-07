# _Hair Salon_

#### _An MVC web application for a hair salon, Created 3/1/19, Updated 3/4/19 - 3/7/19_

#### By _**Micaela Jawor**_

## Description

A program (using C#) that allows the owner of a salon to add a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.

## Specifications

* As a salon employee, I need to be able to see a list of all our stylists.
* As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
* As an employee, I need to add new stylists to our system when they are hired.
* As an employee, I need to be able to add new clients to a specific stylist.
* I should not be able to add a client if no stylists have been added.

## Setup/Installation Requirements
##### Download the required software
* _Download .NET Core 1.1.4 SDK and .NET Core Runtime 1.1.2 and install them._
* _Download Mono and install it._

##### Clone the repository
* _Please visit the Hair Salon repository <a href="https://github.com/MicaelaDJ/HairSalon.Solution">at this link</a>._
* _Clone repository or download to desktop_

##### Compile and open in Mono
* _Change into the work directory: $ cd HairSalon.Solution
* _Open files using IDE (Atom or Visual Code Studio) to view code._
* _To run the program, first navigate to the location of the HairSalon folder then compile and execute: $ mcs Program.cs Models/HairSalon.cs; mono Program.exe;_

##### Run Tests
* _To run the tests, use these commands: $ cd HairSalon.Tests $ dotnet test_

##### Open in Browser
* _Open Mac Terminal or Windows Command Prompt._
* _Type "cd HairSalon.Solution" and press enter to go to the solution directory._
* _Type "cd HairSalon" and press enter to go to the application directory._
* _Type "dotnet restore" and press enter_
* _Type "dotnet build" and press enter_
* _Type "dotnet run" and press enter_
* _Open a web browser and go to_ http://localhost:5000/

##### Import MySql Database
* Open your preferred database manager
* Import hair_salon.sql

##### MySql Database Recreation
* Open MySql in your preferred terminal, see [MySql Documentation](https://dev.mysql.com/doc/) for further instructions
* Execute commands CREATE DATABASE hair_salon;, and USE hair_salon; to create and select the database
* Execute commands CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), experience TINYINT(4));, CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255));

## Known Bugs

_Edit client does not allow you to update or edit clients._

## Support and contact details

_If you run into any issues or have questions, ideas or concerns.  Please email me @ micaelajawor@yahoo.com_

## Technologies Used

* _Atom_
* _C#_
* _MySql_
* _AspNetCore_
* _Microsoft SDK_

### License

*MIT*

Copyright (c) 2019 **_Micaela Jawor_**
