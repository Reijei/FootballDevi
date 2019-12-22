import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material"
import { Player } from 'src/app/shared/player.model';
import { NgForm } from '@angular/forms';
import { TeamService } from 'src/app/shared/team.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  formData: Player;
  isValid: boolean = true;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef: MatDialogRef<PlayerComponent>,
    private teamService: TeamService) { }

  ngOnInit() {
    if (this.data.playerIndex == null) {
      this.formData = {
        PlayerID: null,
        TeamID: this.data.TeamID,
        PlayerName: '',
        No: 0,
        Position: '',
        Matches: 0,
        Minutes: 0,
        Goals: 0,
        Passes: 0,
        Spots: 0,
        CardYellow: 0,
        CardRed: 0,
        Xg: 0,
        XgP: 0,
        Xa: 0,
        XaP: 0,
        Xg90: 0,
        Xa90: 0
      }
    } else {
      this.formData = Object.assign({}, this.teamService.playersData[this.data.playerIndex]);
    }
  }

  updateXg(ctrl) {
    if (this.formData.Xg == 0 || this.formData.Goals == 0) {
      this.formData.XgP = 0;
    }
    else {
      this.formData.XgP = this.formData.Goals - this.formData.Xg;
    }

    if (this.formData.Minutes != 0) {
      this.updateX90();
    }
  }

  updateXa(){
    if (this.formData.Xa == 0 || this.formData.Passes == 0) {
      this.formData.XaP = 0;
    }
    else {
      this.formData.XaP = this.formData.Passes - this.formData.Xa;
    }

    if (this.formData.Minutes != 0) {
      this.updateXa90();
    }
  }

  updateX90(){
    if (this.formData.Xg == 0 || this.formData.Minutes == 0) {
      this.formData.Xg90 = 0;
    }
    else {
      this.formData.Xg90 = this.formData.Xg / (this.formData.Minutes / 90);
      this.formData.Xg90 = Math.round(this.formData.Xg90 * 1000) / 1000;
    }
  }

  updateXa90(){
    if (this.formData.Xa== 0 || this.formData.Minutes == 0) {
      this.formData.Xa90 = 0;
    }
    else {
      this.formData.Xa90 = this.formData.Xa / (this.formData.Minutes / 90);
      this.formData.Xa90 = Math.round(this.formData.Xa90 * 1000) / 1000;
    }
  }


  onSubmit(form: NgForm) {
    console.log(form.value);
    if (this.validateForm(form.value)) {
      if (this.data.playerIndex == null) {
        this.teamService.playersData.push(form.value);
      } else {
        this.teamService.playersData[this.data.playerIndex] = form.value;
      }
      this.dialogRef.close();
    }
  }

  validateForm(formData: Player) {
    this.isValid = true;
    if (formData.PlayerName == '') {
      this.isValid = false;
    }
    return this.isValid;
  }
}
