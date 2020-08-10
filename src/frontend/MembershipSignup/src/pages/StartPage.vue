<template>
  <div class="startpage">
    <img id="swimmers" src="../assets/pics/swimmers.png"/>
    <h5>{{ marketingHeadline }}</h5>
    <div class="wrapper">
      <div class="offerBox" v-for="offer in offers" v-bind:key="offer.id">
        <img :src="offer.src" />
        <div>{{ offer.text }}</div>
      </div>
    </div>
    <router-link to="/student">
      <BaseButton classType="prim" :text="headline" />
    </router-link>
  </div>
</template>

<script>
import StudentChoicePage from "@/pages/StudentChoicePage.vue";

import store from "../store/store";

export default {
  name: "StartPage",
  components: {
    StudentChoicePage
  },
  data() {
    return {
      marketingHeadline: "Treningsklar? Kom i gang i dag!",
      headline: "Bli medlem",
      offers: [
        {
          id: 1,
          text: "6 sentrale treningsstudio",
          src: require("../assets/icons/centers.svg")
        },
        {
          id: 2,
          text: "Gruppetimer",
          src: require("../assets/icons/group.svg")
        },
        {
          id: 3,
          text: "Svømmehaller",
          src: require("../assets/icons/swim.svg")
        },
        {
          id: 4,
          text: "Flerbrukshaller",
          src: require("../assets/icons/hall.svg")
        },
        {
          id: 5,
          text: "Squash og tennis",
          src: require("../assets/icons/squash.svg")
        },
        {
          id: 6,
          text: "Kunstgressbane",
          src: require("../assets/icons/field.svg")
        }
      ]
    };
  },
};
</script>

<style>
.wrapper {
  margin: 40px auto 40px auto;
}
#swimmers {
  width: 100%;
}
</style>