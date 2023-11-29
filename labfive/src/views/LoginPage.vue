<template>
  <div>
    Ім'я користувача
    <input v-model="userName" type="text" />
    <div>Пароль</div>
    <input v-model="password" type="password" />
    <button @click="onLogin">er</button>
  </div>
</template>

<script>
export default {
  name: 'LoginPage',
  data() {
    return {
      userName: null,
      password: null,
      isAuthenticated: false, 
    };
  },
  methods: {
    onLogin() {
    if (this.userName && this.password) {
      // встановлюємо ім'я користувача в глобальну змінну (window.userName) для вашого використання
      window.userName = this.userName;
      // встановлюємо аутентифікаційний стан в true
      this.isAuthenticated = true;
      // переходимо на бажаний маршрут ("/lessons/select" або редирект)
      this.$router.push({ path: '/lessons/select' });
    } else {
      
      console.error("Invalid username or password");
    }
  },
}
};
</script>
