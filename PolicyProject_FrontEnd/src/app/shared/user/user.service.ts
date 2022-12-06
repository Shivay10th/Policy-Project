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
    
    let headers = new HttpHeaders();
    headers=headers.set("Authorization","Bearer "+localStorage.getItem("jwt"));
    return this.http.get(this.apiUrl+localStorage.getItem("userId"),{headers:headers});
  }
}
