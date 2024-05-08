# Project Name: Database Service Logger Example 📘

## Description 📝
This example project demonstrates the use of NLog for advanced logging in a .NET 6 console application. It focuses on managing a collection of "Person" objects in memory, enabling operations such as adding, retrieving, and listing people, and details how to log these operations effectively.

## Features 🌟
- **Person Management**: Implements functionalities to add, retrieve, and list people in memory.
- **Advanced Logging with NLog**: Uses NLog to log events and errors in detail.
- **Daily and Colored Log Files**: Configures logs that are stored daily and displayed in the console with color coding.

## Technologies Used 💻
- **C#**
- **.NET 6**
- **NLog**

## Project Structure 🏗️
- `IPerson`: Interface that defines the structure of a "Person" entity.
- `Person`: Concrete class that implements the `IPerson` interface.
- `DataBaseService`: Class that simulates database operations and handles logging.

## NLog Configuration 🛠️
NLog is configured to log data to two destinations:
- **Files**: Logs are stored daily with detailed information on operations and exceptions.
- **Console**: Output in the console with logs colored according to the severity level, facilitating debugging and real-time monitoring.

### Log Layout
Logs include the date and time, the logger, the severity level, the code location, the log message, and any captured exception, all formatted for easy reading and analysis.

## How to Use 🚀
1. **Clone the Repository**: Clone this repository to your local machine.
2. **Set Up the Development Environment**: Ensure you have .NET 6 and NLog configured.
3. **Run the Application**: Run the application from your development environment or from the command line. Observe how logs are generated in the console and in daily files.

## License 📜
This project is distributed under the MIT License, allowing free use, modification, and distribution within the terms of the license.
