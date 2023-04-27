import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { TreeClaims } from '../Models/User/TreeClaims';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    // Get the access token from local storage
    const accessTokenInfo = localStorage.getItem('access_token') ;

    // Clone the request and add the authorization header
    if (accessTokenInfo) {
      var accessToken:TreeClaims = JSON.parse(accessTokenInfo);
      const authReq = req.clone({
        headers: req.headers.set('Authorization', `Bearer ${accessToken.token}`)
      });
      return next.handle(authReq);
    }

    // If there is no access token, just pass the request through
    return next.handle(req);
  }
}
