import { Component, OnInit } from '@angular/core';
import { MatchService } from '../shared/match.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css']
})
export class MatchesComponent implements OnInit {
  matchList;


  constructor(private service: MatchService,
    private router: Router,
    private toaster: ToastrService) { }
  ngOnInit() {
    this.refreshList();
  }

  refreshList() {
    this.service.getMatchList().then(res => this.matchList = res);

  }

  openForEdit(MatchID: number) {
    this.router.navigate(['/match/edit/' + MatchID]);
  }

  onMatchDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteMatch(id).then(res => {
        this.refreshList();
        this.toaster.warning("Deleted Successfully", "Football xG.");
      });
    }
  }
}
