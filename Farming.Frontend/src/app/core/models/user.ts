export interface UserDto {
  id: string;
  login: string;
  name: string;
  created: Date;
  active: boolean;
  isAdmin: boolean;
}

export interface AddUserDto {
  login: string;
  name: string;
  password: string;
  repeatPassword: string;
}
