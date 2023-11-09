import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/delivery',
    name: 'delivery',
    component: () => import( '../views/DeliveryView.vue')
  },
  {
    path: '/shipment',
    name: 'shipment',
    component: () => import( '../views/ShipmentView.vue')
  },
  
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
