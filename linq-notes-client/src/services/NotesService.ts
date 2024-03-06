import axios from "axios";

const apiClient = axios.create({
  // TODO: Use environment variables to set the base URL
  baseURL: "http://localhost:5103/api",
  withCredentials: false,
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
});

export default {
  async getNotes() {
    try {
      return await apiClient.get("/notes");
    } catch (error) {
      console.error("An error occurred while fetching notes:", error);
      return null;
    }
  },
  async createNote(note: { title: string; content: string }) {
    try {
      return await apiClient.post("/notes", note);
    } catch (error) {
      console.error("An error occurred while creating a note:", error);
      return null;
    }
  },
  async updateNote(id: number, note: { title: string; content: string }) {
    try {
      return await apiClient.put(`/notes/${id}`, note);
    } catch (error) {
      console.error("An error occurred while updating the note:", error);
      return null;
    }
  },
  async deleteNote(id: number) {
    try {
      return await apiClient.delete(`/notes/${id}`);
    } catch (error) {
      console.error("An error occurred while deleting the note:", error);
      return null;
    }
  },
};
