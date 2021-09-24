import { Injectable } from '@angular/core';

@Injectable()
export class JwtService {
  getToken(): string {
    const jwtToken = 'jwtToken';
    // return window.localStorage[jwtToken];

    return 'fake_token'; // just for this example
  }

  saveToken(token: string) {
    const jwtToken = 'jwtToken';
    window.localStorage[jwtToken] = token;
  }

  destroyToken() {
    const jwtToken = 'jwtToken';
    window.localStorage.removeItem(jwtToken);
  }
}
