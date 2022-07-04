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
        .post('auth/login', loginCredentials)
        .then(async (response) => {
            localStorage.setItem('accessToken', response.data);
            await this.getAuthenticatedUser();
            console.log('data is ' + response.data)
            return response.data;
        })
        .catch((error: AxiosError) => {
          if (error.response && error.response.data) {
            alert('error')
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
      // const config = {
      //   method: 'get',
      //   url: 'https://localhost:7226/api/auth/user',
      //   headers: {
      //     'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6InZhcm91ZmFraXMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJzb3RpcmFzVGlzRWxsYWRhc0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBdXRob3IiLCJleHAiOjE2NTY4NjYxMDMsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcyMjYiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MjI2In0.DwQU-GoI1bBADq_S-TWe8gsq1yio-Giniqokjx7Bfdw'
      //   }
      // };

      // api.get(config)
      //   .then(function (response) {
      //     console.log(JSON.stringify(response.data));
      //   })
      //   .catch(function (error) {
      //     console.log(error);
      //   });


      await api.get<UserDTO>('auth/user',
        { headers: { 'Authorization': `Bearer ${localStorage.getItem('accessToken')}` }
      })
        .then((response) => {
          this.user = response.data
          console.log(JSON.stringify(response.data))
          this.loggedIn = true;
      }).catch((error) => {
          console.log(error);
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
