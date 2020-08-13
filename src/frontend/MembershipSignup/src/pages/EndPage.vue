<template>
  <div>
    <BaseProgressBar :active="4" />
    <img src="../assets/pics/end_image.png" />
    <p id="end">Kvittering og mer info er sendt til {{ email }}</p>
    <router-link to="/">
      <BaseButton classType="sec" text="Ferdig"></BaseButton>
    </router-link>
  </div>
</template>

<script>
export default {
  name: "EndPage",
  data() {
    return {
      email: "",
    };
  },
  created() {
    this.email = this.$store.getters.getUserData.email;
  },
};
</script>
<style>
#end {
  margin: 30px;
}
</style>
