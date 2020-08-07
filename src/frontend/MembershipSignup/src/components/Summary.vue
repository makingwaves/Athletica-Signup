<template>
    <div class="summary">
        <h6>Oppsummering og betaling</h6>
        <slot name="summaryCard"></slot>
        <BaseButton v-on:BaseButton-clicked="createUser" text="Opprett bruker" classType="prim"/>
    </div>
</template>

<script>
import repo from "@/api/httpFactory";


export default {
    name: 'Summary',
    data() {
        return {
            response: null,
        }
    },
    methods: {
        createUser() {
            var user = this.$store.getters.getUserData;
            const Users = repo.get("users");
            Users.postUser(user.firstName, user.lastName, user.learningInstitutionId, 
            user.email, user.phoneNumber, user.address, user.ssn).then((response) => {
                try {
                    this.response = response.data;
                    console.log(this.response)
                    console.log("HELLOO")
                } catch(e) {}
                }).catch((error) => {
                try {
                    console.log(error.response.data);
                } catch(e) {}
            })
        }
    }
}
</script>

<style>

</style>