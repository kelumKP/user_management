# Activate's Interview Project Readme

Welcome to Activate's Interview Project. This repository provides a foundational template for a modern full-stack application, offering essential functionality to demonstrate best practices and key concepts. Below, you'll find an overview of the project's features, architecture, and instructions for running the application.

Please note, this is used diring our interview process and not intended to be production ready.

---

## **Project Overview**

### **Scope and Features**

This project serves as a starting point for building scalable and maintainable applications. It includes:

- **User Management**: User registration and login functionality.
- **Authentication**: Secure JWT token-based authentication with http-only cookies for persistence.
- **CRUD Operations**: Sample Create, Read, Update, Delete operations.
- **Frontend Framework**: React with routing and state management.
- **Styling**: Material UI (MUI) integrated with a theme provider.
- **Form Handling**: React Hook Form (RHF) with validation.
- **State Management**: Redux Toolkit with local storage integration.
- **Testing**: Examples using React Testing Library (RTL), Moq, and MSTest Framework.
- **Backend Architecture**: .NET Core backend with Unit of Work and Repository patterns.
  
### **Technologies Used**

- **Frontend**: React, Redux Toolkit, React Hook Form, MUI.
- **Backend**: .NET Core with EF Core, Unit of Work, and Repository patterns.
- **Database**: PostgreSQL.
- **Testing**: React Testing Library, MSTest Framework, Moq.
- **Containerization**: Docker with multi-profile support.

This template demonstrates best practices for secure user authentication, clean architecture, and test-driven development.

---

## **Setup and Usage**

### **Docker Profiles**

This project supports two Docker profiles to accommodate different use cases:

1. **`dev`**: Runs a PostgreSQL database only. The frontend and backend must be run manually for development purposes.
2. **`docker`**: Runs all components, including the database, frontend, and backend.

---

### **Initial Setup**

#### **1. Database Migration**
Before running the application, the PostgreSQL database must be initialized with the required schema:

1. Start the `dev` Docker profile:
   ```bash
   docker compose --profile dev up
   ```
2. The database migrations will be applied on startup, so no additional work should be needed to provision the database.

---

### **Running the Application**

#### **For Demo**

1. Stop any running `dev` Docker containers:
   ```bash
   docker compose down
   ```
2. Start the `docker` profile:
   ```bash
   docker compose --profile docker up
   ```
3. Access the frontend at [http://localhost:8080](http://localhost:8080).
4. Register a user and log in with your credentials.

---

#### **For Development**

1. After migrating the database, install dependencies for the React app:
   ```bash
   cd react-app
   npm install
   ```
2. Start the React development server:
   ```bash
   npm run start
   ```
3. Open the .NET solution in Visual Studio, build, and run the backend.
4. Access the frontend at [http://localhost:3000](http://localhost:3000).

---

## **Testing**

The project includes testing examples to ensure reliability:

- **Frontend**: React Testing Library (RTL) for UI testing.
- **Backend**: MSTest Framework and Moq for backend logic validation.

Run tests using the respective tools (e.g., `npm test` for React, Visual Studio Test Explorer for backend tests).

---

## **Additional Notes**

- Ensure Docker, Node.js, and .NET 8 SDK are installed on your system.
- Update environment variables as needed for development or production configurations.
- Feel free to extend or customize the project to fit specific requirements.

---

By following the steps above, you should have the project running successfully for either demo or development purposes. If you encounter issues or have questions, feel free to raise them in the repository's issue tracker.