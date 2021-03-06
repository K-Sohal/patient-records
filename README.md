# Patient Medical Records

## Project Overview

### Application Description

The application should assist General Practitioners (GPs) when recording patient information during appointments. By using an efficient and simple application, the GP is able to enter patient details quickly and save valuable time. Additionally, the application allows patients to view their own records and submit any concerns they have. The GP can view these concerns ahead of time and address them during the next appointment.

### Project Goals

Design goals:
* Produce a 3 tier application consisting of a SQL database, C# business and WPF GUI layer
* The business layer should be unit tested
* The database should have at least two linked tables
* Project should have concise documentation

User specific goals:
* User authentication system
* GP/patient CRUD functionality
* High usability for data entry
* Data security

## Class Diagram

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/ClassDiagram.png?raw=true "Class Diagram")

## WPF

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/WPF1.png?raw=true)

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/WPF2.png?raw=true)

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/WPF3.png?raw=true)

## Sprint Breakdowns

### Sprint 1 - 01/12/2020

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/StartofSprint1.png?raw=true "Start of Sprint 1")

By the end of sprint 1, I aim to have a three tier application with basic functionality and a basic user interface.

#### Sprint Goals

- [x] Complete user story 0.1 - Create a database
- [ ] Complete user story 0.2 - Create a basic GUI
- [ ] Complete user story 0.3 - Create a business layer
- [x] Complete user story 0.4 - Complete initial documentation
- [x] Update read me file
- [x] Create local git folder
- [x] Commit all changes from local to github
- [x] Complete agile retrospective

#### Sprint Review

Documentation and database design was completed. The create and delete functionality of the business layer was implemented. The update functionality needs to be added to the business layer, also the business layer needs to be unit tested. The GUI needs to be created.

#### Sprint Retrospective

Not all user stories were completed, in part due to limited time this sprint because of a test. Additionally, I got carried away with the database design by adding features that were not priority. This increased the complexity of the design and therefore increased the time taken to develop the database and the business layer. The GUI looks like it will take a lot of time and is a large part of the project due to the database having many tables. Therefore user story 0.2 - Create a GUI should be broken down into sub tasks as this will most likely take more than one sprint to complete.


![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/EndofSprint1.png?raw=true "End of Sprint 1")

### Sprint 2 - 02/12/2020

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/StartofSprint2.png?raw=true "Start of Sprint 2")

By the end of sprint 2, I aim to have my business layer completed with some unit tests. Also I would like to create a GUI for GP CRUD functionality and link it to my business layer.

#### Sprint Goals

- [x] Complete user story 0.3.4 - Test business layer
- [x] Complete user story 0.3.3 - Add update functionality to business layer
- [x] Complete user story 0.3 - Create a business layer
- [x] Complete user story 0.2 - Create a basic GUI for GP CRUD functionality
- [x] Update read me file
- [x] Commit all changes from local to github
- [x] Complete agile retrospective

#### Sprint Review

All of my sprint goals were completed. The business layer has been tested for GP CRUD functionality through some unit testing and some manual testing via the GUI. A basic GUI for GP CRUD functionality was created which can been used as a base for further CRUD operations. A problem I had was changing the ListBox display for GP objects. To solve this, I had to override the ToString method for the GP class by using a partial class customisation.

#### Sprint Retrospective

As mentioned in the last sprint, creating the GUI and linking it to the business layer takes a large amount of time. Partially due to WPF inexperience and partially to the complexity of my project. This was evident today during my sprint as the majority of my time was used to create the GUI. Therefore it is a good idea to allocate more time to GUI related tasks in upcoming sprints. I also encountered an issue where build creation in Visual Studio was taking a really long time. This was solved by closing and reopening my project.

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/EndofSprint2.png?raw=true "End of Sprint 2")

### Sprint 3 - 03/12/2020

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/StartofSprint3.png?raw=true "Start of Sprint 3")

By the end of sprint 3, I aim to be able to have Patient, Medication, Vaccines, Allergy and Concerns CRUD functionality.

#### Sprint Goals

- [x] Complete user story 2.1.1 - Medication CRUD
- [x] Complete user story 2.2.1 - Allergy CRUD
- [x] Complete user story 2.3.1 - Immunisation CRUD
- [ ] Complete user story 2.4 - Concerns CRUD
- [x] Complete user story 2.5 - Patient CRUD functionality - linked to a GP
- [x] Update read me file
- [x] Commit all changes from local to github
- [x] Complete agile retrospective

