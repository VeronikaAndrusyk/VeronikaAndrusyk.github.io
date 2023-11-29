<template>
  <div>
    <h1>Selected Teachers for Lessons:</h1>
    <p>Selected Lessons: {{ selectedLessons }}</p>
    <ul>
      <li v-for="(teacherId, lessonId) in selectedTeachers" :key="lessonId">
        Lesson: {{ getLessonName(lessonId) }}, Teacher: {{ getTeacherName(teacherId) }}
      </li>
    </ul>
  </div>
</template>

<script>
import { mapState } from 'vuex';
export default {
  props: ['selectedLessons'],
  data() {
    return {
      selectedTeachers: {},
    };
  },
  created() {
    const selectedTeachersParam = this.$route.query.selectedTeachers;
    if (selectedTeachersParam) {
      this.selectedTeachers = JSON.parse(selectedTeachersParam);
    }
  },
  computed: {
    ...mapState(['selectedLessons']),
   
    getLessonName() {
      return lessonId => {
        const lesson = this.$store.state.lessons.find(lesson => lesson.id === lessonId);
        return lesson ? lesson.lesson : 'Unknown Lesson';
      };
    },
    
    getTeacherName() {
      return teacherId => {
        const teacher = this.$store.state.teachers.find(teacher => teacher.id === teacherId);
        return teacher ? teacher.name : 'Unknown Teacher';
      };
    },
    
  },
};
</script>
