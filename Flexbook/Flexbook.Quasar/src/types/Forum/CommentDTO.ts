import {UserDTO} from 'src/types/Users/UserDTO';
import {AuthorDTO} from 'src/types/Users/AuthorDTO';

export interface CommentDTO {
  id: number,
  content: string,
  createdOn: string,
  updatedOn: string,
  likesCount: number,
  user: UserDTO,
  authorHost: AuthorDTO
}
