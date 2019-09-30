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
  date = '';

  emptyHome = true;
  emptyAway = true;

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
      this.onAddTeamName();
      this.date = this.service.formData.DateTime.toString();
      this.date = this.date.slice(0, 10);
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
      HomeGoals: 0,
      AwayGoals: 0,
      HomeCorners: 0,
      AwayCorners: 0,
      HomeSide: 0,
      AwaySide: 0,
      HomeFree: 0,
      AwayFree: 0,
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
  onAddTeamName() {
    if(this.service.formData.HomeName != '') {
      this.emptyHome = false;
    }

    if(this.service.formData.AwayName != '') {
      this.emptyAway = false;
    }

  }


  updateXgTotal() {
    for (let item of this.service.shotData) {
      if (item.TeamName == this.service.formData.HomeName) {
        this.service.formData.HomeXg = this.service.formData.HomeXg + item.Xg;
      }
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

updateTotal() {
    this.service.formData.HomeTotal = +this.service.formData.HomeCorners + +this.service.formData.HomeFree + +this.service.formData.HomeSide;

}

updateTotalAway() {
  this.service.formData.AwayTotal = +this.service.formData.AwayCorners + +this.service.formData.AwayFree + +this.service.formData.AwaySide;

}

  EditShotHome(shotIndex, MatchID) {
    var TeamName = this.service.formData.HomeName;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width="1500px";
    dialogConfig.data = {shotIndex, MatchID, TeamName};
    this.dialog.open(ShotComponent, dialogConfig).afterClosed().subscribe(res => {
      this.afterCloseHome();
    });
  }

  afterCloseHome() {
    this.service.formData.HomeXg = 0;
    for (let item of this.service.shotData) {
      if (this.service.formData.HomeName == item.TeamName) {
        this.service.formData.HomeXg = this.service.formData.HomeXg + +item.Xg;

      }
    }
  }

  afterCloseAway() {
    this.service.formData.AwayXg = 0;
    for (let item of this.service.shotData) {
      if (this.service.formData.AwayName == item.TeamName) {
        this.service.formData.AwayXg = this.service.formData.AwayXg + +item.Xg;

      }
    }
  }

  EditShotAway(shotIndex, MatchID) {
    var TeamName = this.service.formData.AwayName;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width="1500px";
    dialogConfig.data = {shotIndex, MatchID, TeamName};
    this.dialog.open(ShotComponent, dialogConfig).afterClosed().subscribe(res => {
      this.afterCloseAway();
    });
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
