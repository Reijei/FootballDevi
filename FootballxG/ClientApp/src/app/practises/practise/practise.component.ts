import { Component, OnInit } from '@angular/core';
import { PractiseService } from 'src/app/shared/practise.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { ShotService } from 'src/app/shared/shot.service';
import { NgForm } from '@angular/forms';
import { ShotComponent } from 'src/app/matches/shot/shot.component';
import { MatchService } from 'src/app/shared/match.service';
import { PractiseShotComponent } from '../practise-shot/practise-shot.component';

@Component({
  selector: 'app-practise',
  templateUrl: './practise.component.html',
  styleUrls: ['./practise.component.css']
})
export class PractiseComponent implements OnInit {
  isValid: boolean = true;
  Id = '';
  date = '';


  constructor(public service: PractiseService,
    public service2: MatchService,
    private dialog: MatDialog,
    private toaster: ToastrService,
    private router: Router,
    private currentRoute: ActivatedRoute,
    public shotService: ShotService) { }

    ngOnInit() {
      let MatchID = this.currentRoute.snapshot.paramMap.get('id');
      this.Id =  MatchID
      if(MatchID == null) {
      this.resetForm();
      } else {
      this.service.getMatchById(parseInt(MatchID)).then(res=>{
        this.service.formData = res.match;
        this.service.shotData = res.shot;
        console.log(this.service.formData);
      });
      }


    }

  resetForm(form?:NgForm) {
    if( form = null ) {
    form.resetForm();
    }
    this.service.formData = {
      PractiseID: null,
      DateTime: null,
      TeamName: '',
      Serie: '',
      Goals: 0,
      Corners: 0,
      Side: 0,
      Free: 0,
      Total: 0,
      Xg: 0,
    };
    this.service.shotData = [];
  }

  onSubmit(form: NgForm) {
    if (this.validateForm()) {
      this.service.saveOrUpdatePractise().subscribe(res => {
        this.resetForm();
        this.toaster.success('Submitted succesfully', 'FootballxG App.');
        this.router.navigate(['/practises']);
      })
    }
  }



  onDeleteShot(ShotID: number, i: number) {
    if (ShotID == null) {
      this.service.shotData.splice(i,1);
    } else {
      if (confirm('Are you sure to delete this record?')) {
      this.shotService.deleteShot(ShotID).then(res => {
        this.toaster.warning("Deleted Successfully", "Football xG");
        this.reloadComponent();
      });
    }
  }
}



  EditShot(shotIndex, PractiseID) {
    var TeamName = this.service.formData.TeamName;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width="1500px";
    dialogConfig.data = {shotIndex, PractiseID, TeamName};
    this.dialog.open(PractiseShotComponent, dialogConfig).afterClosed().subscribe(res => {
      this.afterClose();
    });
  }

  afterClose() {
    this.service.formData.Xg = 0;
    for (let item of this.service.shotData) {
        this.service.formData.Xg = this.service.formData.Xg + +item.Xg;

    }

    console.log(this.service.shotData);
  }

  updateTotal() {
    this.service.formData.Total = +this.service.formData.Corners + +this.service.formData.Free + +this.service.formData.Side;

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
    this.router.navigate(['/practise/edit/' + this.Id]);
  }

  redirectBack() {
    this.router.navigate(['/practises']);
  }



}
