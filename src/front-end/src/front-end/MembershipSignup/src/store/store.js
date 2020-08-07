import Vue from 'vue'
import Vuex from 'vuex'
import modules from './modules'
import createPersistedState from 'vuex-persistedstate'

Vue.use(Vuex)

export const store = new Vuex.Store( {
    state: {
        user: {
            firstName: "",
            lastName: "",
            //Type: int - if null, person is not a student
            learningInstitutionId: null,
            email: "",
            phoneNumber: "",
            address: "",
            ssn: "",
        },

        locationId: 1234,
        //Type: int
        contractid: null,
        //Type: String 8 siffer - DDMMYYYY
        today: "",

        isStudent: null,

    },
    plugins: [createPersistedState({
        /* Using sessionStorage instead of default applicationStorage to make
        sure state resets when the tab is closed */
        storage: window.sessionStorage,
    })],
    getters: {
        /*getContractsByInst: state => {
            state.contractsByInst;
        }*/
    },
    mutations: {
        SAVE_CHOSEN_LEARNINGINST(state, learningInst) {
            state.user.learningInstitutionId = learningInst;
        },
        SAVE_STUDENT_CHOICE(state, isStudent) {
            state.isStudent = isStudent;
        },
        SAVE_CHOSEN_CONTRACT_ID(state, contractId) {
            state.contractid = contractId
        },
        SAVE_FIRST_NAME(state, firstName) {
            state.user.firstName = firstName;
        },
        SAVE_LAST_NAME(state, lastName) {
            state.user.lastName = lastName;
        },
        SAVE_PHONE_NUMBER(state, number) {
            state.user.phoneNumber = number;
        },
        SAVE_ADDRESS(state, address) {
            state.user.address = address;
        },
        SAVE_EMAIL_ADDRESS(state, email) {
            state.user.email = email;
        },
        SAVE_SSN(state, ssn) {
            state.user.ssn = ssn;
        },
        SAVE_TODAYS_DATE(state, date) {
            state.today = date;
        }
        /*
        SAVE_RELEVANT_CONTRACTS(state, contracts) {
            state.contractsByInst = contracts;
        }*/
    },
    modules,
    actions: {
        saveChosenLearningInst({commit}, instId) {
            commit('SAVE_CHOSEN_LEARNINGINST', instId)
        },
        saveStudentChoice({commit}, isStudent) {
            commit('SAVE_STUDENT_CHOICE', isStudent)
        },
        saveChosenContractId({commit}, contractId) {
            commit('SAVE_CHOSEN_CONTRACT_ID', contractId);
        },
        saveFirstName({commit}, firstName) {
            commit('SAVE_FIRST_NAME', firstName);
        },
        saveLastName({commit}, lastName) {
            commit('SAVE_LAST_NAME', lastName);
        },
        savePhoneNumber({commit}, number) {
            commit('SAVE_PHONE_NUMBER', number)
        },
        saveAddress({commit}, address) {
            commit('SAVE_ADDRESS', address);
        },
        saveEmailAddress({commit}, email) {
            commit('SAVE_EMAIL_ADDRESS', email);
        },
        saveSsn({commit}, ssn) {
            commit('SAVE_SSN', ssn);
        },
        saveTodaysDate({commit}, date) {
            commit('SAVE_TODAYS_DATE', date);
        }
        /*loadLearningInsts({commit}) {
            learningInstRepo.getAll().then((response) => {
                commit('SAVE_LEARNINGINST', response.data);
            }).catch(error => {
                console.log(error.response.data);
            })
        },
        loadContracts({commit}, instId) {
            contractRepo.getContractsByLearningInst(instId).then((response) => {
                commit('SAVE_RELEVANT_CONTRACTS', reponse.data);
            }).catch(error => {
                console.log(error.response.data);
            })
        }*/
    }
})