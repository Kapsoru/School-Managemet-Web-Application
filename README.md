# School Management Web Application

Welcome to the School Management Web Application repository! This project is developed using ASP.NET Core MVC and aims to streamline and enhance the administration of educational institutions.

## Overview

The School Management Web Application provides a comprehensive platform for managing various school activities and operations. It is designed to facilitate efficient handling of tasks such as student enrollment, attendance tracking, grade management, teacher assignments, and more.

## Features

- **Student Management**: Easily enroll and manage student information, including personal details, class assignments, and academic records.
- **Teacher Management**: Manage teacher profiles, subject assignments, and schedules.
- **Class Management**: Create and organize classes, assign students and teachers, and manage timetables.
- **Attendance Tracking**: Record and monitor student and teacher attendance with ease.
- **Grading System**: Manage and track student grades, generate report cards, and provide academic performance insights.
- **Parent Portal**: Provide parents with access to their child's academic progress and school activities.
- **User Authentication and Authorization**: Secure login and role-based access control for different user types (admin, teacher, student, parent).

## Technologies Used

- **ASP.NET Core MVC**: The primary framework for building the web application.
- **Entity Framework Core**: For database management and interaction.
- **SQL Server**: The database system used for storing application data.
- **Bootstrap**: For responsive and modern UI design.
- **JavaScript/jQuery**: For enhanced interactivity and dynamic content.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended) or any preferred IDE

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Kapsoru/School-Managemet-Web-Application.git
   cd School-Managemet-Web-Application
   ```

2. **Set up the database**:
   - Update the `appsettings.json` file with your SQL Server connection string.
   - Run the following command to apply migrations and create the database:
     ```bash
     dotnet ef database update
     ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. **Access the application**:
   Open your web browser and navigate to `https://localhost:5001` (or the appropriate URL provided in the terminal).

## Contributing

We welcome contributions to enhance the School Management Web Application. If you are interested in contributing, please follow these steps:

1. **Fork the repository**.
2. **Create a new branch**: `git checkout -b feature/your-feature-name`
3. **Make your changes**.
4. **Commit your changes**: `git commit -m 'Add some feature'`
5. **Push to the branch**: `git push origin feature/your-feature-name`
6. **Create a Pull Request**.

## License

This project is Free of charge

## Contact

If you have any questions or need further assistance, please feel free to contact us at [gnsmad9@gmail.com](mailto:gnsmad9@gmail.com).

Paypal Donation: gnsmad9@gmail.com

---

Thank you for using the School Management Web Application! We hope this tool helps in effectively managing your educational institution.
