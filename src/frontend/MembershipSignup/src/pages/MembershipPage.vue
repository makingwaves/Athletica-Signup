<template>
  <div class="createMembership">
    <BaseProgressBar :active="1" />
    <div class="membershipChoice">
      <h5>Hva passer deg best?</h5>
      <b-card-group deck class="cardDeck justify-content-center">
        <BaseCard
          v-for="card in cards"
          :key="card.id"
          :card="card"
          :isChosen="isChosen(card.id)"
          :setChosen="() => (chosenCard = card.id)"
        >
          <template #radiobutton>
            <b-form-radio
              name="radio-size"
              v-model="chosenCard"
              size="lg"
              :value="card.id"
            ></b-form-radio>
          </template>
        </BaseCard>
      </b-card-group>
    </div>
    <router-link to="/personalia">
      <BaseButton
        classType="prim"
        text="Neste"
        v-on:BaseButton-clicked="membershipChosen()"
      />
    </router-link>
    <BaseInfoBox
      color="#F1F3FF"
      label="Frys gir deg mulighet til å sette abonnementet på vent, også i bindingsperioden."
    />
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
      contractsByInst: []
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
      console.log(this.cards);
      let chosenCard = this.cards.find(e => e.id === this.chosenCard);
      this.$store.dispatch("saveChosenCard", chosenCard);
      console.log(this.$store.getters.getChosenCard);
    },
    getContracts(callback) {
      const Contracts = repo.get("contracts");
      Contracts.getContractsByLearningInst(
        this.$store.getters.getSelectedLearningInst
      ).then(response => {
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
          infoText
        );
        this.cards.push(card);
      });
      this.cards.sort((a, b) => a.id - b.id);
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
  border: 1px solid #ffb0a7;
  box-sizing: border-box;
  border-radius: 10px;
  background-color: transparent;
}

#check {
  float: left;
}

.active {
  max-width: 18rem;
  background-color: #61177b !important;
  color: WHITE;
  box-sizing: border-box;
  border-radius: 10px;
  border: 0;
}
</style>
