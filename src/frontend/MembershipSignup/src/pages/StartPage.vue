<template>
  <div class="startpage">
    <div class="image-container">
      <img id="swimmers" src="../assets/pics/swimmers.png" />
      <h5 id="marketing-headline">
        <b>{{ marketingHeadline }}</b>
      </h5>
    </div>
    <p>
      <b>{{ headline }}</b>
    </p>
    <div class="wrapper">
      <div class="offerBox" v-for="offer in offers" v-bind:key="offer.id">
        <img :src="offer.src" />
        <div>{{ offer.text }}</div>
      </div>
    </div>
    <router-link to="/student">
      <BaseButton classType="prim" :text="buttonText" />
    </router-link>
  </div>
</template>

<script>
import StudentChoicePage from "@/pages/StudentChoicePage.vue";

import store from "../store/store";

export default {
  name: "StartPage",
  components: {
    StudentChoicePage,
  },
  data() {
    return {
      marketingHeadline: "Treningsklar? Bli medlem her.",
      headline: "Ved å bli medlem får du tilgang til:",
      buttonText: "Bli medlem",
      offers: [
        {
          id: 1,
          text: "6 treningsstudio",
          src: require("../assets/icons/centers.svg"),
        },
        {
          id: 2,
          text: "Gruppetimer",
          src: require("../assets/icons/group.svg"),
        },
        {
          id: 3,
          text: "Svømmehaller",
          src: require("../assets/icons/swim.svg"),
        },
        {
          id: 4,
          text: "Flerbrukshaller",
          src: require("../assets/icons/hall.svg"),
        },
        {
          id: 5,
          text: "Squash og tennis",
          src: require("../assets/icons/squash.svg"),
        },
        {
          id: 6,
          text: "Kunstgressbane",
          src: require("../assets/icons/field.svg"),
        },
      ],
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
.image-container {
  position: relative;
  text-align: center;
  color: white;
  margin-bottom: 30px;
}
#marketing-headline {
  color: white;
  position: absolute;
  width: fit-content;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -150%);
}
</style>