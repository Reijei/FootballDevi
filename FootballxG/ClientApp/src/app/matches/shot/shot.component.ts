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
  FieldY: number = 526;
  FieldX: number = 351;

  X: number = 0;
  Y: number = 0;



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

      var rect = event.target.getBoundingClientRect();
      var x = event.clientX - rect.left;
      var y = event.clientY - rect.top;

      y = this.FieldY - y;
      y = (y / this.OneMeter);
      y = Math.round(y * 100) / 100;
      console.log(y);
      this.Y = y;

      if(x > this.FieldX) {
        x = x - this.FieldX;
        x = x / this.OneMeter;
        x = Math.round(x * 100) / 100;
        console.log(x);
        this.X = x;
      } else {
        x = this.FieldX - x;
        x = (x / this.OneMeter);
        x = Math.round(x * 100) / 100;
        console.log(x);
        this.X = x;
      }

    }






    onSubmit(form: NgForm) {
      console.log(form.value);
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
