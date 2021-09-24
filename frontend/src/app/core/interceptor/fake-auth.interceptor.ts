import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '@app/model/user';
import { Observable, of } from 'rxjs';

@Injectable()
export class FakeAuth implements HttpInterceptor {
  fakeUser: User = new User();

  constructor() {
    this.fakeUser.token = 'fake-token';
    this.fakeUser.id = '123';
    this.fakeUser.loginAttemps = 3;
    this.fakeUser.password ='';
    this.fakeUser.username = 'fake user';
  }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler,
  ): Observable<HttpEvent<any>> {
    if (req.url.includes('api/user')) {
      return of(
        new HttpResponse({
          status: 200,
          body: this.fakeUser,
        }),
      );
    }

    return next.handle(req);
  }
}
