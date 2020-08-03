import Client from './httpClient'

const RESOURCE_NAME = '/api/signup/users/existing';

export default {
    getAll() {
        return Client.get(RESOURCE_NAME);
    },
    getUserByNumber(num) {
        return Client.get(`${RESOURCE_NAME}`, {
            params: {
                phoneNumber: num
            }
        })
    }
}