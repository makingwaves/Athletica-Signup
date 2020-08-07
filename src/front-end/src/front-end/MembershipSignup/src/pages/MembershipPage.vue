<template>
  <div class="createMembership">
    <div class="membershipChoice">
      <h3>Velg medlemskap</h3>
      <b-card-group deck class="cardDeck">
        <b-card v-for="card in cards" :key="card.id" style="max-width: 20rem;" class="mb-2">
          <h5>{{card.getLockInText()}}</h5>
          <h1>{{card.getPrice()}},-</h1>
          <p>/måned</p>
          <h5>{{card.getInfoSentence()}}</h5>
          <BaseInfoBox :label="card.getLabel()" style="background-color: WHITE" />
          <BaseButton v-on:BaseButton-clicked="membershipChosen(card.id)" text="Velg" />
        </b-card>
      </b-card-group>
      <!-- TODO: Dinne vise før korta e ferdilaga, blir litt lagg i UI. Display litt seinare -->
      <BaseInfoBox>
        <b>Hva er AvtaleGiro?</b> Banken betaler regningen for deg, uten at du trenger å godkjenne først.
        Du slipper å huske på forfallsdatoer og unngår fakturagebyr.
        Vi trekker den første hver måned.
      </BaseInfoBox>
    </div>
    <div class="personalia">
      <PersonaliaForm />
    </div>
    <div>
      <Summary v-if="showSummary"/>
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
        let label;
        if (element.lockInPeriod === 0) {
          lockInText = "Med bindingstid";
          infoText = "12 måneder bindingstid med AvtaleGiro";
          label = "Du sparer 612,- over et år med bindingstid.";
        } else if (element.lockInPeriod === 1) {
          lockInText = "Uten bindingstid";
          infoText = "AvtaleGiro";
          label = "Medlemskapet går til du avslutter det selv.";
        } else {
          lockInText = "Kun én måned";
          infoText = "";
          label = "Medlemskapet løper én måned før det avsluttes automatisk.";
        }
        var card = new MembershipCard(
          element.id,
          lockInText,
          fee,
          infoText,
          label
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