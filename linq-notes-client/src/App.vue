<template>
  <div id="app">
    <AddNote @note-added="triggerRefresh" />
    <ListNotes :key="refreshKey" />
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import AddNote from "./components/note/AddNote.vue";
import ListNotes from "./components/note/ListNotes.vue";

export default defineComponent({
  components: {
    AddNote,
    ListNotes,
  },
  setup() {
    const refreshKey = ref(0);

    const triggerRefresh = () => {
      refreshKey.value++;
    };

    return {
      refreshKey,
      triggerRefresh,
    };
  },
});
</script>

<style scoped>
#app {
  max-width: 800px;
  margin: 40px auto;
  padding: 20px;
  background-color: #fff;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  border-radius: 8px;
}

@media (max-width: 768px) {
  #app {
    padding: 15px;
  }
}
</style>
