# Appointment Scheduling Application

A C# Windows Forms application for managing customer appointments with multi-language support, time zone handling, and comprehensive reporting capabilities.

## Project Overview

This application was developed as part of the WGU C969 - Software II course. It demonstrates advanced C# programming concepts including database integration, localization, lambda expressions, and exception handling.

## Features

### Core Functionality
- **Customer Management**: Full CRUD operations for customer records with validation
- **Appointment Scheduling**: Create, modify, and delete appointments with business rule enforcement
- **Multi-Language Support**: Login interface available in English and Spanish
- **Time Zone Handling**: Automatic adjustment between user local time and Eastern Standard Time
- **Calendar View**: Interactive calendar for viewing appointments by date
- **Reporting**: Generate three types of reports using lambda expressions
- **15-Minute Alert**: Notification system for upcoming appointments

### Business Rules
- Appointments must be scheduled during business hours: 9:00 AM – 5:00 PM EST, Monday-Friday
- Prevents scheduling of overlapping appointments
- Validates all customer and appointment data before saving

## Technology Stack

- **Framework**: .NET Framework 4.7.2
- **Language**: C# 
- **Database**: MySQL 8.0+
- **IDE**: Visual Studio 2022
- **Libraries**: 
  - MySql.Data (9.5.0)
  - Windows Forms

##  Getting Started

### Prerequisites
- Windows Operating System
- Visual Studio 2022 (Community, Professional, or Enterprise)
- MySQL Server 8.0 or higher
- .NET Framework 4.7.2

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/scheduler-app.git
   cd scheduler-app
   ```

2. **Set up the database**
   - Open MySQL Workbench
   - Create a new database named `client_schedule`
   - Run the SQL script: `Database/C969_DB_Setup.sql`
   - (Optional) Run `Database/C969_Test_Data.sql` for sample data

3. **Configure the connection string**
   - Open `App.config`
   - Update the connection string with your MySQL credentials:
     ```xml
     <connectionStrings>
       <add name="client_schedule"
            connectionString="Server=localhost;Port=3306;Database=client_schedule;Uid=YOUR_USER;Pwd=YOUR_PASSWORD;"
            providerName="MySql.Data.MySqlClient" />
     </connectionStrings>
     ```

4. **Build and run**
   - Open the solution in Visual Studio 2022
   - Restore NuGet packages
   - Build the solution (F6)
   - Run the application (F5)

### Default Login Credentials
- **Username**: `test`
- **Password**: `test`

##  Reports

The application includes three lambda-based reports:

1. **Appointment Types by Month**: Shows count of each appointment type grouped by month
2. **User Schedules**: Displays all appointments organized by user
3. **Appointments by Customer**: Summary of total, upcoming, and past appointments per customer

##  Localization

The login form supports English and Spanish. The application automatically detects the system locale and displays the appropriate language. To test Spanish:

1. Change Windows display language to Spanish, OR
2. Modify `LoginForm.cs` line 25 to force Spanish:
   ```csharp
   ApplyLocalization(new CultureInfo("es"));
   ```

##  Activity Logging

All login attempts are recorded in `Login_History.txt` with the following format:
```
2026-02-15 14:23:45    test    Success
2026-02-15 14:25:12    admin   Failed
```

