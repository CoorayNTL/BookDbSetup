# BookDbSetup

<img width="1521" height="922" alt="Screenshot 2025-08-29 173710" src="https://github.com/user-attachments/assets/b00e8239-e7fa-4d2d-98eb-594caf7761bf" />

## Overview
This project implements a containerized MySQL database setup using Docker Compose to modernize development workflows for a simplified publishing domain. It includes three entities—Author, Book, and Publisher—with an initial schema, sample data seeding, and a schema migration. The solution leverages Docker Compose to ensure a repeatable and isolated environment.

## Entities
- **Author**: ID (primary key), name (string), country (string)
- **Book**: ID (primary key), title (string), publication_year (integer), author_id (foreign key to Author)
- **Publisher**: ID (primary key), name (string), city (string)

## Setup
1. **Prerequisites**:
   - Install Docker and Docker Compose.
   - Ensure Docker Desktop is running.

2. **Configuration**:
   - Update the `docker-compose.yml` file with the MySQL image if needed.
   - Adjust environment variables (e.g., `MYSQL_ROOT_PASSWORD`) in `docker-compose.yml` if desired.

3. **Build and Run**:
   - Navigate to the project directory in a terminal.
   - Run `docker-compose up --build` to start the containers.
   - The MySQL database will initialize, apply the schema, seed data, and perform the migration.

4. **Verification**:
   - Access the database using a MySQL client (e.g., `mysql` command-line tool or a GUI like MySQL Workbench) with the container name (`db`), root user, and password from `docker-compose.yml`.
   - Connect to `localhost:3306` (or the mapped port) and the database `publishing_db` to check the tables and data.
