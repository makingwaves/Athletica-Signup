import Client from './httpClient'

const RESOURCE_NAME = '/api/signup/users/';

export default {
    getAll() {
        return Client.get(RESOURCE_NAME);
    },
    getUserByNumber(num) {
        return Client.get(`${RESOURCE_NAME}` + `existing`, {
            params: {
                phoneNumber: num
            }
        })
    },
    getStudentFeeBySsn(ssn) {
        return Client.get(`${RESOURCE_NAME}` + `studentfee`, {
            params: {
                ssn: ssn
            }
        })
    },
    getCityByPostalCode(postalCode) {
        return Client.get(`${RESOURCE_NAME}` + `postalcode`, {
            params: {
                postalCode: postalCode
            }
        });
    },
    postUser(first, last, inst, email, num, address, ssn) {
        return Client.post(`${RESOURCE_NAME}`, {
            params: {
                firstName: first,
                lastName: last,
                learningInstitutionId: inst,
                email: email,
                phoneNumber: num,
                address: address,
                ssn: ssn
            }
        })
    }
}