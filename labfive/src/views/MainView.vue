<template>
  <div class="main">
    <img alt="Vue logo" src="../assets/logo.png">
    <HelloWorld msg="Вітаємо на сайті школи."/>
    <HelloWorld msg="У нашій школі учень сам  вибирає уроки і вчителів."/>
    <HelloWorld msg="Увійдіть для повноцінного використання."/>
   
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'mainView',
  components: {
    HelloWorld
  }
}
</script>
