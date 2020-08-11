<template>
  <div>
    <BaseProgressBar :active="3" />
    <h5>Klar for å betale?</h5>
    <div class="inputField">
      <h6>Du har valgt</h6>
      <BaseCard v-if="card" :card="card" id="summary-card" />
      <h6>Dette betaler du i dag</h6>
      <div>
        <div class="wrapper2">
          <p style="float: left">Resten av denne måneden</p>
          <p style="float: right">{{ remainingPrice }},-</p>
        </div>
        <div class="wrapper2">
          <p style="float: left">Neste måned</p>
          <p style="float: right">{{ card.getPrice() }},-</p>
        </div>
        <div class="separator"></div>
        <div class="wrapper2">
          <p style="float: left">Totalt</p>
          <p style="float: right">
            <b>{{ remainingPrice + card.getPrice() }},-</b>
          </p>
        </div>
      </div>
      <BaseInfoBox
        color="#FFEF9E"
        label="Fremtidige betalinger trekkes i forkant av hver måned."
      />
      <h6>Opprett AvtaleGiro nå</h6>
      <div class="baseMarketingBox" id="ag-pros">
        <template>
          <div v-for="pro in avtaleGiroPros" :key="pro.id">
            <img id="avtale-check" src="../assets/icons/check_black.svg" />
            <p>{{ pro }}</p>
          </div>
        </template>
      </div>
      <b-form-checkbox
        id="checkbox-1"
        v-model="statusAG"
        name="checkbox-1"
        value="accepted"
        unchecked-value="not_accepted"
      >
        Opprett AvtaleGiro
      </b-form-checkbox>
      <b-form-checkbox
        id="checkbox-2"
        v-model="statusMA"
        name="checkbox-2"
        value="accepted"
        unchecked-value="not_accepted"
      >
        Jeg godtar
        <router-link to="inst"><u>medlemsavtalen</u></router-link> til SiO
        Athletica*
      </b-form-checkbox>

      <h6>Betalingsmetode</h6>
      <div>
        <b-button-group>
          <b-button variant="outline-dark" class="btn">Bankterminal</b-button>
          <b-button variant="outline-dark" class="btn">Vipps</b-button>
          <b-button variant="outline-dark" class="btn"
            >Fyll inn kortinformasjon</b-button
          >
        </b-button-group>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "SummaryPage",
  data() {
    return {
      statusAG: "accepted",
      statusMA: null,
      card: null,
      avtaleGiroPros: [
        "Slipp 35,- i fakturagebyr hver måned",
        "Banken betaler regningen for deg"
      ]
    };
  },
  methods: {
    fetchChosenCard() {
      this.card = this.$store.getters.getChosenCard;
      console.log(this.card);
    }
  },
  created() {
    this.fetchChosenCard();
  },
  computed: {
    remainingPrice: function() {
      if (this.card !== null) {
        const today = new Date();
        const numberOfDays = new Date(
          today.getYear(),
          today.getMonth() + 1,
          0
        ).getDate();
        const remainingDays = numberOfDays - today.getDate();
        return Math.floor(
          this.card.getPrice() * (remainingDays / numberOfDays)
        );
      }
      return 0;
    }
  }
};
</script>

<style>
.separator {
  height: 1px;
  background-color: black;
  width: 100%;
}
.btn {
  margin: 10px;
  width: 200px;
}
#avtale-check {
  float: left;
  padding-right: 10px;
}
#summary-card {
  background-color: #f1f3ff;
  border: transparent;
  text-align: center;
}
#ag-pros {
  background-color: #e8fdef;
}
</style>
