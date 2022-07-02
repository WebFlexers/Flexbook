import axios, {AxiosError, AxiosResponse} from 'axios'
import UserLogin from 'src/types/UserLogin';


export default class LoginService {
  jwtToken = '';

  public async Login(user: UserLogin): Promise<AxiosResponse<string> | void> {
      const result = await axios.post(`${process.env.API_URL}/session/login`, {
        username: user.username,
        password: user.password,
      }).catch(function (error) {
        if (error.response) {
          // The request was made and the server responded with a status code
          // that falls out of the range of 2xx
          console.log(error.response.data);
          console.log(error.response.status);
          console.log(error.response.headers);
        } else if (error.request) {
          // The request was made but no response was received
          // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
          // http.ClientRequest in node.js
          console.log(error.request);
        } else {
          // Something happened in setting up the request that triggered an Error
          console.log('Error', error.message);
        }
        console.log(error.config);
      });

      return result?.data;

  }
}
