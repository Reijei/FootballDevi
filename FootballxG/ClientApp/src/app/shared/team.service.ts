import { Injectable } from '@angular/core';
import { Team } from './team.model';
import { Player } from './player.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  formData: Team;
  playersData: Player[];
  constructor(private http: HttpClient) { }


  getTeamList() {
    return this.http.get(environment.apiURL + '/Team').toPromise();
  }

  deleteTeam(id:number):any
  {
    return this.http.delete(environment.apiURL+'/Team/'+id).toPromise();
  }
  getTeamById(id:number):any
  {
    return this.http.get(environment.apiURL+'/Team/'+id).toPromise();
  }

}
