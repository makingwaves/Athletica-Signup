<template>
    <div class="summary">
        <h1>SUMMARYYY</h1>
        <BaseButton v-on:BaseButton-clicked="createUser" text="Opprett bruker"/>
    </div>
</template>

<script>
import repo from "@/api/httpFactory";


export default {
    name: 'Summary',
    data() {
        return {
            response,
        }
    },
    methods: {
        createUser() {
            var user = this.$store.getters.getUserData
            const Users = repo.get("users");
            Users.postUser(user.firstName, user.lastName, user.learningInstitutionId, user.email, user.phoneNumber, user.address, user.ssn).then((response) => {
                this.response = response.data;
                console.log(this.response)
            })
        }
    }
}
</script>

<style>

</style>