import * as jwt from 'jwt-decode';

export interface ApiResponse<T> {
  content: T;
}

export interface TokenResponse {
  token: string;
}

export interface DecodedToken extends jwt.JwtPayload {
  id: string;
  isAdmin: string;
  isActive: string;
  isAuthorized: string;
  name: string;
}
