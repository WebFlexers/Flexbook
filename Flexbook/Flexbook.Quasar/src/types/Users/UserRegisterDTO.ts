import {AddressDTO} from 'src/types/AddressDTO';

export interface UserRegisterDTO {
  username: string,
  password: string,
  fullname: string,
  email: string,
  address: AddressDTO,
  birthDate: string,
  phoneNumber: string,
  image: string,
  role: string
}
