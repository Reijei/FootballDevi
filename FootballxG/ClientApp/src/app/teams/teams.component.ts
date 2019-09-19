import { Component, OnInit } from '@angular/core';
import { TeamService } from '../shared/team.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {


  constructor() { }

  ngOnInit() {

  }


}
