<template>
  <button
    class="custom-button"
    :style="{ backgroundColor: color, '--before-color': beforeColor }"
    @click="onClick"
  >
    <span :style="{ color: textColor }">
      <slot></slot>
    </span>
  </button>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "CustomButton",
  props: {
    color: {
      type: String,
      default: "black",
    },
    textColor: {
      type: String,
      default: "#fff",
    },
    beforeColor: {
      type: String,
      default: "blue",
    },
  },
  emits: ["click"],
  setup(_, { emit }) {
    const onClick = () => {
      emit("click");
    };

    return {
      onClick,
    };
  },
});
</script>

<style scoped>
/* CSS */
.custom-button {
  appearance: none;
  border-width: 0;
  box-sizing: border-box;
  cursor: pointer;
  display: inline-block;
  font-size: 14px;
  font-weight: 500;
  letter-spacing: 0;
  line-height: 1em;
  margin: 0;
  opacity: 1;
  outline: 0;
  padding: 1em 1em;
  position: relative;
  text-align: center;
  text-decoration: none;
  text-rendering: geometricprecision;
  text-transform: uppercase;
  transition: opacity 300ms cubic-bezier(0.694, 0, 0.335, 1),
    background-color 100ms cubic-bezier(0.694, 0, 0.335, 1),
    color 100ms cubic-bezier(0.694, 0, 0.335, 1);
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  vertical-align: baseline;
  white-space: nowrap;
}

.custom-button:before {
  animation: opacityFallbackOut 0.5s step-end forwards;
  backface-visibility: hidden;
  background-color: var(--before-color);
  clip-path: polygon(-1% 0, 0 0, -25% 100%, -1% 100%);
  content: "";
  height: 100%;
  left: 0;
  position: absolute;
  top: 0;
  transform: translateZ(0);
  transition: clip-path 0.5s cubic-bezier(0.165, 0.84, 0.44, 1),
    -webkit-clip-path 0.5s cubic-bezier(0.165, 0.84, 0.44, 1);
  width: 100%;
}

.custom-button:hover:before {
  animation: opacityFallbackIn 0s step-start forwards;
  clip-path: polygon(0 0, 101% 0, 101% 101%, 0 101%);
}

.custom-button:after {
  background-color: #ffffff;
}

.custom-button span {
  z-index: 1;
  position: relative;
}
</style>
