import { PlayerService } from './../../shared/player.service';
import { Component, OnInit } from '@angular/core';
import { TeamService } from 'src/app/shared/team.service';
import { NgForm } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PlayerComponent } from '../player/player.component';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {
  isValid: boolean = true;
  Id = '';


  constructor(public service: TeamService,
    private dialog: MatDialog,
    private toaster: ToastrService,
    private router: Router,
    private currentRoute: ActivatedRoute,
    public playerService: PlayerService) { }

  ngOnInit() {
    let TeamID = this.currentRoute.snapshot.paramMap.get('id');
    this.Id =  TeamID
    if(TeamID == null) {
    this.resetForm();
    } else {
    this.service.getTeamById(parseInt(TeamID)).then(res=>{
      this.service.formData = res.team;
      this.service.playersData = res.players;
    });
    }
  }


  resetForm(form?:NgForm) {
    if( form = null ) {
    form.resetForm();
    }
    this.service.formData = {
      TeamID: null,
      TeamName: '',
      Wins: null,
      Loses: null,
      Serie: '',
      Position: null,
    };
    this.service.playersData = [];
  }

}
