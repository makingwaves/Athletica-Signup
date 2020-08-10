<template>
  <div class="header">
    <router-link to="/">
    <img class="logo" src="../assets/icons/logo.svg" />
    </router-link>
  </div>
</template>

<script>
export default {
  name: "Header"
};
</script>

<style>
.header {
  height: 105px;
  padding: 10px;
  box-shadow: 0px 1px 0px rgba(36, 6, 47, 0.12);
}
.logo {
  width: 6em;
  height: 6em;
  float: left;
}
</style>