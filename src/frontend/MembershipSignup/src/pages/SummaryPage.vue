<template>
    <div>
        <BaseProgressBar/>
        <h5>Klar for å betale?</h5>
        <div class="inputField">
            <h6>Du har valgt</h6>
            <div class="baseMarketingBox">
                <template>
                    <p class="subtitle2">FLEXI</p>
                    <h4>175,-</h4>
                    <p>/måned</p>
                </template>
            </div>
            <h6>Dette betaler du i dag</h6>
            <div>
                <div class="wrapper2">
                    <p style="float: left">Resten av denne måneden</p>
                    <p style="float: right">125,-</p>
                </div>
                <div class="wrapper2">
                    <p style="float: left">Neste måned</p>
                    <p style="float: right">175,-</p>
                </div>
                <div class="separator"></div>
                <div class="wrapper2">
                    <p style="float: left">Totalt</p>
                    <p style="float: right"><b>300,-</b></p>
                </div>
            </div>
            <BaseInfoBox color="#FFEF9E" label="Fremtidige betalinger trekkes i forkant av hver måned." /> 
            <h6>Opprett AvtaleGiro nå</h6>
            <div class="baseMarketingBox">
                <template>
                    <ul>
                        <li>Slipp 35,- i fakturagebyr hver måned</li>
                        <li>Banken betaler regningen for deg</li>
                    </ul>
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
                Jeg godtar <router-link to="inst"><u>medlemsavtalen</u></router-link> til SiO Athletica*
            </b-form-checkbox>

            <h6>Betalingsmetode</h6>
            <div>
                <b-button-group>
                <b-button variant="outline-dark" class="btn">Bankterminal</b-button>
                <b-button variant="outline-dark" class="btn">Vipps</b-button>
                <b-button variant="outline-dark" class="btn">Fyll inn kortinformasjon</b-button>
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
            statusAG: null,
            statusMA: null
        }
    }
}
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
</style>