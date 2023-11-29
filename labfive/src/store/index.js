import { createStore } from 'vuex';

export default createStore({
  state: {
    
    lessons:[
      {id: 1, lesson: 'Українська мова', },
      {id: 2, lesson: 'Математика', },
      {id: 3, lesson: 'Історія',},
      {id: 4, lesson: 'Хімія', },
      {id: 5, lesson: 'Фізика', },
      {id: 6, lesson: 'Географія', },
    ],
    teachers:[
      {id: 11, name:' v1'},
      {id: 22, name:' v1'},
      {id: 33, name:' v1'},
      {id: 44, name:' v1'},
      {id: 55, name:' v1'},
      {id: 66, name:' v1'},
      {id: 77, name:' v1'},
      {id: 88, name:' v1'},
      {id: 99, name:' v1'},
      {id: 21, name:' v1'},
      {id: 31, name:' v1'},
    ],
    selectedLessons: [],
    
  },
  mutations: {
   
    toggleLessonSelection(state, lessonId) {
      const index = state.selectedLessons.indexOf(lessonId);
      if (index === -1) {
        state.selectedLessons.push(lessonId);
      } else {
        state.selectedLessons.splice(index, 1);
      }
    },
    
  },
  actions: {
    
  },
  getters: {
    selectedLessonDetails: state => {
      return state.selectedLessons.map(lessonId => {
        const lesson = state.lessons.find(lesson => lesson.id === lessonId);
        return lesson ? { lessonId: lesson.id, lessonName: lesson.lesson } : null;
      });
    },
  }
});
