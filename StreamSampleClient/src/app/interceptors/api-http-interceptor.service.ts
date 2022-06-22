import { Inject, Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BASE_URL } from '../app.module';

@Injectable()
export class ApiHttpInterceptor implements HttpInterceptor {

  constructor(@Inject(BASE_URL) private baseUrl: string) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const request = req.clone({ url: `${this.baseUrl}${req.url}` });
    return next.handle(request);
  }
}
