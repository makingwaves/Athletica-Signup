import store from '../store/store'

export default {

    nameValidation(name) {
        // TODO: The regex does not handle special characters (like é)
        let singleName = `(([a-zA-Z]([a-zA-Z]*(\\-[a-zA-Z])?)*))`;
        let regName = new RegExp(`^(?<firstName>(${singleName}\\s)+)(?<lastName>${singleName})$`);
        if(!regName.test(name)) {
            console.log('Invalid name')
        } else {
            console.log('Valid name')
            let matches = name.match(regName);
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
}