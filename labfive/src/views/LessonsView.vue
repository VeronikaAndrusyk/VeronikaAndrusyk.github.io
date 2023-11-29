<template>
  <div>
    
    <ul>
      <li v-for="lesson in lessons" :key="lesson.id">
        {{ lesson.lesson }}
        <button @click="toggleLessonSelection(lesson.id)">
          {{ isSelected(lesson.id) ? '✔' : 'Вибрати' }}
        </button>
      </li>
    </ul>

    <router-link v-if="selectedLessons.length > 0" :to="{ name: 'teachers', params: { selectedLessons: selectedLessons.join(',') } }">
      <button>Перейти до вчителів</button>
    </router-link>
  </div>
</template>

<script>
import { mapState, mapMutations } from 'vuex';

export default {
  computed: {
    ...mapState(['lessons', 'selectedLessons']),
  },
  methods: {
    ...mapMutations(['toggleLessonSelection']),
    isSelected(lessonId) {
      return this.selectedLessons.includes(lessonId);
    },
  },
};
</script>
