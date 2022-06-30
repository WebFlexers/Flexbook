import axios from 'axios'
import UserLogin from 'src/types/UserLogin';


export default class LoginService {
  API_URL = 'https://localhost:7226/api';

  jwtToken = '';

  public async Login(user: UserLogin): Promise<number> {
    return await axios.post(`${this.API_URL}/session/login`, {
      username: user.username,
      password: user.password,
    })
    //   .catch(function (error) {
    //   if (error.response) {
    //     // The request was made and the server responded with a status code
    //     // that falls out of the range of 2xx
    //     console.log(error.response.data);
    //     console.log(error.response.status);
    //     console.log(error.response.headers);
    //   }
    // })

  }
}
