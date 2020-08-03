<template>
    <div class="checkInput" v-bind:class="numberValidation">
        <h3>Personalia</h3>
        <b-form-group label="Fullt navn">
            <b-form-input id="fullName" v-model="name" @blur="nameValidation"></b-form-input>
        </b-form-group>
        <b-form-group label="Telefonnummer">
            <p>Bruk gjerne nummeret du gav til universitetet ditt.</p>
            <b-form-input id="phoneNumber" placeholder="8 siffer" v-model="number"></b-form-input>
        </b-form-group>

        <!-- TODO: Flesh out scenario "Har SiO-bruker, må logge inn" -->
        <PersonaliaUserExists v-if="userExists">
            <template #hasuser>
                <p>USER EXISTS</p>
            </template>
        </PersonaliaUserExists>

        <PersonaliaNewUser v-else-if="userExists === false">
            <template #newuser>
                <BaseInfoBox label="Du trenger SiO-bruker for å trene hos Athletica.
                Ved å opprette SiO-bruker kan du få studentpriser på medlemskapet ditt." />
                <h3>Registrer SiO-bruker</h3>
                <b-form-group label="Gatenavn og nummer">
                    <b-form-input id="streetAddress" placeholder="Eksempel: Gatenavn 24" v-model="street" @blur="streetValidation"></b-form-input>
                </b-form-group>
                <b-form-group label="Postnummer">
                    <b-form-input id="postalCode" v-model="postal" @blur="postalValidation"></b-form-input>
                </b-form-group>
                <b-form-group label="E-post">
                    <b-form-input id="emailAddress" v-model="email" @blur="emailValidation"></b-form-input>
                </b-form-group>
                <b-form-group label="Fødselsnummer">
                    <p>Vi bruker fødselsnummeret ditt for å sjekke at du har betalt semesteravgift</p>
                    <b-form-input id="socialSecurityNumber" placeholder="13 siffer" v-model="socSecNum" @blur="ssnValidation"></b-form-input>
                </b-form-group>
            </template>
        </PersonaliaNewUser>

    </div>
</template>

<script>
import PersonaliaUserExists from '@/components/PersonaliaUserExists.vue'
import PersonaliaNewUser from '@/components/PersonaliaNewUser.vue'
import store from '../store/store'
import UsersApi from '@/api/users.api'

export default {
    name: 'Personalia',
    data() {
        return {
            name: "",
            number: "",
            street: "",
            email: "",
            postal: "",
            socSecNum: "",
            userExists: null,
            address: "",
        }
    },
    components: {
        PersonaliaUserExists,
        PersonaliaNewUser
    },
    methods: {
        checkUserByNumber(userNum) {
            UsersApi.getUserByNumber(userNum).then((response) => {
                try {
                    this.userExists = response.data.exists;
                } catch(e) {}
                }).catch((error) => {
                try {
                    console.log(error.response.data);
                } catch(e) {}
            });
        },
        nameValidation() {
            // The regex does not handle special characters (like é)
            let singleName = `(([a-zA-Z]([a-zA-Z]*(\\-[a-zA-Z])?)*))`;
            let regName = new RegExp(`^(?<firstName>(${singleName}\\s)+)(?<lastName>${singleName})$`);
            if(!regName.test(this.name)) {
                console.log('Invalid name')
            } else {
                console.log('Valid name')
                let matches = this.name.match(regName);
                let firstName = matches.groups.firstName.trim();
                let lastName = matches.groups.lastName;
                // TODO: Format strings nicely
                this.$store.dispatch('saveFirstName', firstName)
                this.$store.dispatch('saveLastName', lastName)
            }
        },
        streetValidation() {
            let regStreet = /[a-zA-Z\d\s]+/;
            if(!regStreet.test(this.street)) {
                console.log('Invalid street')
            } else {
                console.log('Valid street')
                this.address = this.street.concat(", ")
                console.log(this.address)
            }
        },
        postalValidation() {
            let regPostal = /^\d{4}$/;
            if(!regPostal.test(this.postal)) {
                console.log('Invalid postal code')
            } else {
                console.log('Valid postal code')
                this.address = this.address.concat(this.postal + ", ")
                console.log(this.address)
            }
        },
        emailValidation() {
            let regEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if(!regEmail.test(this.email)) {
                console.log('Invalid email address')
            } else {
                console.log('Valid email address')
                this.$store.dispatch('saveEmailAddress', this.email)
            }
        },
        ssnValidation() {
            let regSsn = /^\d{11}$/;
            if(!regSsn.test(this.socSecNum)) {
                console.log('Invalid ssn')
            } else {
                console.log('Valid ssn')
                this.$store.dispatch('saveSsn', this.socSecNum)
            }
        }
    },
    computed: {
    numberValidation: function () {
      if (this.number.length === 8) {
          console.log("CORRECT")
          this.checkUserByNumber(this.number);
        return 'valid';
      } else {
          console.log("INCORRECT")
        return 'invalid';
      }
    }
  }
}
</script>

<style>
.checkInput {
    margin: 0 20% 0 20%;
}
</style>