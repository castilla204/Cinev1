import { createRouter, createWebHistory } from 'vue-router';
import type { RouteRecordRaw } from 'vue-router';
import HomePage from './components/Homepage.vue';
import InfoPelicula from './components/InfoPelicula.vue';


const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'HomePage',
    component: HomePage
  },
  {
    path: '/infopeli',
    name: 'InfoPelicula',
    component: InfoPelicula,
  },

];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;