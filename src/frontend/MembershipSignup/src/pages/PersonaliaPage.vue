<template>
  <div class="checkInput">
    <BaseProgressBar :active="2" />
    <h5>Hvem er du?</h5>
    <div class="inputField" v-bind:class="numberValidation">
      <b-form-group label="Fullt navn">
        <b-form-input id="fullName" v-model="name" @blur="nameValidation"></b-form-input>
      </b-form-group>
      <b-form-group class="short" label="Telefonnummer">
        <b-form-input
          id="phoneNumber"
          placeholder="8 sifre"
          v-model="number"
          :formatter="numberFormatter(8)"
          @blur="saveNumber"
        ></b-form-input>
      </b-form-group>
      <div v-if="checkingUser">
        <b-spinner variant="primary" label="Text Centered"></b-spinner>
        <p>Sjekker om du har SiO-bruker...</p>
      </div>
    </div>
    <div v-if="!checkingUser && existingUser && existingUser.isMember">
      <BaseInfoBox color="#FFEF9E" label="Du er allerede medlem i Athletica." />
    </div>
    <div v-else>
      <PersonaliaUserExists v-if="existingUser">
        <template #hasuser>
          <BaseModal ref="login-modal" :email="email" :modalClosed="modalClosed" />
        </template>
      </PersonaliaUserExists>

      <PersonaliaNewUser class="inputField" v-if="!checkingUser && afterModal === true">
        <template #newuser>
          <b-form-group label="Gatenavn og nummer">
            <b-form-input
              id="streetAddress"
              placeholder="Eksempel: Gatenavn 24"
              v-model="street"
              @blur="streetValidation"
            ></b-form-input>
          </b-form-group>
          <b-form-group label="Postnummer">
            <b-form-input
              id="postalCode"
              v-model="postal"
              @blur="postalValidation"
              :formatter="numberFormatter(4)"
            ></b-form-input>
            <div style="float: right">{{ postalCity }}</div>
          </b-form-group>
          <b-form-group label="E-post">
            <b-form-input
              id="emailAddress"
              v-model="email"
              :disabled="!!existingUser"
              @blur="emailValidation"
            ></b-form-input>
          </b-form-group>
          <b-form-group label="Fødselsnummer" :class="ssnValidation" v-if="existingUser === false">
            <b-form-input
              id="ssn"
              placeholder="11 siffer"
              v-model="ssn"
              :formatter="numberFormatter(11)"
              @blur="saveSsn"
            ></b-form-input>
          </b-form-group>
          <BaseInfoBox color="#FFEF9E" label="Sjekk at opplysningene stemmer." />
          <div>
            <div class="offerBox" v-if="lastFeePaidThisSemester === true">
              <img src="../assets/icons/checkmark.svg" />
              <p>Flott! Du har betalt semesteravgift, og kan få studentpriser.</p>
            </div>
            <BaseInfoBox
              v-if="lastFeePaidThisSemester === false"
              color="#FFB0A7"
              label="Det ser ut som du ikke har betalt semesteravgiften. Husk å betale
          innen 15. september for å få studentpriser på medlemskapet ditt."
            />
            <BaseInfoBox
              v-if="
              ssn.length === 11 &&
                loadingFeeStatus === false &&
                lastFeePaidThisSemester === null
            "
              color="#FFEF9E"
              label="Det er ikke registrert i systemene våre om du har betalt semesteravgift. 
            Husk at den må være betalt innen 15. september for at du skal få studentpriser på medlemskapet ditt."
            />
          </div>
          <router-link to="/summary">
            <BaseButton classType="prim" v-on:BaseButton-clicked="createUser" text="Neste" />
          </router-link>
        </template>
      </PersonaliaNewUser>
    </div>
  </div>
</template>

<script>
import PersonaliaUserExists from "@/components/PersonaliaUserExists.vue";
import PersonaliaNewUser from "@/components/PersonaliaNewUser.vue";
import store from "../store/store";
import UsersApi from "@/api/users.api";
import repo from "@/api/httpFactory";

