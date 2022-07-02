import { defineStore } from 'pinia';

export const jwtAuth = defineStore('jwt_token', {
  state: () => ({
    me: {},
    token: '',
    isAuthenticated: false
  }),

  getters: {
    doubleCount (state) {
      return state.counter * 2;
    }
  },

  actions: {
    doLogin: async ({ commit }, payload) => {
      console.log(payload)
    },

    signOut: ({ commit }) => {

    },

    getMe: async ({commit, dispatch}, token) => {

    }
  }
});
