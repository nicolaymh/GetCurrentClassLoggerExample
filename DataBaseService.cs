

namespace GetCurrentClassLoggerExample
{
    interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
    }

    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }


    public class DataBaseService
    {
        private List<IPerson> _people;

        public DataBaseService()
        {
            _people = new List<IPerson>
            {
                new Person { Id = 1, Name = "Juan Perez", Email = "juanperez@example.com" },
                new Person { Id = 2, Name = "Ana Lopez", Email = "analopez@example.com" },
                new Person { Id = 3, Name = "Carlos Gomez", Email = "carlosgomez@example.com" },
                new Person { Id = 4, Name = "Sofia Castro", Email = "sofiacastro@example.com" },
            };
        }

        public void GetPersonById(int id)
        {
            try
            {
                var person = _people.FirstOrDefault(person => person.Id == id)
                ?? throw new Exception($"No person found with the specified ID: {id}");

                Console.WriteLine($"Person => Id: {person.Id} name: {person.Name} - email: {person.Email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error => {ex.Message}");
            }
        }

        public void GetAllPeople()
        {
            try
            {
                // Configurar encabezados y ancho de columna
                Console.WriteLine("List of People:");
                Console.WriteLine($"{"".PadRight(90, '-')}");  // Línea divisoria para encabezados

                // Imprimir encabezados de columna
                Console.WriteLine($"{"ID".PadRight(38)} | {"Name".PadRight(20)} | {"Email".PadRight(30)}");
                Console.WriteLine($"{"".PadRight(90, '-')}");  // Línea divisoria después de los encabezados

                // Iterar sobre cada persona y imprimir sus detalles con alineación adecuada
                _people.ForEach(person =>
                {
                    // Formato de los campos para asegurar alineación
                    string id = person.Id.ToString().PadRight(38);
                    string name = person.Name.PadRight(20);
                    string email = person.Email.PadRight(30);

                    Console.WriteLine($"{id} | {name} | {email}");
                });

                // Otra línea divisoria al final para separar la salida de futuras impresiones
                Console.WriteLine($"{"".PadRight(90, '-')}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void AddPerson(Person person)
        {
            try
            {
                _people.Add(person);

                GetAllPeople();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
