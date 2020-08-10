<template>
  <div>
    <BaseProgressBar/>  
    <div>
      <h5>Så fint at du vil trene hos oss!</h5>
      <h5>Er du student?</h5>
      <div class="studentChoiceButtons">
        <router-link to="/inst">
          <BaseButton classType="prim" v-on:BaseButton-clicked="studentOrNot(true)" text="Jeg er student" />
        </router-link>
        <br />
        <BaseButton classType="prim" v-on:BaseButton-clicked="studentOrNot(false)" text="Jeg er ikke student" />
        <!-- <b-form-radio name="radio-size" size="lg">Large</b-form-radio>
        <b-form-radio name="radio-size" size="lg">Large</b-form-radio> -->
      </div>
      <!-- <BaseButton classType="prim" /> -->
      <BaseInfoBox
        color="#FFEF9E"
        label="If you do not have a Norwegian bank account, please go to the reception in order to sign up."
      />
    </div>
  </div>
</template>

<script>
export default {
    name: 'StudentChoicePage',
    data() {
        return {
            isStudent: null,
        }
    },
    methods: {
    studentOrNot(answer) {
      this.isStudent = answer;
      this.$store.dispatch("saveStudentChoice", this.isStudent);
    }
  }
}
</script>

<style>
.studentChoiceButtons {
  margin: 30px;
}
</style>