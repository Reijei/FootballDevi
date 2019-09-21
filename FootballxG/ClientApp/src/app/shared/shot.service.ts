import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ShotService {

  constructor(private http: HttpClient) { }


  deleteShot(id: number): any {
    return this.http.delete(environment.apiURL + '/Shot/' + id).toPromise();
  }
}
