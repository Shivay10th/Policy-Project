import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly apiUrl="http://localhost:2459/api/users/";

  constructor(private http:HttpClient) { }

  getUserById(){
    
    let headers = new HttpHeaders();
    headers=headers.set("Authorization","Bearer "+localStorage.getItem("jwt"));
    return this.http.get(this.apiUrl+localStorage.getItem("userId"),{headers:headers});
  }
}
