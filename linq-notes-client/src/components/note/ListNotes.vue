<template>
  <div>
    <ul>
      <li v-for="note in notes" :key="note.id">
        {{ note.title }} - {{ note.content }}
        <div class="button-container">
          <CustomButton
            color="#2568A7"
            textColor="white"
            @click="() => openModal(note)"
            >Edit</CustomButton
          >
          <CustomButton
            color="#C21807"
            textColor="#fff"
            beforeColor="#EA3C53"
            @click="() => deleteNote(note.id)"
            >Delete</CustomButton
          >
        </div>
      </li>
    </ul>
    <NoteEditModal
      :isVisible="modalVisible"
      :note="currentNote"
      @update:isVisible="modalVisible = false"
      @saveNote="saveNote"
    />
  </div>
</template>
<script lang="ts">
import { defineComponent, ref, onMounted } from "vue";
import NotesService from "../../services/NotesService";
import CustomButton from "../ui/CustomButton.vue";
import NoteEditModal from "./NoteEditModal.vue";
import { Note } from "../../types/Note";

export default defineComponent({
  components: {
    CustomButton,
    NoteEditModal,
  },
  setup() {
    const notes = ref<Note[]>([]);
    const modalVisible = ref(false);
    const currentNote = ref<Note | null>(null);

    const fetchNotes = async () => {
      const response = await NotesService.getNotes();
      if (!response?.data) return;

      notes.value = response.data.map((note: Note) => ({
        ...note,
        isEditing: false,
      }));
    };

    const openModal = (note: Note) => {
      currentNote.value = note;
      modalVisible.value = true;
    };

    const saveNote = async (editedNote: Note) => {
      await NotesService.updateNote(editedNote.id, {
        title: editedNote.title,
        content: editedNote.content,
      });
      modalVisible.value = false;
      fetchNotes();
    };

    const deleteNote = async (id: number) => {
      await NotesService.deleteNote(id);
      fetchNotes();
    };

    onMounted(fetchNotes);

    return {
      notes,
      modalVisible,
      currentNote,
      openModal,
      saveNote,
      deleteNote,
    };
  },
});
</script>

<style scoped>
ul {
  list-style-type: none;
  padding: 0;
}

li {
  background-color: #f9f9f9;
  border: 1px solid #ddd;
  margin-bottom: 12px;
  padding: 12px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-radius: 4px;
  transition: background-color 0.2s ease-in-out;
}

li:hover {
  background-color: #f1f1f1;
}

.button-container {
  display: flex;
  gap: 10px;
}
</style>
