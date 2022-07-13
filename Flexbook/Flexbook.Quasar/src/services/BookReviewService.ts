import {api} from 'boot/axios';
import {BookReviewDTO} from 'src/types/Books/BookReviewDTO';
import {AddBookReviewDTO} from 'src/types/Books/AddBookReviewDTO';

export default class BookReviewService {
  public async getAllReviewsOfBook(bookId: number): Promise<BookReviewDTO[]> {
    const result = await api.get(`book/review/all_reviews/${bookId}`);
    console.log(result.data);
    return result.data;
  }

  public async addReview(review: AddBookReviewDTO) {
    const result = await api.post('book/review/add_review', review)
    console.log(result.data)
    return result.data
  }
}
