<template>
  <div>
    <b-modal id="modal-center" hide-footer centered ref="login-modal">
      <template v-slot:default="{}">
        <div>
          <h5 style="margin: 15px">Logg inn</h5>
          <p>
            Du har SiO-bruker, logg inn for å opprette medlemskap hos Athletica.
          </p>
        </div>
        <label>E-post</label>
        <b-form-input v-model="email" disabled><b></b></b-form-input>
        <b-form-group label="Passord">
          <b-form-input type="password"></b-form-input>
        </b-form-group>
        <BaseButton
          classType="prim"
          v-on:BaseButton-clicked="hideModal"
          text="Logg inn"
        />
        <br />
        <p><u>Jeg har glemt passordet</u></p>
        <div class="text-center" v-if="loading">
          <b-spinner variant="primary" label="Text Centered"></b-spinner>
        </div>
      </template>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "BaseModal",
  props: {
    email: String,
    modalClosed: Function
  },
  data() {
    return {
      loading: false
    };
  },
  methods: {
    showModal() {
      this.$refs["login-modal"].show();
    },
    hideModal() {
      this.loading = true;
      setTimeout(() => {
        this.$refs["login-modal"].hide();
        this.modalClosed();
      }, 2000);
    }
  }
};
</script>

<style></style>
