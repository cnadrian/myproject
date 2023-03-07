<script setup lang="ts">
import CreateToDo from "@/components/CreateToDo.vue";
import DisplayToDo from "@/components/DisplayToDo.vue";
import { defineEmits, onMounted, ref, watch } from "vue";
import type { TodoElement } from "@/types/element";

const todoElement = ref<TodoElement[]>([]);

const addElement = (value: string, status: boolean) => {
  if (!value.trim()) return;
  todoElement.value.push({
    id: Math.floor(Math.random() * 101),
    content: value,
    status: status,
  });
  localStorage.setItem("todoElement", JSON.stringify(todoElement.value));
};

const removeElement = (id: number) => {
  todoElement.value = todoElement.value.filter((x) => x.id !== id);
};

const editElement = (id: number, value: string, status: boolean) => {
  const element = todoElement.value.find((x) => x.id === id);
  if (element) {
    element.content = value;
    element.status = status;
    localStorage.setItem("todoElement", JSON.stringify(todoElement.value));
  }
};

onMounted(() => {
  const localData = localStorage.getItem("todoElement");
  if (localData) todoElement.value = JSON.parse(localData);
});

watch(
  todoElement,
  (newVal) => {
    localStorage.setItem("todoElement", JSON.stringify(newVal));
  },
  { deep: true });

defineEmits<{
  (e: "removeElement", id: number): void;
  (e: "addElement", value: string, status: boolean): void;
}>();
</script>

<template>
  <main>
    <CreateToDo :elements="todoElement" @add-element="addElement" />
    <DisplayToDo 
      :elements="todoElement" 
      @remove-Element="removeElement" 
      @edit-Element="editElement" 
    />
  </main>
</template>
