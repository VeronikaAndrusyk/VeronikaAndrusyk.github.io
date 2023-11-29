import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/MainView.vue'

const routes = [
  {
    path: '/home',
    name: 'home',
    component: HomeView
  },
  {
    path: '/',
    name: 'error',
    component: () => import(/* webpackChunkName: "notFound" */ '../views/NotFound.vue'),
  },
  {
    path: '/login',
    name: 'login',
    component: () => import(/* webpackChunkName: "loginPage" */ '../views/LoginPage.vue'),
    meta: {requiresAuth: false},
  },
  {
    path: '/lessons/select',
    name: 'lessons/select',
    component: () => import(/* webpackChunkName: "lessons/select" */ '../views/LessonsView.vue'),
    meta: {requiresAuth: false},
  },
  {
    path: '/teachers/:selectedLessons',
    name: 'teachers',
    component: () => import(/* webpackChunkName: "teachers" */ '../views/TeachersView.vue'),
    props: true,
    meta: {requiresAuth: false},
  },
  {
    path: '/standing-plan/:selectedLessons',
    name: 'standingPlan',
    component: () => import(/* webpackChunkName: "standingPlan" */ '../views/StandingPlanView.vue'),
    props:(route) => ({ selectedLessons: route.params.selectedLessons }),
  },

]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})
router.beforeEach((to) =>{
  const isAuthenticated = window.userName
  if (to.meta.requiresAuth && !isAuthenticated){
    return {
      name:'LoginPage',
      query:{ redirect: to.fullPath},
    }
  }
})
export default router
