import {BookDTO} from 'src/types/Books/BookDTO';
import {api} from 'boot/axios';
import {BookSalesDTO} from 'src/types/BookSalesDTO';

export class StatisticsService {
  public async getBooksSales(authorId: number): Promise<BookSalesDTO> {
    const result = await api.get(`/author/statistics/get_book_sales/${authorId}`)
    console.log(result.data)
    return result.data
  }
}
