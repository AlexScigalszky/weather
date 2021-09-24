import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SerializerService {
  queryToParams(query: { [k: string]: any }): string {
    let urlParams = '?';
    for (let key in query) {
      if (this.isValid(query, key)) {
        const symbol = urlParams == '?' ? '' : '&';
        urlParams += `${symbol}${key}=${query[key]}`;
      }
    }
    return urlParams;
  }

  private isValid(query: { [k: string]: any }, key: string) {
    return query[key] !== '' && query[key] !== null;
  }
}
