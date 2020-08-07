<template>
    <div>
        <BaseProgressBar/>
        <div class="learningInst">
            <p class="p2">Velg ditt studiested</p>
            <b-form-select id="learningInstDropDown" class="inputField" v-model="selected">
                <template v-slot:first>
                    <b-form-select-option :value="null" disabled>Velg utdanningsinstitusjon</b-form-select-option>
                </template>
                <b-form-select-option :value="inst" v-for="inst in learningInsts" v-bind:key="inst.name">{{inst.name}}</b-form-select-option>
            </b-form-select>
            <MembershipPage v-if="selected" :key="selected.id" :selected="selected"/>
        </div>
    </div>
</template>

<script>
import { mapState, mapGetters } from 'vuex'
import store from '../store/store'
import repo from '@/api/httpFactory'
import MembershipPage from '@/pages/MembershipPage.vue'

export default {
    name: 'InstitutionPage',
    components: {
        MembershipPage
    },
    data() {
        return {
            selected: null,
            cards: [],
            learningInsts: [],
        }
    },
    created() {
      const LearningInst = repo.get("learningInst");
      LearningInst.getAll().then((response) => {
          this.learningInsts = response.data;
      })
    },
    watch: {
        selected: function(val) {
            this.$store.dispatch('saveChosenLearningInst', this.selected.id);
        }
    }
}
</script>

<style>

.learningInst {
    text-align: left;
    margin-left: 10%;
}
</style>