<template>
  <nav>
    <router-link to="/home">Головна</router-link> |
    <router-link to="/lessons/select">Учні</router-link> |
    <router-link to="/teachers">Вчителі</router-link> |
    <router-link to="/studing-plan">Навчальний план</router-link> |
    <router-link to="/login">Увійти</router-link>
  </nav>
  <router-view :isAuthenticated="isAuthenticated"/>
</template>

<script>
export default {
  data() {
    return {
      isAuthenticated: false,
    };
  },
  methods: {
    logout() {

      this.isAuthenticated = false;
    },
  },
};
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }

  div {
    display: inline-block;
    margin-left: 20px;
  }
}
</style>
