import Users from './users.api'
import LearningInst from './learninginstitutions.api'
import Contracts from './contracts.api'

const repositories = {
    'users': Users,
    'learningInst': LearningInst,
    'contracts': Contracts
}

export default {
    get: name => repositories[name]
}