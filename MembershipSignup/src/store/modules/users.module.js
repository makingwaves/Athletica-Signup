import { getAllUsers } from "@/api/users.api"


const initialState = () => ({
    users: []
})

const state = initialState();

const getters = {
    getUsers(state) {
        return state.users;
    }
}

const actions = {
    async fetchUsers({ commit }) {
        try {
            const response = await getAllUsers();
            commit('SET_USERS', response.data);
        } catch (error) {
            // Handle the error here
        }
    },
    reset({commit}) {
        commit('RESET');
    }
}

const mutations = {
    SET_USERS(state, data) {
        state.users = data;
    },
    RESET(state) {
        const newState = initialState();
        Object.keys(newState).forEach(key => {
            state[key] = newState[key]
        })
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
}