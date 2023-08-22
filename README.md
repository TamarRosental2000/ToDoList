# ToDoList base CQRS- Command-query Separation Prinsiple
Rest Api Manage  a TODO List 
Command - Produced side-effects vs Query - Side-effect free
change Server in ToDoListDBContext.cs on line 21 to server name
on windows powershell on ToDoList\ToDoList.csproj execute 2 command
dotnet ef migrations add InitialModel
dotnet ef database update
