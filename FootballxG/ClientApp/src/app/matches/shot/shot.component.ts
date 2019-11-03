import { Component, OnInit, Inject} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material"
import { MatchService } from 'src/app/shared/match.service';
import { Shot } from 'src/app/shared/shot.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-shot',
  templateUrl: './shot.component.html',
  styleUrls: ['./shot.component.css']
})
export class ShotComponent implements OnInit {
  formData: Shot;
  isValid: boolean = true;
  xpos = '';
  OneMeter: number = 9.545;
  FieldY: number = 542;
  FieldX: number = 430;

  PX: number = 0;
  PY: number = 0;

  X: number = 0;
  Y: number = 0;
  Xg: number = 0;
  part: string = '';
  showBall = false;




  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef: MatDialogRef<ShotComponent>,
    private matchService: MatchService) { }

    ngOnInit() {
      if (this.data.shotIndex == null) {
        this.formData = {
          ShotID: null,
          MatchID: this.data.MatchID,
          PractiseID: this.data.PractiseID,
          DateTime: null,
          Time: null,
          Half: null,
          ShooterName: '',
          TeamName: this.data.TeamName,
          Opponent: '',
          Assist: '',
          PositionX: null,
          PositionY: null,
          BodyPart: '',
          Result: '',
          Breakway: '',
          Pattern: '',
          BigChange: '',
          NoChange: '',
          Defenders: null,
          Xg: null,
          Comments: '',
        }

        console.log(this.data.TeamName);
      } else {
        this.formData = Object.assign({}, this.matchService.shotData[this.data.shotIndex]);
      }


    }


    getpos(event) {
      this.showBall = true;

      var rect = event.target.getBoundingClientRect();
      var x = event.clientX - rect.left;
      var y = event.clientY - rect.top;


      this.PY = y - 10;

      y = this.FieldY - y;
      y = (y / this.OneMeter);
      y = Math.round(y * 10) / 10;
      this.formData.PositionY = y;

      if(x > this.FieldX) {
        this.PX = x - 10;

        x = x - this.FieldX;
        x = x / this.OneMeter;
        x = Math.round(x * 10) / 10;
        this.formData.PositionX = x;
      } else {
        this.PX = x - 10;

        x = this.FieldX - x;
        x = (x / this.OneMeter);
        x = Math.round(x * 10) / 10;
        this.formData.PositionX = x;
      }



      this.calculateXg();
    }

    calculateXg() {
      let dist = Math.sqrt(Math.pow(this.formData.PositionX, 2) + Math.pow(this.formData.PositionY, 2));
      let partMultiplier = 7.1;
      if(this.part == "Head") {
        partMultiplier = 4.4;
      }
      let xg = Math.exp(-dist / partMultiplier);
      xg = Math.round(xg * 1000) / 1000;

      if (this.formData.Pattern == 'Corner') {
        xg = xg - 0.65;
      } else if (this.formData.Pattern == 'Side') {
        xg = xg - 0.3;
      } else if (this.formData.Pattern == 'Toss') {
        xg = xg - 0.35;
      } else if (this.formData.Pattern == 'Penalty') {
        xg = xg + 2;
      }

      if (this.formData.Breakway == 'Yes') {
        xg = xg - 0.3;
      }

      if (this.formData.BigChange == 'Yes' ) {
        xg = xg + 0.5;
      }

      if (this.formData.NoChange == 'Yes' ) {
        xg = xg - 0.5;
      }


      this.formData.Xg = xg;
    }




    onSubmit(form: NgForm) {

      if (this.validateForm(form.value)) {
        if (this.data.playeIndex == null) {
          this.matchService.shotData.push(form.value);
        } else {
          this.matchService.shotData[this.data.shotIndex] = form.value;
        }
        this.dialogRef.close();
      }
    }

    validateForm(formData: Shot) {
      this.isValid = true;
      if (formData.ShooterName == '') {
        this.isValid = false;
      }
      return this.isValid;
    }


}
