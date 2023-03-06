<script setup lang="ts">
import { ref } from "vue";

//This method is not working
import type { TodoElement } from "@/types/element";
const props = defineProps<{
  item: TodoElement
}>()

const status = ref(props.item.status);
const content = ref(props.item.content);

const emits = defineEmits<{
  (e: "editElement", id: number, content: string, status: boolean): void;
}>();

function updateStatus(event: Event) {
  const newStatus = (event.target as HTMLInputElement).checked;
  emits("editElement", props.item.id, content.value, newStatus);
  status.value = newStatus;
}

function updateContent(event: Event) {
  const newContent = (event.target as HTMLInputElement).value;
  emits("editElement", props.item.id, newContent, status.value);
  content.value = newContent;
}
</script>

<template>
  <label>
    <input
      class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600"
      type="checkbox"
      :checked="status"
      @change="updateStatus"
    />
  </label>
  <div class="element-content w-60">
    <input
      class="display-full bg-lime-100 ml-2 text-sm font-medium text-gray-900 dark:text-gray-300"
      type="text"
      :class="[{
          'bg-lime-100': status,
          'bg-white': !status
        }]"
      :value="content"
      @input="updateContent"
    />
  </div>
</template>