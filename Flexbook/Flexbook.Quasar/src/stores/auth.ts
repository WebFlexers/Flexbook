import { DataResponse } from 'src/types/Responses/DataResponse';
import { useAlertStore } from 'src/stores/alert';
import { ErrorResponse } from 'src/types/Responses/ErrorResponse';
import { TokenDTO } from 'src/types/Auth/TokenDTO';
import { Login } from 'src/types/Auth/Login';
import { UserDTO } from 'src/types/Users/UserDTO';
import { api } from 'boot/axios';
import { defineStore } from 'pinia';
import { AxiosError } from 'axios';
import { SuccessResponse } from 'src/types/Responses/SuccessResponse';
import {UserRegisterDTO} from 'src/types/Users/UserRegisterDTO';

interface AuthStore {
  user: UserDTO;
  loggedIn: boolean;
}

export const useAuthStore = defineStore({
  id: 'auth',
  state: (): AuthStore => ({
    user: JSON.parse(localStorage.getItem('currentUser') || '{}'),
    loggedIn: localStorage.getItem('userLoggedIn') == 'true'
  }),

  getters: {
    getLoggedIn(): boolean {
      return this.loggedIn
    },
    getUser(): UserDTO {
      return this.user
    },
  },

  actions: {
    async login(loginCredentials: Login) {
      return await api
        .post('auth/login', loginCredentials)
        .then(async (response) => {
            localStorage.setItem('accessToken', response.data)
            localStorage.setItem('userLoggedIn', 'true')

            await this.getAuthenticatedUser()
            console.log('data is ' + response.data)
            return response.data
        })
        .catch((error: AxiosError) => {
          if (error.response && error.response.data) {
            const errorResponse = error.response.data as ErrorResponse;
            const alertStore = useAlertStore();
            alertStore.setErrors(errorResponse.errors);
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
        .post<SuccessResponse>('customer/register', registerCredentials)
        .then((response) => {
          if (response.data.success) {
            const alertStore = useAlertStore();
            alertStore.setMessage(response.data.message);
          }
          else {
            console.log(JSON.stringify(response.data))
          }
        })
        .catch((error: AxiosError) => {
          if (error.response && error.response.data) {
            const alertStore = useAlertStore();
            alertStore.clearAlert();
            const errorResponse = error.response.data as ErrorResponse;
            alertStore.setErrors(errorResponse.errors);
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
