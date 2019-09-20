import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  constructor(private http: HttpClient) { }


  deletePlayer(id: number): any {
    return this.http.delete(environment.apiURL + '/Player/' + id).toPromise();
  }
}
