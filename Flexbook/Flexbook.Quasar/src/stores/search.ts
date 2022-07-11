import {defineStore} from 'pinia';

interface SearchStore {
  userSearch: string,
  searchType: string
}

export const useSearchStore = defineStore({
  id: 'search',
  state: (): SearchStore => ({
    userSearch: '',
    searchType: 'Title'
  }),

  getters: {
    getUserSearch(): string {
      return this.userSearch
    },
    getSearchType(): string {
      return this.searchType
    }
  },
})

