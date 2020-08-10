<template>
  <div class="createMembership">
    <BaseProgressBar/>
    <div class="membershipChoice">
      <h5>Hva passer deg best?</h5>
      <b-card-group deck class="cardDeck justify-content-center">
          <b-card v-for="card in cards" :key="card.id" :class="(isChosen(card.id) ? `mb-2 active` : `mb-2 card`)" id="carrd">
              <img id="tick" src="../assets/icons/checkmark.svg" :style="(isChosen(card.id) ? `visibility: visible` : `visibility: hidden`)"/>
              <p class="subtitle2">{{card.getLockInText()}}</p>
              <h4>{{card.getPrice()}},-</h4>
              <p>/måned</p>
              <BaseButton v-on:BaseButton-clicked="membershipChosen(card.id)" text="Velg" classType="sec"/>
          </b-card>
      </b-card-group>
    </div>
    <router-link to="/personalia">
      <BaseButton classType="prim" text="Neste"/>
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
      chosenCard: 1,
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
    membershipChosen(card) {
      this.chosenCard = null;
      this.chosenCard = card;
      console.log(this.chosenCard)
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
          infoText = ["12 måneder bindingstid med AvtaleGiro", "Frys opp til 2 måneder det første året", "Du sparer 612,- over et år", "AvtaleGiro"];
        } else if (element.lockInPeriod === 1) {
          lockInText = "FLEXI";
          infoText = ["Ingen binding", "Frys opp til 1 måned per år", "AvtaleGiro"];
        }
        var card = new MembershipCard(
          element.id,
          lockInText,
          fee,
          infoText,
        );
        this.cards.push(card);
      });
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

.active {
  max-width: 18rem;
  background-color: #61177B !important;
  color: WHITE;
  box-sizing: border-box;
  border-radius: 10px;
  border: 0;
}
</style>