import {api} from 'boot/axios';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';

export default class AuthorService {
  public async getAllAuthors(): Promise<AuthorDTO[]> {
    const result = await api.get('authors/get_all');
    console.log(result.data);
    return result.data;
  }

  public async getAuthorByName(fullname: string): Promise<AuthorDTO> {
    const result = await api.get(`authors/get_by_name/${fullname}`)
    console.log(result.data)
    return result.data
  }
}
