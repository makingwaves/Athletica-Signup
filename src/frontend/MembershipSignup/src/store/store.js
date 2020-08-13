import Vue from "vue";
import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex);

export const store = new Vuex.Store({
  state: {
    user: {
      id: "",
      firstName: "",
      lastName: "",
      //Type: int - if null, person is not a student
      learningInstitutionId: null,
      email: "",
      phoneNumber: "",
      address: "",
      ssn: ""
    },

    //Type: int
    locationId: 1234,
    //Type: String 8 siffer - DDMMYYYY
    today: "",

    isStudent: null,

    card: {
      id: null,
      lockInText: null,
      price: null,
      infoSentence: null,
      contractId: null
    },

    learningInsts: []
  },
  plugins: [
    createPersistedState({
      /* Using sessionStorage instead of default applicationStorage to make
        sure state resets when the tab is closed */
      storage: window.sessionStorage
    })
  ],
  getters: {
    getUserData: state => {
      return state.user;
    },
    getSelectedLearningInst: state => {
      return state.user.learningInstitutionId;
    },
    getChosenCard: state => {
      return state.card;
    },
    getLearningInsts: state => {
      return state.learningInsts;
    },
    getLocationId: state => {
      return state.locationId;
    },
    getToday: state => {
      return state.today;
    }
  },
  mutations: {
    SAVE_CHOSEN_LEARNINGINST(state, learningInst) {
      state.user.learningInstitutionId = learningInst;
    },
    SAVE_STUDENT_CHOICE(state, isStudent) {
      state.isStudent = isStudent;
    },
    SAVE_CHOSEN_CONTRACT_ID(state, contractId) {
      state.contractid = contractId;
    },
    SAVE_CHOSEN_CARD(state, card) {
      state.card = card;
    },
    SAVE_USER_ID(state, userId) {
      state.user.id = userId;
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
    },
    SAVE_EXISTING_USER(state, user) {
      state.user = user;
    },
    SAVE_LEARNING_INSTS(state, learningInsts) {
      state.learningInsts = learningInsts;
    }
  },
  modules,
  actions: {
    saveChosenLearningInst({
      commit
    }, instId) {
      commit("SAVE_CHOSEN_LEARNINGINST", instId);
    },
    saveStudentChoice({
      commit
    }, isStudent) {
      commit("SAVE_STUDENT_CHOICE", isStudent);
    },
    saveChosenContractId({
      commit
    }, contractId) {
      commit("SAVE_CHOSEN_CONTRACT_ID", contractId);
    },
    saveChosenCard({
      commit
    }, card) {
      commit("SAVE_CHOSEN_CARD", card);
    },
    saveUserId({
      commit
    }, userId) {
      commit("SAVE_USER_ID", userId);
    },
    saveFirstName({
      commit
    }, firstName) {
      commit("SAVE_FIRST_NAME", firstName);
    },
    saveLastName({
      commit
    }, lastName) {
      commit("SAVE_LAST_NAME", lastName);
    },
    savePhoneNumber({
      commit
    }, number) {
      commit("SAVE_PHONE_NUMBER", number);
    },
    saveAddress({
      commit
    }, address) {
      commit("SAVE_ADDRESS", address);
    },
    saveEmailAddress({
      commit
    }, email) {
      commit("SAVE_EMAIL_ADDRESS", email);
    },
    saveSsn({
      commit
    }, ssn) {
      commit("SAVE_SSN", ssn);
    },
    saveTodaysDate({
      commit
    }, date) {
      commit("SAVE_TODAYS_DATE", date);
    },
    saveUser({
      commit
    }, user) {
      commit("SAVE_USER_ID", user.id)
      commit("SAVE_FIRST_NAME", user.firstName);
      commit("SAVE_LAST_NAME", user.lastName);
      commit("SAVE_EMAIL_ADDRESS", user.email);
      commit("SAVE_ADDRESS", user.address);
      commit("SAVE_SSN", user.ssn);
      commit("SAVE_PHONE_NUMBER", user.phoneNumber);
      commit("SAVE_CHOSEN_LEARNINGINST", user.learningInstitutionId);
    },
    saveLearningInsts({
      commit
    }, learningInsts) {
      commit("SAVE_LEARNING_INSTS", learningInsts);
    }
  }
});
