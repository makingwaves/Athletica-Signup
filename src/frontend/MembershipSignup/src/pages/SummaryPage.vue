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
      <BaseInfoBox color="#FFEF9E" label="Fremtidige betalinger trekkes i forkant av hver måned." />
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
      >Opprett AvtaleGiro</b-form-checkbox>
      <b-form-checkbox
        id="checkbox-2"
        v-model="statusMA"
        name="checkbox-2"
        value="accepted"
        unchecked-value="not_accepted"
      >
        Jeg godtar
        <a>
          <u>medlemsavtalen</u>
        </a>
        til
        Athletica*
      </b-form-checkbox>
    </div>
    <h6>Betalingsmetode</h6>
    <div id="payment-method">
      <b-button-group>
        <b-button variant="outline-dark" class="btn" @click="selectPayment(1)">
          <img src="../assets/icons/bankterminal.svg" />
        </b-button>
        <b-button variant="outline-dark" class="btn" @click="selectPayment(2)">
          <img src="../assets/icons/vipps.svg" />
        </b-button>
        <b-button variant="outline-dark" class="btn" @click="selectPayment(3)">
          <div>
            <div style="float:left">
              <img src="../assets/icons/visa.svg" />
              <img src="../assets/icons/mastercard.svg" />
            </div>
            <div style="float:right">Bankkort</div>
          </div>
        </b-button>
      </b-button-group>
      <img v-if="payment === 1" src="../assets/icons/terminal_chosen.svg" />
      <router-link to="/end">
        <img
          v-if="payment === 3"
          src="../assets/icons/bankkort_chosen.svg"
          @click="postMembership()"
        />
      </router-link>
    </div>
  </div>
</template>

<script>
import repo from "@/api/httpFactory";

export default {
  name: "SummaryPage",
  data() {
    return {
      statusAG: "accepted",
      statusMA: null,
      card: null,
      payment: null,
      avtaleGiroPros: [
        "Slipp 35,- i fakturagebyr hver måned",
        "Banken betaler regningen for deg",
      ],
    };
  },
  methods: {
    fetchChosenCard() {
      this.card = this.$store.getters.getChosenCard;
      console.log(this.card);
    },
    selectPayment(choice) {
      this.payment = choice;
    },
    postMembership() {
      const user = this.$store.getters.getUserData;
      const contractId = this.$store.getters.getChosenCard.contractId;
      const today = this.$store.getters.getToday;
      const locationId = this.$store.getters.getLocationId;
      console.log({
        user: user.id,
        contractId: contractId,
        today: today,
        locationId: locationId,
      });
      const Memberships = repo.get("memberships");

      Memberships.postMembership(user.id, contractId, today, locationId)
        .then((response) => {
          try {
            this.response = response.data;
            console.log(this.response);
          } catch (e) {}
        })
        .catch((error) => {
          try {
            console.log(error.response.data);
          } catch (e) {}
        });
    },
  },
  created() {
    this.fetchChosenCard();
  },
  computed: {
    remainingPrice: function () {
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
    },
  },
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
  width: fit-content;
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
#payment-method {
  display: inline-flex;
  flex-direction: column;
  width: fit-content;
}
</style>
