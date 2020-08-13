<template>
  <div class="baseProgressBar">
    <div v-for="item in progress" v-bind:key="item.step">
      <router-link :to="item.route">
        <img v-if="active === item.step" :src="item.src_active" />
        <img v-else :src="item.src_inactive" />
      </router-link>
      <div class="captions">{{ item.text }}</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BaseProgressBar",
  props: ["active"],
  data() {
    return {
      progress: [
        {
          step: 1,
          text: "Medlemskap",
          src_active: require("../assets/icons/1_active.svg"),
          src_inactive: require("../assets/icons/1_inactive.svg"),
          route: "/student",
        },
        {
          step: 2,
          text: "Personalia",
          src_active: require("../assets/icons/2_active.svg"),
          src_inactive: require("../assets/icons/2_inactive.svg"),
          route: "/personalia",
        },
        {
          step: 3,
          text: "Betaling",
          src_active: require("../assets/icons/3_active.svg"),
          src_inactive: require("../assets/icons/3_inactive.svg"),
          route: "/summary",
        },
        {
          step: 4,
          text: "Kvittering",
          src_active: require("../assets/icons/4_active.svg"),
          src_inactive: require("../assets/icons/4_inactive.svg"),
          route: "/end",
        },
      ],
    };
  },
};
</script>

<style>
.baseProgressBar {
  position: -webkit-sticky; /* Safari */
  position: sticky;
  background-color: #ffffff;
  top: 0;
  width: 80%;
  margin: 20px auto 40px auto;
  display: grid;
  grid-template-columns: 25% 25% 25% 25%;
  grid-gap: 15px;
  z-index: 9999;
  text-align: center;
}

.baseProgressBar img {
  padding: 10px;
}
</style>
