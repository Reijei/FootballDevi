import { Practise } from './practise.model';
import { Injectable } from '@angular/core';
import { Shot } from './shot.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PractiseService {

  formData: Practise;
  shotData: Shot[];

  constructor(private http: HttpClient) { }


  saveOrUpdatePractise() {
    var body = {
      ...this.formData,
      Shot: this.shotData
    }
    console.log(body);
    return this.http.post(environment.apiURL + '/Practise', body)
  }

  getPractiseList():any {
    return this.http.get(environment.apiURL+'/Practise').toPromise();
  }

  deletePractise(id:number):any
  {
    return this.http.delete(environment.apiURL+'/Practise/'+id).toPromise();
  }

  getMatchById(id:number):any
  {
    return this.http.get(environment.apiURL+'/practise/'+id).toPromise();
  }
}
