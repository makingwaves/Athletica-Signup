<template>
  <div class="createMembership">
    <BaseProgressBar/>
    <div class="membershipChoice">
      <h5>Hva passer deg best?</h5>
      <b-card-group deck class="cardDeck justify-content-center">
          <b-card v-for="card in cards" :key="card.id" :class="(isChosen(card.id) ? `mb-2 active` : `mb-2 card`)" @click="chosenCard = card.id">
              <b-form-radio name="radio-size" v-model="chosenCard" size="lg" :value="card.id"></b-form-radio>
              <p class="subtitle2">{{card.getLockInText()}}</p>
              <h4>{{card.getPrice()}},-</h4>
              <p>/måned</p>
              <div :key="s.id" v-for="s in card.getInfoSentence()">
                <img v-if="isChosen(card.id)" id="check" src="../assets/icons/check_white.svg"/>
                <img v-else id="check" src="../assets/icons/check_black.svg"/>
                <div>{{s}}</div>
              </div>
          </b-card>
      </b-card-group>
    </div>
    <router-link to="/personalia">
      <BaseButton classType="prim" text="Neste" v-on:BaseButton-clicked="membershipChosen()"/>
    </router-link>
    <BaseInfoBox color="#F1F3FF" label="Frys gir deg mulighet til å sette abonnementet på vent, også i bindingsperioden."/>
  </div>
</template>

<script>
import MembershipCard from "@/helpers/MembershipCard.js";
import repo from "@/api/httpFactory";

export default {
  name: "MembershipPage",
  props: ["selected"],
  data() {
    return {
      cards: [],
      chosenCard: 0,
      contractsByInst: [],
    };
  },
  created() {
    /* Using callback to make sure all contracts are fetched
        before the cards are made */
    this.getContracts(this.createCardsFromContract);
  },
  methods: {
    isChosen(cardid) {
      return cardid === this.chosenCard;
    },
    membershipChosen() {
      this.$store.dispatch("saveChosenContractId", this.chosenCard);
    },
    getContracts(callback) {
      const Contracts = repo.get("contracts");
      Contracts.getContractsByLearningInst(this.$store.getters.getSelectedLearningInst).then(response => {
        this.contractsByInst = response.data;
        callback();
      });
    },
    createCardsFromContract() {
      this.cards = [];
      this.contractsByInst.forEach(element => {
        const fee = element.monthlyFeeNok;
        let lockInText;
        let infoText;
        if (element.lockInPeriod === 0) {
          lockInText = "SUPERSPAR";
          infoText = ["12 måneder bindingstid", "Frys i opptil 2 måneder"];
        } else if (element.lockInPeriod === 1) {
          lockInText = "FLEXI";
          infoText = ["Ingen bindingstid", "Frys i opptil 1 måned"];
        }
        var card = new MembershipCard(
          element.lockInPeriod,
          lockInText,
          fee,
          infoText,
        );
        this.cards.push(card);
      });
      this.cards.sort((a, b) => a.id - b.id)
    }
  }
};
</script>

<style>
.cardDeck {
  margin: auto;
}

.card {
  max-width: 18rem;
  border: 1px solid #FFB0A7;
  box-sizing: border-box;
  border-radius: 10px;
  background-color: transparent;
}

#check {
  float:left;
}

.active {
  max-width: 18rem;
  background-color: #61177B !important;
  color: WHITE;
  box-sizing: border-box;
  border-radius: 10px;
  border: 0;
}
</style>