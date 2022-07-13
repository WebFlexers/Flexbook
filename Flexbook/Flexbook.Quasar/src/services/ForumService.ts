import {CommentDTO} from 'src/types/Forum/CommentDTO';
import {api} from 'boot/axios';
import {CreateCommentDTO} from 'src/types/Forum/CreateCommentDTO';

export class ForumService {
  public async getAllCommentsByAuthorId(id: number): Promise<CommentDTO[]> {
    const result = await api.get(`/author/forum/all_comments/${id}`)
    console.log(result.data)
    return result.data
  }

  public async createComment(createCommentDTO: CreateCommentDTO) {
    const result = await api.post('/author/forum/add_comment', createCommentDTO)
    console.log(result.data)
    return result.data
  }
}
