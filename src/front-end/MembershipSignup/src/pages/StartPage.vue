<template>
    <div class="startpage">
      <div>
        <h1>{{ headline }}</h1>
        <div>
            <b-button-group vertical>
                <router-link to="/inst"><b-button @click="studentOrNot(true)">Student / Snart student</b-button></router-link>
                <b-button @click="studentOrNot(false)">Jeg skal ikke studere</b-button>
            </b-button-group>
        </div>
        <BaseInfoBox label="If you do not have a Norwegian bank account, please go to the reception in order to sign up."/>
      </div>
      <div>
        <InstitutionPage v-if="isStudent"/>
        <MembershipPage v-if="isStudent===false"/>
      </div>
    </div>
</template>

<script>
import InstitutionPage from '@/pages/InstitutionPage.vue'
import MembershipPage from '@/pages/MembershipPage.vue'
import store from '../store/store'

export default {
  name: 'StartPage',
  components: {
    InstitutionPage,
    MembershipPage
  },
  data () {
    return {
      headline: 'Bli medlem her!',
      isStudent: null
    }
  },
  methods: {
    studentOrNot(answer) {
      this.isStudent = answer;
      this.$store.dispatch('saveStudentChoice', this.isStudent);
    }
  }
}
</script>

<style>
h1 {
  margin: 40px;
}
.infobox {
  background-color:burlywood;
}
</style>