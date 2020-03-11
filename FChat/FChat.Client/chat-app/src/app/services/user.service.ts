import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../models/user.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public loggedUser: UserModel;

  constructor(private http: HttpClient) { }
  
  getUsers(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(environment.webApp + "user/all");
  }
  checkUser(name:string): Observable<boolean> {
    return this.http.get<boolean>(environment.webApp + `user/checkUser/${name}`);
  }
  getUser(id: number): Observable<UserModel> {
    return this.http.get<UserModel>(environment.webApp + `user/getById/${id}`);
  }

  enter(user: UserModel) {
    return this.http.post(environment.webApp + "user/enter", user);
  }
}
