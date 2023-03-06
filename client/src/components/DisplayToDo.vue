<script setup lang="ts">
import TodoItem from "./TodoItem.vue";
import DButton from "./DButton.vue";
import type { TodoElement } from "@/types/element";

defineProps<{
  elements: TodoElement[];
}>();

defineEmits<{
  (e: "removeElement", id: number): void;
  (e: "editElement", id: number, value: string, status: boolean): void;
}>();
</script>

<template>
  <div class="grid grid-cols-1 gap-4 justify-items-center mt-2 mr-20">
    <div
      v-for="todo in $props.elements"
      :class="[{
          'bg-lime-100': todo.status,
          'bg-white': !todo.status
        },
        'flex',
        'justify-between',
        'items-center',
        'w-full',
        'max-w-md',
        'rounded-md',
        'shadow-md',
        'p-4'
      ]"
      :key="todo.id"
    >
      <TodoItem
        :item="todo"
        @editElement="
          (id, content, status) => $emit('editElement', id, content, status)
        "
      />
      <DButton
        :id="todo.id"
        :content="todo.content"
        :status="todo.status"
        @click.prevent="$emit('removeElement', todo.id)"
      />
    </div>
  </div>
</template>

