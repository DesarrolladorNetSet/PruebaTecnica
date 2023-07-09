import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../user'
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'user');
  }

  register(Name: string, Email: string, Password: string): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'user/register', {
      Name,
      Email,
      Password
    }, httpOptions);
  }

  treeConstructor(strArr: string): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'user/treeConstructor?strArr=' + strArr);
  }

  farthestNodes(strArr: string): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'user/farthestNodes?strArr=' + strArr);
  }
}
