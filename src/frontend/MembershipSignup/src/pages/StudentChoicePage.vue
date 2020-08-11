<template>
  <div>
    <BaseProgressBar :active="1" />
    <div>
      <h5>Supert! Er du student?</h5>
      <div class="studentChoiceButtons">
        <b-form-radio
          name="radio-size"
          v-model="isStudent"
          size="lg"
          value="true"
          >Jeg er student</b-form-radio
        >
        <b-form-radio
          name="radio-size"
          v-model="isStudent"
          size="lg"
          value="false"
          >Jeg er ikke student</b-form-radio
        >
      </div>
      <router-link to="/inst">
        <BaseButton
          classType="prim"
          v-on:BaseButton-clicked="studentOrNot()"
          text="Neste"
        />
      </router-link>
      <BaseInfoBox
        color="#FFEF9E"
        label="If you do not have a Norwegian bank account, please go to the reception in order to sign up."
      />
    </div>
  </div>
</template>

<script>
export default {
  name: "StudentChoicePage",
  data() {
    return {
      isStudent: true
    };
  },
  methods: {
    studentOrNot() {
      this.$store.dispatch("saveStudentChoice", this.isStudent);
    }
  }
};
</script>

<style>
.studentChoiceButtons {
  margin: 30px;
}
</style>
