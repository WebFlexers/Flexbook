import {AddressDTO} from 'src/types/AddressDTO';

export interface UserDTO {
  id: number,
  username: string,
  password: string,
  fullname: string,
  email: string,
  address: AddressDTO,
  birthDate: Date,
  phoneNumber: string,
  image: string,
  role: string
}
