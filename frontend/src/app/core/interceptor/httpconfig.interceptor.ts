import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';

import { Observable, throwError, of } from 'rxjs';
import { map, catchError, timeout } from 'rxjs/operators';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler,
  ): Observable<HttpEvent<any>> {
    if (!request.headers.has('Content-Type')) {
      request = request.clone({
        headers: request.headers.set('Content-Type', 'application/json'),
      });
    }
    if (!request.headers.has('Access-Control-Allow-Origin')) {
      request = request.clone({
        headers: request.headers.set('Access-Control-Allow-Origin', '*'),
      });
    }
    request = request.clone({
      headers: request.headers.set('Accept', 'application/json'),
    });
    request = request.clone({
      headers: request.headers.set('Cache-Control', 'no-cache'),
    });
    request = request.clone({
      headers: request.headers.set('Pragma', 'no-cache'),
    });
    request = request.clone({
      headers: request.headers.set('Expires', 'Sat, 01 Jan 2000 00:00:00 GMT'),
    });

    if (request.headers.has('Skip-Prefix')) {
      return next.handle(request);
    }

    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
        }
        return event;
      }),
      catchError((error: HttpErrorResponse) => {
        console.debug(error.url, error);
        const data = {
          mensaje: error,
          status: error.status,
        };
        console.error(data);
        return throwError(error);
      }),
    );
  }
}
