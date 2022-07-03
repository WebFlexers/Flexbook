import { DataResponse } from 'src/types/Responses/DataResponse';
import { RegisterCustomer } from 'src/types/Auth/RegisterCustomer';
import { useAlertStore } from 'src/stores/alert';
import { ErrorResponse } from 'src/types/Responses/ErrorResponse';
import { TokenDTO } from 'src/types/Auth/TokenDTO';
import { Login } from 'src/types/Auth/Login';
import { UserDTO } from 'src/types/UserDTO';
import { api } from 'boot/axios';
import { defineStore } from 'pinia';
import { AxiosError } from 'axios';
import { SuccessResponse } from 'src/types/Responses/SuccessResponse';

interface AuthStore {
  user: UserDTO;
  loggedIn: boolean;
  searchedUser: UserDTO;
}

export const useAuthStore = defineStore({
  id: 'auth',
  state: (): AuthStore => ({
    user: {} as UserDTO,
    loggedIn: false,
    searchedUser: {} as UserDTO,
  }),

  getters: {
    getLoggedIn(): boolean {
      return this.loggedIn;
    },
    getUser(): UserDTO {
      return this.user;
    },
    getSearchedUserFromState(): UserDTO {
      return this.searchedUser;
    },
  },

  actions: {
    async login(loginCredentials: Login) {
      return await api
        .post<DataResponse<TokenDTO>>('auth/login', loginCredentials)
        .then(async (response) => {
          if (response.data.success) {
            localStorage.setItem('accessToken', response.data.data.accessToken);
            await this.getAuthenticatedUser();
            return response.data.success;
          }
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
      localStorage.removeItem('accessToken');
      this.user = {} as UserDTO;
      this.loggedIn = false;
    },

    async register(registerCredentials: RegisterCustomer) {
      await api
        .post<SuccessResponse>('auth/register', registerCredentials)
        .then((response) => {
          if (response.data.success) {
            const alertStore = useAlertStore();
            alertStore.setMessage(response.data.message);
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
      await api.get<DataResponse<UserDTO>>('auth/user').then((response) => {
        this.user = response.data.data;
        this.loggedIn = true;
      });
    },

    async getUserByEmail(email: string) {
      await api
        .get<DataResponse<UserDTO>>(`auth/${email}`)
        .then((response) => {
          if (response.data.success) {
            this.searchedUser = response.data.data;
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
  },
});
