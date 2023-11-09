<template>
  <div class="home">
    <img alt="Vue logo" style="width: 400px; height: 200px;"  src="../assets/Logo.jpg">
    <HelloWorld msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>

import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'HomeView',
  components: {
    HelloWorld
  }
}
</script>
