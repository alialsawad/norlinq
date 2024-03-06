<template>
  <div>
    <CustomInput v-model="note.title" placeholder="Title" />
    <CustomTextArea v-model="note.content" placeholder="Content" />
    <CustomButton @click="addNote"> Add Note </CustomButton>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import NotesService from "../../services/NotesService";
import CustomButton from "../ui/CustomButton.vue";
import CustomInput from "../ui/CustomInput.vue";
import CustomTextArea from "../ui/CustomTextArea.vue"; // Ensure the path is correct

export default defineComponent({
  components: {
    CustomButton,
    CustomInput,
    CustomTextArea,
  },
  setup(_, { emit }) {
    const note = ref({ title: "", content: "" });

    const addNote = async () => {
      await NotesService.createNote(note.value);
      note.value.title = "";
      note.value.content = "";
      emit("note-added");
    };

    return {
      note,
      addNote,
    };
  },
});
</script>
