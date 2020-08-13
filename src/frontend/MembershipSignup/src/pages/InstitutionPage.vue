<template>
  <div>
    <BaseProgressBar :active="1" />
    <h5>Hvor studerer du?</h5>
    <div class="learningInst">
      <p class="p2">Velg ditt studiested</p>
      <b-form-select id="learningInstDropDown" class="inputField" v-model="selected">
        <template v-slot:first>
          <b-form-select-option :value="null" disabled>Velg utdanningsinstitusjon</b-form-select-option>
        </template>
        <b-form-select-option
          :value="inst"
          v-for="inst in learningInsts"
          v-bind:key="inst.name"
        >{{ inst.name }}</b-form-select-option>
      </b-form-select>
    </div>
    <router-link to="/membership">
      <BaseButton classType="prim" v-if="selected" :selected="selected" text="Neste" />
    </router-link>
    <BaseInfoBox
      v-if="selected"
      color="#FFEF9E"
      label="Prisen varierer ut ifra støtten vi får fra de ulike studiestedene."
    />
  </div>
</template>

<script>
import { mapState, mapGetters } from "vuex";
import store from "../store/store";
import repo from "@/api/httpFactory";
import MembershipPage from "@/pages/MembershipPage.vue";

export default {
  name: "InstitutionPage",
  components: {
    MembershipPage,
  },
  data() {
    return {
      selected: null,
      cards: [],
    };
  },
  computed: {
    learningInsts: function () {
      console.log(this.$store.getters.getLearningInsts);
      return this.$store.getters.getLearningInsts;
    },
  },
  watch: {
    selected: function (val) {
      this.$store.dispatch("saveChosenLearningInst", this.selected.id);
    },
    learningInsts: function (val) {},
  },
};
</script>

<style>
.learningInst {
  text-align: center;
  margin: 60px;
}
</style>
