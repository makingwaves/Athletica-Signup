<template>
  <div class="createMembership">
    <div class="membershipChoice">
      <h6>Velg medlemskap</h6>
      <b-card-group deck class="cardDeck">
          <b-card v-for="card in cards" :key="card.id" :class="(isChosen(card.id) ? `mb-2 active` : `mb-2 card`)" id="carrd">
              <img id="tick" src="../assets/icons/checkmark.svg" :style="(isChosen(card.id) ? `visibility: visible` : `visibility: hidden`)"/>
              <p class="subtitle2">{{card.getLockInText()}}</p>
              <h4>{{card.getPrice()}},-</h4>
              <p>/måned</p>
              <BaseButton v-on:BaseButton-clicked="membershipChosen(card.id)" text="Velg" classType="sec"/>
          </b-card>
      </b-card-group>
      <!-- TODO: Dinne vise før korta e ferdilaga, blir litt lagg i UI. Display litt seinare -->
      <BaseInfoBox label="Hva er AvtaleGiro? Banken betaler regningen for deg, uten at du trenger å godkjenne først.
        Du slipper å huske på forfallsdatoer og unngår fakturagebyr.
        Vi trekker den første hver måned."/>
    </div>
    <div class="position">
      <div class="personalia">
        <PersonaliaForm />
      </div>
      <div>
        <Summary v-if="showSummary">
          <template #summaryCard>

          </template>
        </Summary>
      </div>
    </div>
  </div>
</template>

<script>
import MembershipCard from "@/helpers/MembershipCard.js";
import PersonaliaForm from "@/components/PersonaliaForm.vue";
import Summary from "@/components/Summary.vue";
import repo from "@/api/httpFactory";

export default {
  name: "MembershipPage",
  props: ["selected"],
  components: {
    PersonaliaForm,
    Summary
  },
  data() {
    return {
      cards: [],
      chosenCard: 1,
      contractsByInst: [],
      showSummary: false,
    };
  },
  created() {
    /* Using callback to make sure all contracts are fetched
        before the cards are made */
    this.getContracts(this.createCardsFromContract);
  },
  methods: {
    timeForSummary() {
      showSummary: true;
      console.log("TIME FOR SUMMARY")
    },
    isChosen(cardid) {
      return cardid === this.chosenCard;
    },
    membershipChosen(card) {
      this.chosenCard = null;
      this.chosenCard = card;
      console.log(this.chosenCard)
    },
    getContracts(callback) {
      const Contracts = repo.get("contracts");
      Contracts.getContractsByLearningInst(this.selected.id).then(response => {
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
          lockInText = "MED BINDING";
          infoText = ["12 måneder bindingstid med AvtaleGiro", "Frys opp til 2 måneder det første året", "Du sparer 612,- over et år", "AvtaleGiro"];
        } else if (element.lockInPeriod === 1) {
          lockInText = "UTEN BINDING";
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
  },
  computed: {
    getInfoTexts: function() {
      var texts = [];
      for(var i = 0; i < this.cards.length; i++){
        for(var k = 0; k < this.cards[i].length; k++){
          texts.push(this.cards[i][k].infoText);
        }
      }
      return texts;
    },
  },
  watch: {
    chosenCard: function(val) {
            this.membershipChosen;
        }
  }
};
</script>

<style>
.cardDeck {
  text-align: center;
}

.card {
  max-width: 18rem;
  border: 1px solid #FFB0A7;
  box-sizing: border-box;
  border-radius: 10px;
}

.active {
  max-width: 18rem;
  background-color: #61177B;
  color: WHITE;
  box-sizing: border-box;
  border-radius: 10px;
  border: 0;
}
</style>