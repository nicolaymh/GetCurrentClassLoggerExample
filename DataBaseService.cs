using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetCurrentClassLoggerExample
{
    // Define a basic interface for Person entities.
    interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
    }

    // Implements the IPerson interface.
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    /// <summary>
    /// Manages database operations for person entities.
    /// Uses NLog for logging important information and errors.
    /// </summary>
    public class DataBaseService
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private List<IPerson> _people;

        /// <summary>
        /// Initializes the database with default data.
        /// </summary>
        public DataBaseService()
        {
            _people = new List<IPerson>
            {
                new Person { Id = 1, Name = "Juan Perez", Email = "juanperez@example.com" },
                new Person { Id = 2, Name = "Ana Lopez", Email = "analopez@example.com" },
                new Person { Id = 3, Name = "Carlos Gomez", Email = "carlosgomez@example.com" },
                new Person { Id = 4, Name = "Sofia Castro", Email = "sofiacastro@example.com" },
            };

            _logger.Info("Initialized database with 4 initial people.");
        }

        /// <summary>
        /// Retrieves a person by ID.
        /// </summary>
        /// <param name="id">The ID of the person to retrieve.</param>
        public void GetPersonById(int id)
        {
            try
            {
                var person = _people.FirstOrDefault(p => p.Id == id);
                if (person == null)
                {
                    _logger.Warn($"No person found with the specified ID: {id}");
                    throw new Exception($"No person found with the specified ID: {id}");
                }

                _logger.Info($"Person found => Id: {person.Id}, Name: {person.Name}, Email: {person.Email}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error retrieving person by ID.");
            }
        }

        /// <summary>
        /// Retrieves and logs all people in the database.
        /// </summary>
        public void GetAllPeople()
        {
            try
            {
                _logger.Info("Listing all people:");
                _logger.Info($"{"".PadRight(90, '-')}");

                foreach (var person in _people)
                {
                    _logger.Info($"{person.Id.ToString().PadRight(38)} | {person.Name.PadRight(20)} | {person.Email.PadRight(30)}");
                }

                _logger.Info($"{"".PadRight(90, '-')}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error retrieving all people.");
            }
        }

        /// <summary>
        /// Adds a new person to the database and logs the operation.
        /// </summary>
        /// <param name="person">The person to add.</param>
        public void AddPerson(Person person)
        {
            try
            {
                if (person == null)
                {
                    throw new ArgumentNullException(nameof(person), "The person cannot be null.");
                }

                _people.Add(person);
                _logger.Info($"Added new person: Id={person.Id}, Name={person.Name}, Email={person.Email}");

                GetAllPeople();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error adding new person.");
                throw;
            }
        }
    }
}
