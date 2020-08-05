<template>
  <div class="createMembership">
    <div class="membershipChoice">
      <h6>Velg medlemskap</h6>
      <b-card-group deck class="cardDeck">
        <b-card v-for="card in cards" :key="card.id" style="max-width: 20rem;" class="mb-2">
          <p class="subtitle2">{{card.getLockInText()}}</p>
          <h4>{{card.getPrice()}},-</h4>
          <p>/måned</p>
          <ul>
            <li v-for="text in card.infoText" v-bind:key="text">{{text}}</li>
          </ul>
          <BaseButton v-on:BaseButton-clicked="membershipChosen(card.id)" text="Velg" />
        </b-card>
      </b-card-group>
      <!-- TODO: Dinne vise før korta e ferdilaga, blir litt lagg i UI. Display litt seinare -->
      <BaseInfoBox label="Hva er AvtaleGiro? Banken betaler regningen for deg, uten at du trenger å godkjenne først.
        Du slipper å huske på forfallsdatoer og unngår fakturagebyr.
        Vi trekker den første hver måned."/>
    </div>
    <div class="personalia">
      <PersonaliaForm />
    </div>
    <div>
      <Summary>
        <template #summaryCard>

        </template>
      </Summary>
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
      chosenCard: null,
      contractsByInst: [],
      showSummary: false
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
    membershipChosen(card) {
      this.chosenCard = true;
      this.$store.dispatch("saveChosenContractId", card);
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
          lockInText = "MED BINDINGSTID";
          infoText = ["12 måneder bindingstid med AvtaleGiro", "Frys opp til 2 måneder det første året", "Du sparer 612,- over et år", "AvtaleGiro"];
        } else if (element.lockInPeriod === 1) {
          lockInText = "UTEN BINDINGSTID";
          infoText = ["Ingen binding", "Frys opp til 1 måned per år", "AvtaleGiro"];
        } else {
          lockInText = "KUN ÉN MÅNED";
          infoText = ["Medlemskapet løper én måned før det avsluttes automatisk"];
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
  justify-content: center;
}
</style>