import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { alert } from 'devextreme/ui/dialog';

@Injectable()
export class HttpAuthErrorInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          window.location.href = '/identity/account/login';
        }
        if (error.status === 403) {
          alert(
            'Bạn không đủ quyền để truy cập chức năng này!',
            'Đã có lỗi xảy ra'
          );
        }
        return throwError(error);
      })
    );
  }
}
