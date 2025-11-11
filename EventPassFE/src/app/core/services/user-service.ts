import { inject, Injectable } from '@angular/core';
import { registerUserDto } from '../dtos/register-user.dto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  httpclient = inject(HttpClient);

  registerUser(user: registerUserDto): Observable<any> {
    return this.httpclient.post('https://localhost:7231/api/Users/register', user);
  }
}
