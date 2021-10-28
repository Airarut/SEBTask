import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class BackendService {
  constructor(private http: HttpClient) { }

  GetRates(date: string | null) : Observable<any>{
    return this.http.get<any>('https://localhost:44398/api/Exchange/' + date)
  }
}