<template>
  <div>
    <h1>Вчителі для обраних уроків:</h1>
    <ul>
      <li v-for="lessonId in selectedLessonIds" :key="lessonId">
        {{ getLessonById(lessonId) }}
        <select v-model="selectedTeachers[lessonId]">
          <option v-for="teacher in teachers" :key="teacher.id" :value="teacher.id">{{ teacher.name }}</option>
        </select>
      </li>
    </ul>
    <router-link :to="{ name: 'standingPlan', params: { selectedLessons: selectedLessonIds.join(',') }, query: { selectedTeachers: JSON.stringify(selectedTeachers) } }">
       <button>Перейти на іншу сторінку</button>
    </router-link>

  </div>
</template>

<script>
export default {
  data() {
    return {
      selectedTeachers: {}, // Об'єкт для зберігання обраних вчителів для кожного уроку
    };
  },
  computed: {
    selectedLessonIds() {
      const selectedLessons = this.$route.params.selectedLessons;
      return selectedLessons ? selectedLessons.split(',').map(Number) : [];
    },
    teachers() {
      return this.$store.state.teachers; // Отримуємо масив вчителів 
    },
  },
  methods: {
    getLessonById(lessonId) {
      // Отримуємо урок за його id
      const lesson = this.$store.state.lessons.find((l) => l.id === lessonId);
      return lesson ? lesson.lesson : 'Невідомий урок';
    },
  },
};
</script>