export default {
  name: "PersonaliaPage",
  data() {
    return {
      name: "",
      number: "",
      street: "",
      email: "",
      postal: "",
      postalCity: "",
      ssn: "",
      existingUser: null,
      address: "",
      lastFeePaidThisSemester: null,
      loading: false,
      checkingUser: null,
      afterModal: false,
      loadingFeeStatus: null,
    };
  },
  components: {
    PersonaliaUserExists,
    PersonaliaNewUser,
  },
  methods: {
    showModal() {
      this.$refs["login-modal"].showModal();
    },
    checkUserByNumber(userNum) {
      this.checkingUser = true;
      this.lastFeePaidThisSemester = null;
      UsersApi.getUserByNumber(userNum)
        .then((response) => {
          try {
            this.existingUser = response.data;
            console.log(response.data);
            this.$store.dispatch("saveUser", this.existingUser.user);
            this.email = this.existingUser.user.email;
            this.checkStudentFeeBySsn(this.existingUser.user.ssn);
            setTimeout(() => {
              this.checkingUser = false;
            }, 2000);
          } catch (e) {}
        })
        .catch((error) => {
          try {
            console.log(error.response.data);
            this.existingUser = false;
            this.afterModal = true;
            this.street = "";
            this.postal = "";
            this.postalCity = "";
            this.email = "";
            this.ssn = "";
            setTimeout(() => {
              this.checkingUser = false;
            }, 2000);
          } catch (e) {}
        });
    },
    checkStudentFeeBySsn(ssn) {
      this.loadingFeeStatus = true;
      UsersApi.getStudentFeeBySsn(ssn)
        .then((response) => {
          try {
            var lastFeePaid = response.data.lastPaidStudentFee;
            // TODO: ADD LOADING WHEEL AND PAUSE SOMEWHERE HERE
            if (lastFeePaid) {
              this.checkLastPaidFeeStatus(lastFeePaid);
              console.log(this.lastFeePaidThisSemester);
            }
            this.loadingFeeStatus = false;
          } catch (e) {
            console.log(error.response.data);
          }
        })
        .catch((error) => {
          try {
            this.loadingFeeStatus = false;
            console.log(error.response.data);
          } catch (e) {}
        });
    },
    checkLastPaidFeeStatus(lastFeePaid) {
      var today = new Date().toLocaleDateString().split(".");
      this.formatToday(today);
      var currentMonth = parseInt(today[1]);
      var currentSemester = today[2];

      /* Assuming that one can pay the student fee for a
            new semester earliest at July 1st.*/
      if (currentMonth < 7) {
        currentSemester = currentSemester.concat("V");
      } else {
        currentSemester = currentSemester.concat("H");
      }

      if (lastFeePaid === currentSemester) {
        this.lastFeePaidThisSemester = true;
      } else {
        this.lastFeePaidThisSemester = false;
      }
      console.log(`Student fee: ${this.lastFeePaidThisSemester}`);
    },
    nameValidation() {
      // The regex does not handle special characters (like é)
      let singleName = `(([a-zA-Z]([a-zA-Z]*(\\-[a-zA-Z])?)*))`;
      let regName = new RegExp(
        `^(?<firstName>(${singleName}\\s)+)(?<lastName>${singleName})$`
      );
      if (!regName.test(this.name)) {
        console.log("Invalid name");
      } else {
        console.log("Valid name");
        let matches = this.name.match(regName);
        let firstName = matches.groups.firstName.trim();
        let lastName = matches.groups.lastName;
        // TODO: Format strings nicely
        this.$store.dispatch("saveFirstName", firstName);
        this.$store.dispatch("saveLastName", lastName);
      }
    },
    streetValidation() {
      let regStreet = /[a-zA-Z\d\s]+/;
      if (!regStreet.test(this.street)) {
        console.log("Invalid street");
      } else {
        console.log("Valid street");
        this.postalValidation();
      }
    },
    postalValidation() {
      let regPostal = /^\d{4}$/;
      if (!regPostal.test(this.postal)) {
        console.log("Invalid postal code");
      } else {
        console.log("Valid postal code");
        this.address = "";
        UsersApi.getCityByPostalCode(this.postal)
          .then((response) => {
            try {
              this.postalCity = response.data;
              this.address = this.address.concat(
                this.street + ", " + this.postal + ", " + this.postalCity
              );
              this.$store.dispatch("saveAddress", this.address);
              console.log(this.address);
            } catch (e) {
              console.log(error.response.data);
            }
          })
          .catch((error) => {
            try {
              console.log(error.response.data);
            } catch (e) {}
          });
      }
    },
    emailValidation() {
      let regEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      if (!regEmail.test(this.email)) {
        console.log("Invalid email address");
      } else {
        console.log("Valid email address");
        this.$store.dispatch("saveEmailAddress", this.email);
      }
    },
    saveNumber() {
      console.log("Phone number saved");
      this.$store.dispatch("savePhoneNumber", this.number);
    },
    saveSsn() {
      this.$store.dispatch("saveSsn", this.ssn);
      this.$emit("timeForSummary");
    },
    formatToday(today) {
      var list = today;
      var todayFormatted = "";
      list.forEach((element, i) => {
        if (element.length < 2) {
          var addZero = element.replace(element, "0" + element);
          list[i] = addZero;
        }
      });
      todayFormatted = todayFormatted.concat(list[0], list[1], list[2]);
      this.$store.dispatch("saveTodaysDate", todayFormatted);
    },
    createUser() {
      if (this.existingUser) {
        this.checkForUpdates();
        return;
      }
      console.log("hallooooooo");
      var user = this.$store.getters.getUserData;
      console.log(user);
      const Users = repo.get("users");
      Users.postUser(
        user.firstName,
        user.lastName,
        user.learningInstitutionId,
        user.email,
        user.phoneNumber,
        user.address,
        user.ssn
      )
        .then((response) => {
          try {
            this.response = response.data;
            console.log(this.response);
            this.$store.dispatch("saveUserId", this.response.id);
          } catch (e) {}
        })
        .catch((error) => {
          try {
            console.log(error.response.data);
          } catch (e) {}
        });
    },
    checkForUpdates() {
      const user = this.$store.getters.getUserData;
      if (
        this.existingUser.user.firstName !== user.firstName ||
        this.existingUser.user.lastName !== user.lastName ||
        this.existingUser.user.address !== user.address
      ) {
        console.log("Sending update!");
        const Users = repo.get("users");
        Users.putUser(
          this.existingUser.user.id,
          user.firstName,
          user.lastName,
          user.learningInstitutionId,
          user.email,
          user.phoneNumber,
          user.address,
          user.ssn
        )
          .then((response) => {
            try {
              console.log(this.response);
            } catch (e) {}
          })
          .catch((error) => {
            try {
              console.log(error.response.data);
            } catch (e) {}
          });
      } else {
        console.log("No updates made");
      }
    },
    modalClosed() {
      this.name = `${this.existingUser.user.firstName} ${this.existingUser.user.lastName}`;
      this.email = this.existingUser.user.email;
      let addressSlots = this.existingUser.user.address.split(/\,\s*/);
      console.log(addressSlots);
      this.street = addressSlots[0];
      this.postal = addressSlots[1];
      this.postalCity = addressSlots[2];
      this.afterModal = true;
    },
    numberFormatter(length) {
      return (s) => s.replace(/\D/g, "").substring(0, length);
    },
  },
  computed: {
    numberValidation: function () {
      if (this.number.length === 8) {
        console.log("Valid phone number");
        this.checkUserByNumber(this.number);
        return "valid";
      } else if (this.number.length > 0) {
        console.log("Invalid phone number");
        return "invalid";
      }
    },
    ssnValidation: function () {
      if (this.ssn.length === 11) {
        console.log("Valid ssn");
        this.checkStudentFeeBySsn(this.ssn);
        return "valid";
      } else {
        console.log("Invalid ssn");
        return "invalid";
      }
    },
  },
  watch: {
    checkingUser: function (val) {
      if (this.checkingUser === false && this.existingUser) {
        this.afterModal = false;
        this.showModal();
      }
    },
    postal: function (val) {
      if (this.postal.length === 4) {
        this.postalValidation();
      }
    },
  },
};
</script>

<style>
#postalCode {
  width: 70%;
  float: left;
}
</style>
