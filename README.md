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

## Class Diagrams

## WPF

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

By the end of sprint 3, I aim to have all of my GP/ Patient CRUD functionality linked from my business layer to my GUI.

#### Sprint Goals

- [ ] Complete user story 2.1 - Store and change medical information
- [ ] Complete user story 2.2 - Store and change allergy information
- [ ] Complete user story 2.3 - Store and change immunisation information
- [ ] Complete user story 2.4 - Allow patients to input concerns
- [ ] Complete user story 2.5 - Patient CRUD functionality - linked to a GP
- [ ] Update read me file
- [ ] Commit all changes from local to github
- [ ] Complete agile retrospective

#### Sprint Review



#### Sprint Retrospective

