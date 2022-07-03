import {AddressDTO} from 'src/types/AddressDTO';

export interface RegisterCustomer {
  id: number,
  username: string,
  password: string,
  confirmPassword: string
  fullname: string,
  email: string,
  address: AddressDTO,
  birthDate: Date,
  phoneNumber: string,
  image: string,
  role: string
}
