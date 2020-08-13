import Client from './httpClient'

const RESOURCE_NAME = '/api/signup/memberships/';

export default {
  postMembership(userId, contractId, startDate, facilityId) {
    return Client.post(RESOURCE_NAME, {
      userId: userId,
      contractId: contractId,
      startDate: startDate,
      facilityId: facilityId
    });
  },
}
