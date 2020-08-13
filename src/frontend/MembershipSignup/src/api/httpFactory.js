import Users from './users.api'
import LearningInst from './learninginstitutions.api'
import Contracts from './contracts.api'
import Memberships from './memberships.api'

const repositories = {
  'users': Users,
  'learningInst': LearningInst,
  'contracts': Contracts,
  'memberships': Memberships
}

export default {
  get: name => repositories[name]
}
