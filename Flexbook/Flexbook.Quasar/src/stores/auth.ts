import { Login } from 'src/types/Auth/Login';
import { UserDTO } from 'src/types/Users/UserDTO';
import { api } from 'boot/axios';
import { defineStore } from 'pinia';
import { AxiosError } from 'axios';
import {UserRegisterDTO} from 'src/types/Users/UserRegisterDTO';
import {LoadingBar} from 'quasar';

interface AuthStore {
  user: UserDTO
  loggedIn: boolean
  registerSuccessful: boolean
}

export const useAuthStore = defineStore({
  id: 'auth',
  state: (): AuthStore => ({
    user: JSON.parse(localStorage.getItem('currentUser') || '{}'),
    loggedIn: localStorage.getItem('userLoggedIn') == 'true',
    registerSuccessful: false
  }),

  getters: {
    getLoggedIn(): boolean {
      return this.loggedIn
    },
    getUser(): UserDTO {
      return this.user
    },
    getRegisterSuccessful(): boolean {
      return this.registerSuccessful
    },
  },

  actions: {
    async login(loginCredentials: Login) {
      LoadingBar.start()

      return await api
        .post('auth/login', loginCredentials)
        .then(async (response) => {
            localStorage.setItem('accessToken', response.data)
            localStorage.setItem('userLoggedIn', 'true')

            await this.getAuthenticatedUser()
            //console.log('data is ' + response.data)
            LoadingBar.stop()
            return response.data
        })
        .catch((error: AxiosError) => {
          if (error.response && error.response.data) {
            console.error(error.response)
            console.error(error.response.data)
          }
        });
    },

    logout() {
      localStorage.removeItem('accessToken')
      localStorage.removeItem('userLoggedIn')
      localStorage.removeItem('currentUser')
      this.user = {} as UserDTO;
      this.loggedIn = false;
    },

    async register(registerCredentials: UserRegisterDTO) {
      await api
        .post('customer/register', registerCredentials)
        .then((response) => {
            this.registerSuccessful = true
        })
        .catch((error: AxiosError) => {
            if (error.response && error.response.data) {
              console.error(error.response)
              console.error(error.response.data)
            }
        });
    },

    async getAuthenticatedUser() {
      await api.get<UserDTO>('auth/user',
        { headers: { 'Authorization': `Bearer ${localStorage.getItem('accessToken')}` }
      })
        .then((response) => {
          this.user = response.data
          console.log(JSON.stringify(response.data))
          localStorage.setItem('currentUser', JSON.stringify(response.data))
          this.loggedIn = true;
      }).catch((error) => {
          console.log(error);
      });
    },
  },
});
