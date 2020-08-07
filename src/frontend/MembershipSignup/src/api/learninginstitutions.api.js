import Client from './httpClient'

const RESOURCE_NAME = '/api/signup/learninginstitutions';

export default {
    getAll() {
        return Client.get(RESOURCE_NAME);
    },
    get(id) {
        return Client.get(`${RESOURCE_NAME}/${id}`);
    }
}