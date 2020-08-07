import Client from './httpClient'

const RESOURCE_NAME = '/api/signup/contracts/byinstitution';

export default {
    getAll() {
        return Client.get(RESOURCE_NAME);
    },
    get(id) {
        return Client.get(`${RESOURCE_NAME}/${id}`);
    },
    getContractsByLearningInst(instId) {
        return Client.get(`${RESOURCE_NAME}`, {
            params: {
                instId: instId
            }
        });
    }
}