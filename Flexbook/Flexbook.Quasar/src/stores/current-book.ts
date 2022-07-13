import {defineStore} from 'pinia';
import {BookDTO} from 'src/types/Books/BookDTO';

interface CurrentBookStore {
  book: BookDTO
}

export const useCurrentBookStore = defineStore({
  id: 'current-book',
  state: (): CurrentBookStore => ({
    book: {} as BookDTO
  }),

  getters: {
    getBook(): BookDTO {
      return this.book
    }
  }
})
