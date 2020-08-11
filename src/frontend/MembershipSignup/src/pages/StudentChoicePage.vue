<template>
  <div>
<<<<<<< HEAD
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
=======
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
>>>>>>> f297a0586587d7e275c329c97be33ee98d543819
      <BaseInfoBox
        color="#FFEF9E"
        label="If you do not have a Norwegian bank account, please go to the reception in order to sign up."
      />
    </div>
  </div>
</template>

<script>
export default {
<<<<<<< HEAD
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
=======
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
>>>>>>> f297a0586587d7e275c329c97be33ee98d543819
</script>

<style>
.studentChoiceButtons {
  margin: 30px;
}
<<<<<<< HEAD
</style>
=======
</style>
>>>>>>> f297a0586587d7e275c329c97be33ee98d543819
