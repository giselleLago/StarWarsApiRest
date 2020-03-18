# Vueling Exam
To create this WebApi I used the DDD architecture [Domain-Driven Design(DDD)](https://vaadin.com/learn/tutorials/ddd/ddd_and_hexagonal),
a completely domain-oriented architecture. With this WebApi I they expose the application's functionalities to be integrated by other 
systems. In this case entities are managed, using data persistence in TXT file.

## Responsabilities

To solved Vueling Exam first I separate the problem in tascks, always respecting SOLID principles,
where each class and each method will have a single responsibility, trying to aply clean code  and to comply with the rule of 10x10x10.


**Good Practices**<br/>
**1 - SOLID**
**Single Responsibility**
```
“class should be having one and only one responsibility”<br/>
	-RebeldController<br/>
	-RebeldService<br/>
	-RebeldRepository
```
**Open-Closed**
```
“classes should be open for extension but closed for modification”
```

**Liskov substitution**
```
“parent classes should be easily substituted with their child classes without blowing up the application”
```
**Interface Segregation**
```
“many client specific interfaces are better than one general interface”<br/>
- IRepository<br/>
- IRegister<br/>
- IInfrastructureReposiotry<br/>
- IService<br/>
```
**Dependency Injection**
```
“classes should depend on abstraction but not on concretion”
- AutofacConfiguration<br/>
- FacadeModule<br/>
- ServiceModule<br/>
- ILog<br/>
```

**2 - DDD Architecture**

```
- Business Facade
- Application Logic
- Infrastructure Repository
- Domain Entity
```

**3 - Design Patterns**
- [Aggregate](https://martinfowler.com/bliki/DDD_Aggregate.html)<br/>
-Rebeld<br/>
- [Seedwork](https://martinfowler.com/bliki/Seedwork.html)<br/>
- [Generic Repository](https://codewithshadman.com/repository-pattern-csharp/)<br/>
-IRepository<br/>
- [Builder](https://refactoring.guru/design-patterns/builder)<br/>
-IoCSuportedTest<br/>
-AutofacModule<br/>
- [Facade](https://www.tutorialspoint.com/design_pattern/facade_pattern.htm)<br/>
-Business Facade<br/>
- [Publisher-Subscriber](https://docs.microsoft.com/en-us/azure/architecture/patterns/publisher-subscriber) -> Events Oriented Program<br/>
-Publisher(Controller)<br/>
-Suscriber(Filters)<br/>

**4 - Clean Code**

```
*DRY* Don’t repeat yourself<br/>
*KISS* Keep it simple stupid<br/>
```

**Class and Implementation**<br/>
**Business Facade**<br/>
**AutofacConfiguration** <br/> Se configura Autofac para inyectar todas las capas desde que arranque la aplicacion<br /> 
**WebApiConfiguration**<br/> Configuracion y servicios de la Api, defino la ruta y agrego los filtros.<br/>
**FacadeModule**<br/> Business Facade Layer module, injected from AutofacConfiguration and in turn injects ServiceModule.<br/>
**LoggingModule**<br/> Log4net is activated by events.<br/>
**IController**<br/> Controller interface.<br/>
**RebeldController**<br/> Controller class, implements IController and apply the HTTPverbs.

**NotImplementationFilterAttribute**<br/> Class that catches the exception filters between the web server and the web client. <br/>

**Application Logic**<br/>
**ServiceModule**<br/> Module from Application Logic Layer, is injected by FacadeModule and inject to Infrastructure Repository.<br/>
**IService**<br/> Interface implementaded by RebeldService class.<br/>
**RebeldDto**<br/> It’s a module class, only has properties.<br/>
**RebeldService**<br/> Service class, communicates Business Facade Layer with Infrastructure Repository Layer. In this layer I assing DataTime to the entity.<br/>

**Infrastructure Repository**<br/>
**IInfrastructureRepository**<br/> Interface implemented by RebeldRepository class, and implemet IRepository interface (Domain Entities).<br/>
**RebeldRepository**<br/> Repository class, takes care of data persistence. Communicates with Service class and Domain Entities.<br/>

**Domain Entities**<br/>
**Rebeld**<br/> It’s a module class, only has properties.<br/>
**IRegister**<br/> Is a generic class that implements Register() method.<br/>
**IRepository**<br/> Is a generic class that implements IRegister <T> method.<br/>

**Test Libraries**
```
IoCSupportedTest
Create the Container and resolve dependencies with Container.Resolve<T>().<br/>
LoggingModule
Log4net is activated by events.
```
----------------------------------------------------------------------------
## Technology Stack<br/>
C#   -   .Net Framework     -   Git   -   SonarLint -   Autofac   -   Autofac.Extras.Moq   -   Autofac.WebApi2   -   Log4Net   -    Linq    -    Postman 

