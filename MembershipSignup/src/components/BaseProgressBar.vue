<template>
    <div class="baseProgressBar">
        <router-link to="/">
            <img class="backarrow" src="../assets/icons/backarrow.svg" />
        </router-link>
        <div v-for="item in progress" v-bind:key="item.step">
            <img :src="item.src"/>
            <div class="captions">{{ item.text }}</div>
        </div>
    </div>
</template>

<script>
export default {
    name: "BaseProgressBar",
    data() {
        return {
            progress: [
                {
                    step: 1,
                    text: "Medlemskap",
                    src: require("../assets/icons/1_active.svg")
                },
                {
                    step: 2,
                    text: "Personalia",
                    src: require("../assets/icons/2_inactive.svg")
                },
                {
                    step: 3,
                    text: "Betaling og AvtaleGiro",
                    src: require("../assets/icons/3_inactive.svg")
                },
                {
                    step: 4,
                    text: "Kvittering",
                    src: require("../assets/icons/4_inactive.svg")
                },
            ]
        }
    }
}
</script>

<style>
.baseProgressBar {
  position: -webkit-sticky; /* Safari */
  position: sticky;
  background-color: #FFFFFF;
  top: 0;
  width: 80%;
  margin: 20px auto 40px auto;
  display: grid;
  grid-template-columns: 20% 20% 20% 20% 20%;
  grid-gap: 15px;
  z-index:9999;
  text-align: center;
}

.baseProgressBar img {
    padding: 10px;
}
</style>