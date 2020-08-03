<template>
  <div id="app">
    <img id="logo" src="./assets/logo.png">
    <router-view/>
  </div>
</template>

<script>

import StartPage from '@/pages/StartPage'

export default {
  name: 'App',
  components: {
    StartPage
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
#logo {
  width: 3em;
  height: 3em;
  margin-bottom: 2em;
}
</style>
