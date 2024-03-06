# NorLinq

## LinqNotes

This is a simple CRUD application built with C# and Vue.js. It allows users to create, read, update, and delete notes.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- .NET Core SDK version 7.0 or later.
- Node.js and npm

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Cloning the Repository

```bash
git clone git@github.com:alialsawad/norlinq.git
cd norlinq
```

### Setting Up the Backend (C#)

1. Navigate to the backend project directory:

   ```bash
   cd LinqNotesApi
   ```

2. Restore the .NET dependencies:

   ```bash
   dotnet restore
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the backend server:

   ```bash
   dotnet run
   ```

### Setting Up the Frontend (Vue.js)

1. Navigate to the frontend project directory:

   ```bash
   cd linq-notes-client
   ```

2. Install npm dependencies:

   ```bash
   npm install
   ```

3. Serve the application:

   ```bash
   npm run serve
   ```

## Usage

1. **Retrieve All Notes**: Send a GET request to `/api/notes` to fetch and display all notes.
2. **Add a New Note**: Use a POST request with note data to `/api/notes` to add a new note.
3. **Update a Note**: Send a PUT request with updated data to `/api/notes/{id}` to update a note.
4. **Delete a Note**: Use a DELETE request to `/api/notes/{id}` to remove a note.
