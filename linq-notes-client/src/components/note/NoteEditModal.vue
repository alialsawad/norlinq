<template>
  <div v-if="isVisible" class="backdrop" @click.self="close">
    <dialog :open="isVisible">
      <span class="close" @click="close">&times;</span>
      <CustomInput v-model="editableNote.title" placeholder="Title" />
      <CustomTextArea v-model="editableNote.content" placeholder="Content" />
      <CustomButton @click="save">Save</CustomButton>
    </dialog>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, watch } from "vue";
import CustomInput from "../ui/CustomInput.vue";
import CustomTextArea from "../ui/CustomTextArea.vue";
import CustomButton from "../ui/CustomButton.vue";

export default defineComponent({
  components: { CustomInput, CustomTextArea, CustomButton },
  props: ["isVisible", "note"],
  emits: ["update:isVisible", "saveNote"],
  setup(props, { emit }) {
    const editableNote = ref({ ...props.note });

    watch(
      () => props.note,
      (newNote) => {
        editableNote.value = { ...newNote };
      }
    );

    const save = () => {
      emit("saveNote", editableNote.value);
    };

    const close = () => {
      emit("update:isVisible", false);
    };

    return { editableNote, save, close };
  },
});
</script>

<style scoped>
.backdrop {
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

dialog {
  border: none;
  border-radius: 4px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  min-width: 300px;
  overflow-y: auto;
  background: white;
}

.close {
  position: absolute;
  top: 10px;
  right: 15px;
  font-size: 17px;
  cursor: pointer;
}
</style>
