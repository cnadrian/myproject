<script setup lang="ts">
defineProps<{
  id: number;
  content: string;
  status: boolean;
}>();

defineEmits<{
  (e: "removeElement"): void;
}>();
</script>

<template>
  <div class="action">
    <button
      class="bg-red-500 hover:bg-blue-700 text-white font-bold py-1 px-1 rounded"
      @click="$emit('removeElement')"
    >
      Delete
    </button>
  </div>
</template>