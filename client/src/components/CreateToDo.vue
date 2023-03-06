<script lang="ts" setup>
import { defineEmits, ref } from "vue";

const emit = defineEmits<{
  (e: "addElement", value: string, status: boolean): void;
}>();

const inputValue = ref("");

const onSubmit = () => {
  const value = inputValue.value;
  emit("addElement", value, false);
};
</script>

<template>
  <section>
    <div class="flex flex-col md:flex-row justify-between items-center">
      <form
        @submit.prevent="onSubmit"
        class="w-full md:w-auto md:flex-1 md:mr-6"
      >
        <input 
          class="placeholder-italic placeholder-slate-400 block w-full bg-white border border-slate-300 rounded-md py-2 pl-9 pr-3 shadow-sm focus:outline-none focus:border-sky-500 focus:ring-sky-500 focus:ring-1 text-sm"
          type="text"
          v-model="inputValue"
          placeholder="Add a task..."
        />
      </form>
      <button
        class="px-4 py-2 font-semibold text-sm bg-cyan-500 text-white rounded-full shadow-sm md:mt-0"
        type="submit"
        @click.prevent="onSubmit"
      >Add to list
      </button>
    </div>
  </section>
</template>

