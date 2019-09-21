import { Injectable } from '@angular/core';
import { Match } from './match.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Shot } from './shot.model';

@Injectable({
  providedIn: 'root'
})
export class MatchService {

  formData: Match;
  shotData: Shot[];

  constructor(private http: HttpClient) { }


  saveOrUpdateMatch() {
    var body = {
      ...this.formData,
      Shot: this.shotData
    }
    console.log(body);
    return this.http.post(environment.apiURL + '/Match', body)
  }

  getMatchList(){
    return this.http.get(environment.apiURL+'/Match').toPromise();
  }

  deleteMatch(id:number):any
  {
    return this.http.delete(environment.apiURL+'/Match/'+id).toPromise();
  }

  getMatchById(id:number):any
  {
    return this.http.get(environment.apiURL+'/Match/'+id).toPromise();
  }
}
