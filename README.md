# Vueling Exam
To create this WebApi I used the DDD architecture [Domain-Driven Design(DDD)](https://vaadin.com/learn/tutorials/ddd/ddd_and_hexagonal),
a completely domain-oriented architecture. With this WebApi I they expose the application's functionalities to be integrated by other 
systems. In this case entities are managed, using data persistence in TXT file.

## Responsabilities<br/>
To solved Vueling Exam first I separate the problem in tascks, always respecting SOLID principles, <br/>
where each class and each method will have a single responsibility, trying to aply clean code  and to comply with the rule of 10x10x10.<br/>

**Good Practices**<br/>
**1 - SOLID**<br/>
*Single Responsibility* <br/>
“class should be having one and only one responsibility”<br/>
	-RebeldController<br/>
	-RebeldService<br/>
	-RebeldRepository<br/>
*Open-Closed*<br/>
“classes should be open for extension but closed for modification”<br/>
*Liskov substitution*<br/>
“parent classes should be easily substituted with their child classes without blowing up the application”<br/>
*Interface Segregation*<br/>
“many client specific interfaces are better than one general interface”<br/>
-IRepository<br/>
-IRegister<br/>
-IInfrastructureReposiotry<br/>
-IService<br/>
*Dependency Injection*<br/>
“classes should depend on abstraction but not on concretion”<br/>
-AutofacConfiguration<br/>
-FacadeModule<br/>
-ServiceModule<br/>
-ILog<br/>

**2 - DDD Architecture**<br/>
*Business Facade*<br/>
*Application Logic*<br/>
*Infrastructure Repository*<br/>
*Domain Entity*<br/>

**3 - Design Patterns**<br/>
[Aggregate](https://martinfowler.com/bliki/DDD_Aggregate.html)<br/>
-Rebeld<br/>
[Seedwork](https://martinfowler.com/bliki/Seedwork.html)<br/
 [Generic Repository](https://codewithshadman.com/repository-pattern-csharp/)<br/>
-IRepository<br/>
[Builder](https://refactoring.guru/design-patterns/builder)<br/>
-IoCSuportedTest<br/>
-AutofacModule<br/>
[Facade](https://www.tutorialspoint.com/design_pattern/facade_pattern.htm)<br/>
-Business Facade<br/>
[Publisher-Subscriber](https://docs.microsoft.com/en-us/azure/architecture/patterns/publisher-subscriber) -> Events Oriented Program<br/>
-Publisher(Controller)<br/>
-Suscriber(Filters)<br/>

**4 - Clean Code**<br/>
*DRY* Don’t repeat yourself<br/>
*KIS* Keep it simple<br/>
---------------------------------------
**Class and Implementation**<br/>
**Business Facade**<br/>
**AutofacConfiguration** Se configura Autofac para inyectar todas las capas desde que arranque la aplicacion<br /> 
**WebApiConfiguration**Configuracion y servicios de la Api, defino la ruta y agrego los filtros.<br/>
**FacadeModule**Modulo de la capa Business Facade, es inyectado desde AutofacConfiguration e inyecta a su vez a ServiceModule.<br/>
**LoggingModule**Log4net is activated by events.<br/>
**IController** Controller interface.<br/>
**RebeldController** Controller class, implements IController and apply the HTTPverbs( [HTTPPOST])<br/>
POST<br/>
The POST method is used to submit an entity to the specified resource, often causing a change in state or side effects on the server.<br/>

**NotImplementationFilterAttribute** Class that catches the exception filters between the web server and the web client. <br/>

**Application Logic**<br/>
**ServiceModule** Module from Application Logic Layer, is injected by FacadeModule and inject to Infrastructure Repository.<br/>
**IService**Interface implementaded by RebeldService class.<br/>
**RebeldDto** It’s a module class, only has properties.<br/>
**RebeldService** Service class, communicates Business Facade Layer with Infrastructure Repository Layer. In this layer I assing DataTime to the entity.<br/>

**Infrastructure Repository**<br/>
**IInfrastructureRepository** Interface implemented by RebeldRepository class, and implemet IRepository interface (Domain Entities).<br/>
**RebeldRepository** Repository class, takes care of data persistence. Communicates with Service class and Domain Entities.<br/>

**Domain Entities**<br/>
**Rebeld** It’s a module class, only has properties.<br/>
**IRegister** Is a generic class that implements Register() method.<br/>
**IRepository** Is a generic class that implements IRegister <T> method.<br/>

**Test Libraries**<br/>
**IoCSupportedTest** Create the Container and resolve dependencies with Container.Resolve<T>().<br/>
**LoggingModule** Log4net is activated by events. <br/>
----------------------------------------------------------------------------
## Technology Stack<br/>
C#   -   .Net Framework     -   Git   -   SonarLint -   Autofac   -   Autofac.Extras.Moq   -   Autofac.WebApi2   -   Log4Net   -    Linq    -    Postman 

