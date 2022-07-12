import {BookDTO} from 'src/types/BookDTO';
import {UserDTO} from 'src/types/Users/UserDTO';

export interface BookReviewDTO {
  rating: number,
  content: string,
  book: BookDTO,
  user: UserDTO
}
