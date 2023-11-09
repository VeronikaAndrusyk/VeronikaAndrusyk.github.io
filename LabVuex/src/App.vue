<template>
  <nav>
    <router-link  style="color: #42b983;"  to="/">Список товару </router-link> |
    <router-link  style="color: #42b983;"  to="/shipment">Надходження товару</router-link> |
    <router-link  style="color: #42b983;"  to="/delivery">Відвантаження товару</router-link> 
  </nav>
  <router-view/>
</template>

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
  font-weight: bold;
  color: #42b983;
}
.router-link-exact-active {
      color: #2c3e50;
}
</style>
