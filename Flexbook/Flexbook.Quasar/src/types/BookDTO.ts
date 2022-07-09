import {AuthorDTO} from 'src/types/Users/AuthorDTO';

export interface BookDTO {
  title: string,
  description: string,
  image: string,
  startingPrice: number,
  finalPrice: number,
  isbn: string,
  genre: string,
  publisher: string,
  pageCount: number,
  language: string,
  summary: string,
  author: AuthorDTO
}