#### Sprint Review

In this sprint I managed to implement a large amount of CRUD functionality. I also managed to link a patient to a GP so that the GP can only see a list of their own patients. Concerns CRUD still needs to be completed because I ran out of time. In this sprint, I learned how to pass an instance of a class to multiple pages by overloading the page constructor. I also learned about the DatePicker control for selecting DateTime types which is used for patient date of birth. 

#### Sprint Retrospective

The sprint went well however I overestimated how much I could get done today. I had to break down the user stories as I would not have had time to link the CRUD functions to the patients. This will be the goal of the next sprint.

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/EndofSprint3.png?raw=true "End of Sprint 3")

### Sprint 4 - 04/12/2020

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/StartofSprint4.png?raw=true "Start of Sprint 4")

By the end of sprint 4, I aim to link patient record functionality to individual patients.

#### Sprint Goals

- [x] Complete user story 2.1 - Medication CRUD
- [x] Complete user story 2.2 - Allergy CRUD
- [x] Complete user story 2.3 - Immunisation CRUD
- [x] Complete user story 2.4 - Concerns CRUD
- [x] Update read me file
- [x] Commit all changes from local to github
- [x] Complete agile retrospective

#### Sprint Review

In this sprint I was able to meet all of my sprint goals. The GP can now enter patient medication, allergies, immunisation and any concerns for each of their patients. I was able to finish the goals before the sprint ended so I started working on User Story 1 - Creating an authentication system. I created the pages for GP login and registration which I will be linking to my business layer in the next sprint.

#### Sprint Retrospective

I managed to complete all user stories in a short amount of time due to modifying the database to make it simpler so that the MVP can be achieved. With the remaining time I moved onto authentication but also spent some time making the GUI look like a medical application. To improve on this sprint I could have stayed on task better by only moving onto the prioritised user stories after finishing the sprint goals. Additionally, I lost some motivation to get work done when all sprint goals were achieved, therefore self motivation when completing goals early is a key improvement point for future sprints.

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/EndofSprint4.png?raw=true "End of Sprint 4")

### Sprint 5 - 06/12/2020

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/StartofSprint5.png?raw=true "Start of Sprint 5")

By the end of sprint 5, I aim have complete GP registration and login functionality. I also aim to add validation checks on this process and other CRUD functionality so that the application no longer crashes on empty or null input.

#### Sprint Goals

- [x] Complete user story 1.1
- [x] Complete user story 1.1.1
- [x] Complete user story 1.2
- [x] Complete user story 1.2.1
- [x] Complete user story 1.2.2
- [x] Complete user story 1.2.3
- [x] Commit all changes from local to github
- [x] Complete agile retrospective
- [x] Add class diagrams to read me
- [x] Add application screenshots to read me

#### Sprint Review

In this sprint I was able to meet all of my sprint goals. The GP can now register with an email and password and login to the application. I added input validation so that all registration fields must be entered to register. Additionally, if an email already exists in the database then a new user cannot register with the same email. All my error handling were in the form of nested if else conditions. In the future I would like to use try catch exceptions instead and create my own exceptions or use a validation package such as Fluent Validation which makes user input validation more manageable.

#### Sprint Retrospective

This is my final sprint and I feel like I have achieved all the basic functionality that a GP would need. In order to improve this sprint, it may have been useful to learn about validation checking and error handling before writing my code. If I had done this, then I would have been able to write cleaner code instead of using many nested if conditions.

![](https://github.com/K-Sohal/patient-records/blob/main/DocumentationImages/EndofSprint5.png?raw=true "End of Sprint 5")

## Project Review

The project MVP was achieved and additional features were added. The remaining user stories increase the usablity of the application. The application passes all unit tests. Extensive manual testing has been performed with the GUI to ensure that normal function does not result in program crashes. All documentation has been completed to the required standard.

## Project Retrospective

At the beginning of the project there was too much project scope for the given timeframe. Midway through the project the scope was reduced which resulted in a usable product which was then added upon in the following sprints. As the project progressed, adding more and more features to the minimum viable product was enjoyable because there was no pressure to complete a working prototype.
