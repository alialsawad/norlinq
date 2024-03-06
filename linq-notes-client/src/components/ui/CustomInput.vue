<template>
  <input
    :value="modelValue"
    @input="onInput($event)"
    :placeholder="placeholder"
  />
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  props: {
    modelValue: {
      type: String,
      default: "",
    },
    placeholder: String,
  },
  emits: ["update:modelValue"],
  methods: {
    onInput(event: Event) {
      const target = event.target as HTMLInputElement | null;
      if (target) {
        this.$emit("update:modelValue", target.value);
      }
    },
  },
});
</script>

<style scoped>
input {
  width: calc(100% - 20px);
  padding: 10px 10px;
  margin: 10px 0 20px 0;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 16px;
}

input:focus {
  border-color: #007bff;
  box-shadow: 0 0 0 2px rgba(0, 123, 255, 0.25);
}
</style>
