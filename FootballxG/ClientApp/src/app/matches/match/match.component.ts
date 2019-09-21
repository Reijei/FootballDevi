import { Component, OnInit } from '@angular/core';
import { MatchService } from 'src/app/shared/match.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { ShotService } from 'src/app/shared/shot.service';
import { NgForm } from '@angular/forms';
import { ShotComponent } from '../shot/shot.component';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.css']
})
export class MatchComponent implements OnInit {
  isValid: boolean = true;
  Id = '';

  constructor(public service: MatchService,
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
    });
    }
  }

  resetForm(form?:NgForm) {
    if( form = null ) {
    form.resetForm();
    }
    this.service.formData = {
      MatchID: null,
      DateTime: null,
      HomeName: '',
      AwayName: '',
      HomeGoals: null,
      AwayGoals: null,
      HomeCorners: null,
      AwayCorners: null,
      HomeSide: null,
      AwaySide: null,
      HomeFree: null,
      AwayFree: null,
      HomeTotal: null,
      AwayTotal: null,
      HomeXg: null,
      AwayXg: null,
    };
    this.service.shotData = [];
  }

  onSubmit(form: NgForm) {
    if (this.validateForm()) {
      this.service.saveOrUpdateMatch().subscribe(res => {
        this.resetForm();
        this.toaster.success('Submitted succesfully', 'FootballxG App.');
        this.router.navigate(['/matches']);
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



  EditShot(shotIndex, MatchID) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width="800px";
    dialogConfig.data = {shotIndex, MatchID};
    this.dialog.open(ShotComponent, dialogConfig);
  }

  validateForm() {
    this.isValid = true;
    if (this.service.formData.HomeName == '') {
      this.isValid = false;
    }
    return this.isValid;
  }


  reloadComponent() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['/match/edit/' + this.Id]);
  }

  redirectBack() {
    this.router.navigate(['/matches']);
  }



}
