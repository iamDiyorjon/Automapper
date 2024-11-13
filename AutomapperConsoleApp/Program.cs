using AutomapperConsoleApp;

CustomMapper mapper = new CustomMapper();
mapper.CreateMap<Source, Destination>();

Source person = new Source();
person.Age = 26;
person.Name = "Diyorjon";
person.BirthDay = new System.DateTime(1998, 07, 30);

var personDto = mapper.Map<Source, Destination>(person);

Console.WriteLine(personDto);