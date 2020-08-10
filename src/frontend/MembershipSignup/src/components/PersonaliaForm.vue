<template>
    <div class="checkInput">
        <BaseProgressBar/>
        <h5>Hvem er du?</h5>
        <div class="inputField" v-bind:class="numberValidation">
        <b-form-group label="Fullt navn">
            <b-form-input id="fullName" v-model="name" @blur="nameValidation"></b-form-input>
        </b-form-group>
        <b-form-group class="short" label="Telefonnummer">
            <b-form-input id="phoneNumber" placeholder="8 siffer" v-model="number" @blur="saveNumber"></b-form-input>
        </b-form-group>
        </div>

        <div v-bind:class="ssnValidation">
        <PersonaliaUserExists v-if="existingUser">
            <template #hasuser>
                <div>
                    <div v-if="checkingUser">
                        <b-spinner variant="primary" label="Text Centered"></b-spinner>
                        <p>Sjekker om du har SiO-bruker...</p>
                    </div>
                    <div>

                        <b-modal id="modal-center" ref="my-modal" hide-footer centered>
                            <template v-slot:default="{}">
                                <div>
                                    <h5 style="margin: 15px">Logg inn</h5>
                                    <p>Du har SiO-bruker, logg inn for å opprette medlemskap hos Athletica.</p>
                                </div>
                                <label>E-post</label>
                                <p><b>karolinevberge@gmail.com</b></p>
                                <b-form-group label="Passord">
                                    <b-form-input type="password"></b-form-input>
                                </b-form-group>
                                <BaseButton classType="prim" v-on:BaseButton-clicked="hideModal" text="Logg inn"/>
                                <br>
                                <p><u>Jeg har glemt passordet</u></p>
                                <div class="text-center" v-if="loading">
                                    <b-spinner variant="primary" label="Text Centered"></b-spinner>
                                </div>
                            </template>     
                        </b-modal>
                    </div>
                </div>
            </template>
        </PersonaliaUserExists>

        <PersonaliaNewUser class="inputField" v-if="blabla === true">
            <template #newuser>
                <b-form-group label="Gatenavn og nummer">
                    <b-form-input id="streetAddress" placeholder="Eksempel: Gatenavn 24" v-model="street" @blur="streetValidation"></b-form-input>
                </b-form-group>
                <b-form-group label="Postnummer">
                    <b-form-input id="postalCode" v-model="postal" @blur="postalValidation"></b-form-input>
                    <div style="float: right">{{ postalCity }}</div>
                </b-form-group>
                <b-form-group label="E-post">
                    <b-form-input id="emailAddress" v-model="email" @blur="emailValidation"></b-form-input>
                </b-form-group>
                <!-- <b-form-group label="Fødselsnummer">
                    <b-form-input id="ssn" placeholder="11 siffer" v-model="socSecNum" @blur="saveSsn"></b-form-input>
                </b-form-group> -->
                <BaseInfoBox color="#FFEF9E" label="Sjekk at opplysningene stemmer."/>
                <div class="offerBox">
                    <img src="../assets/icons/checkmark.svg" />
                    <p>Flott! Du har betalt semesteravgift, og kan få studentpriser.</p>
                </div>
                <router-link to="/summary">
                    <BaseButton classType="prim" text="Neste"/>
                </router-link>
            </template>
        </PersonaliaNewUser>
        </div>

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
            postalCity: "",
            socSecNum: "",
            existingUser: null,
            address: "",
            lastFeePaidThisSemester: null,
            loading: false,
            checkingUser: null,
            blabla: false
        }
    },
    components: {
        PersonaliaUserExists,
        PersonaliaNewUser
    },
    methods: {
        showModal() {
        this.$refs['my-modal'].show()
        },
        hideModal() {
            this.loading = true;
            setTimeout(() => {
                this.$refs['my-modal'].hide()
                this.blabla = true;
                document.getElementById("streetAddress").value = this.existingUser.user.address;
                document.getElementById("postalCode").value = this.existingUser.user.address;
                document.getElementById("emailAddress").value = this.existingUser.user.email;
                document.getElementById("ssn").value = this.existingUser.user.ssn;
                }, 2000);
        },
        checkUserByNumber(userNum) {

            UsersApi.getUserByNumber(userNum).then((response) => {
                try {
                    this.existingUser = response.data;
                    this.checkingUser = true;
                    setTimeout(() => {
                        this.checkingUser = false;
                        }, 3000);
                } catch(e) {}
                }).catch((error) => {
                try {
                    console.log(error.response.data);
                    this.existingUser = false;
                    this.blabla = true;
                    document.getElementById("streetAddress").value = "";
                    document.getElementById("postalCode").value = "";
                    document.getElementById("emailAddress").value = "";
                    document.getElementById("ssn").value = "";
                } catch(e) {}
            });
            var regScroll = document.getElementById("registerSIO");
            /*this.$smoothScroll({
                scrollTo: regScroll,
                duration: 1500,
                offset: -50,
                })*/
        },
        checkStudentFeeBySsn(ssn) {
            UsersApi.getStudentFeeBySsn(ssn).then((response) => {
                try {
                    var lastFeePaid = response.data.lastPaidStudentFee;
                    // TODO: ADD LOADING WHEEL AND PAUSE SOMEWHERE HERE
                    if(lastFeePaid) {
                        this.checkLastPaidFeeStatus(lastFeePaid);
                    }
                } catch(e) {console.log(error.response.data);}
            }).catch((error) => {
                try {
                    console.log(error.response.data);
                } catch(e) {}
            });
        },
        checkLastPaidFeeStatus(lastFeePaid) {
            var today = new Date().toLocaleDateString().split(".");
            this.formatToday(today);
            var currentMonth = parseInt(today[1]);
            var currentSemester = today[2];

            /* Assuming that one can pay the student fee for a 
            new semester earliest at July 1st.*/
            if(currentMonth < 7) {
                currentSemester = currentSemester.concat('V');
            } else {
                currentSemester = currentSemester.concat('H');
            }

            if(lastFeePaid === currentSemester) {
                this.lastFeePaidThisSemester = true;
            } else {
                this.lastFeePaidThisSemester = false;
            }
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
            }
        },
        postalValidation() {
            let regPostal = /^\d{4}$/;
            if(!regPostal.test(this.postal)) {
                console.log('Invalid postal code')
            } else {
                console.log('Valid postal code')
                this.address = "";
                UsersApi.getCityByPostalCode(this.postal).then((response) => {
                try {
                    this.postalCity = response.data;
                    this.address = this.address.concat(this.street + ", " + this.postal + ", " + this.postalCity)
                    this.$store.dispatch('saveAddress', this.address);
                    console.log(this.address)
                } catch(e) {console.log(error.response.data);}
            }).catch((error) => {
                try {
                    console.log(error.response.data);
                } catch(e) {}
            });
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
        saveNumber() {
            console.log('Phone number saved')
            this.$store.dispatch('savePhoneNumber', this.number)
        },
        saveSsn() {
            this.$store.dispatch('saveSsn', this.socSecNum);
            this.$emit('timeForSummary');
        },
        formatToday(today) {
            var list = today;
            var todayFormatted = "";
            list.forEach((element, i) => {
                if(element.length < 2) {
                    var addZero = element.replace(element, '0' + element)
                    list[i] = addZero;
                }
            });
            todayFormatted = todayFormatted.concat(list[0], list[1], list[2]);
            this.$store.dispatch('saveTodaysDate', todayFormatted);
        }
    },
    computed: {
    numberValidation: function () {
      if (this.number.length === 8) {
          console.log("Valid phone number")
          this.checkUserByNumber(this.number);
        return 'valid';
      } else {
          console.log("Invalid phone number")
        return 'invalid';
      }
    },
    ssnValidation: function () {
        if (this.socSecNum.length === 11) {
            console.log("Valid ssn");
            this.checkStudentFeeBySsn(this.socSecNum);
            return 'valid';
        } else {
            console.log("Invalid ssn");
            return 'invalid';
        }
    }
  },
  watch: {
        checkingUser: function(val) {
            if(this.checkingUser === false) {
                this.showModal()
            }
        }
    }
}
</script>

<style>
#postalCode {
    width: 70%;
    float:left;
}
</style>