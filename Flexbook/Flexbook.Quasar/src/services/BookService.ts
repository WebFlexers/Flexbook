import {BookDTO} from 'src/types/Books/BookDTO';
import { api } from 'boot/axios';

export default class BookService {
  public async getAllBooks(): Promise<BookDTO[]> {
    const result = await api.get('books/get_all')
    console.log(result.data)
    return result.data
  }

  public async getBookByName(name: string): Promise<BookDTO> {
    const result = await api.get(`books/get_by_title/${name}`)
    console.log(result.data)
    return result.data
  }

  public async getBooksByGenre(genre: string): Promise<BookDTO[]> {
    const result = await api.get(`books/get_by_genre/${genre}`)
    console.log(result.data)
    return result.data
  }

  public async getBooksByAuthor(authorId: number): Promise<BookDTO[]> {
    const result = await api.get(`books/get_all_by_author/${authorId}`)
    console.log(result.data)
    return result.data
  }
}

