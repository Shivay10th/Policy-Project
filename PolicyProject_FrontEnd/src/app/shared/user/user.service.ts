import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  Host = environment.host;

  readonly apiUrl=`${this.Host}/users/`;

  constructor(private http:HttpClient) { }

  getUserById(){
    return this.http.get(this.apiUrl+localStorage.getItem("userId"));
  }
}
