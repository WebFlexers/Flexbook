import {defineStore} from 'pinia';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';

interface CurrentAuthorStore {
  author: AuthorDTO
}

export const useCurrentAuthorStore = defineStore({
  id: 'current-author',
  state: (): CurrentAuthorStore => ({
    author: {} as AuthorDTO
  }),

  getters: {
    getAuthor(): AuthorDTO {
      return this.author
    }
  }
})
