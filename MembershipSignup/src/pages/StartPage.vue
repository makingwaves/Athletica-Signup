<template>
  <div class="startpage">
    <BaseMarketingBox>
      <template #content>
        <h2>{{ marketingHeadline }}</h2>
        <p>Et medlemskap hos Athletica gir deg tilgang til:</p>
        <div class="wrapper">
          <div class="offerBox" v-for="offer in offers" v-bind:key="offer.id">
            <img :src="offer.src" />
            <div>{{ offer.text }}</div>
          </div>
        </div>
      </template>
    </BaseMarketingBox>
    <div>
      <h5>{{ headline }}</h5>
      <div class="studentChoiceButtons">
        <router-link to="/inst">
          <BaseButton classType="prim" v-on:BaseButton-clicked="studentOrNot(true)" text="Jeg er student" />
        </router-link>
        <br />
        <BaseButton classType="prim" v-on:BaseButton-clicked="studentOrNot(false)" text="Jeg er ikke student" />
      </div>
      <BaseInfoBox
        color="#FFEF9E"
        label="If you do not have a Norwegian bank account, please go to the reception in order to sign up."
      />
    </div>
    <div>
      <InstitutionPage v-if="isStudent" />
      <MembershipPage v-if="isStudent===false" />
    </div>
  </div>
</template>

<script>
import InstitutionPage from "@/pages/InstitutionPage.vue";
import MembershipPage from "@/pages/MembershipPage.vue";
import store from "../store/store";

export default {
  name: "StartPage",
  components: {
    InstitutionPage,
    MembershipPage
  },
  data() {
    return {
      marketingHeadline: "Treningsklar?",
      headline: "Bli medlem her",
      isStudent: null,
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
  methods: {
    studentOrNot(answer) {
      this.isStudent = answer;
      this.$store.dispatch("saveStudentChoice", this.isStudent);
    }
  }
};
</script>

<style>
.startpage {
  text-align: center;
}
.studentChoiceButtons {
  margin: 30px;
}
</style>