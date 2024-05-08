using GetCurrentClassLoggerExample;



var person = new DataBaseService();
person.GetAllPeople();
person.GetPersonById(5);
person.AddPerson(new Person { Id = 5, Name = "Linda Castaño Moreno", Email = "linda@correo.com" });
person.GetPersonById(5);
person.AddPerson(null);

