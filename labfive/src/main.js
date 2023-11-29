import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";

router.beforeEach((to, from, next) => {
  // Перевірка, чи роут вимагає авторизації
  if (to.matched.some((route) => route.meta.requiresAuth)) {
    // Перевірка, чи користувач авторизований
    if (store.getters["auth/isAuthenticated"]) {
      next(); // Проходження до роуту, якщо користувач авторизований
    } else {
      next({ name: "login" }); // Перенаправлення на сторінку входу, якщо не авторизований
    }
  } else {
    next(); // Проходження до роуту, якщо не потрібна авторизація
  }
});

createApp(App).use(store).use(router).mount("#app");
