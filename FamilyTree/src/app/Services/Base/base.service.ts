import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export abstract class BaseService<T> {

  protected baseUrl: string = "https://localhost:44374/api/";
  protected constructor(protected http: HttpClient , private childUrl:string)
  {
    this.baseUrl+=childUrl+"/";
  }

  getAll() :Observable<T[]>{
    return this.http.get<T[]>(this.baseUrl);
  }

  getById(id: number) : Observable<T>{
    return this.http.get<T>(`${this.baseUrl}/${id}`);
  }

  create(data: T) :Observable<number>{
    return this.http.post<number>(this.baseUrl, data);
  }

  update(id: number, data: T):Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/${id}`, data);
  }

  delete(id: number):Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}/${id}`);
  }
}
