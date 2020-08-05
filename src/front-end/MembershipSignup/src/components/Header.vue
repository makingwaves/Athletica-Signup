<template>
  <div class="header">
    <img class="logo" src="../assets/icons/logo.svg" />
  </div>
</template>

<script>
export default {
  name: "Header"
};
</script>

<style>
.header {
  height: 96px;
  padding: 10px;
  box-shadow: 0px 1px 0px rgba(36, 6, 47, 0.12);
}
.logo {
  width: 5em;
  height: 5em;
  float: left;
}
</style>