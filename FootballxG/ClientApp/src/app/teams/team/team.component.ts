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

  AddOrEditPlayer(playerIndex, TeamID) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width="50%";
    dialogConfig.data = {playerIndex, TeamID};
    this.dialog.open(PlayerComponent, dialogConfig);
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


  onDeletePlayer(PlayerID: number, i: number) {
    if (PlayerID == null) {
      this.service.playersData.splice(i,1);
    } else {
    if (confirm('Are you sure to delete this record?')) {
      this.playerService.deletePlayer(PlayerID).then(res => {
        this.toaster.warning("Deleted Successfully", "Football xG");
        this.reloadComponent();
      });
    }
  }
}

  onSubmit(form: NgForm) {
    if (this.validateForm()) {
      this.service.saveOrUpdate().subscribe(res => {
        this.resetForm();
        this.toaster.success('Submitted succesfully', 'FootballxG App.');
        this.router.navigate(['/teams']);
      })
    }
  }


  validateForm() {
    this.isValid = true;
    if (this.service.formData.TeamName == '') {
      this.isValid = false;
    }
    return this.isValid;
  }

  reloadComponent() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/team/edit/' + this.Id]);
  }

  redirectBack() {
    this.router.navigate(['/teams']);
  }

}
