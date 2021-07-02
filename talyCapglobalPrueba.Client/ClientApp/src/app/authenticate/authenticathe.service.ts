import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticatheService {
  private user: IUser;
 
  constructor(private http: HttpClient, @Inject('https://fakerestapi.azurewebsites.net/api/v1/') private baseUrl: string) {
   
  }
  authenticate(): Observable<IUser> {    
    return this.http.get<IUser>(this.baseUrl + 'Users'); 
  }
}
interface IUser {
  id: number,
  userName: string,
  password: string
  
}
