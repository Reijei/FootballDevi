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
  sortSerie: string = '';
  matchListSort: string[] = ["All"];
  searchText


  constructor(private service: MatchService,
    private router: Router,
    private toaster: ToastrService) { }
  ngOnInit() {
    this.refreshList();
  }

  refreshList() {
    this.service.getMatchList().then(res => this.matchList = res);

  }

  updateSortList() {

    for (var val of this.matchList) {
      for (var item of this.matchList) {
        if (item != val.Serie) {
          this.matchList.push(val.Serie);
        }
      }
    }
    console.log(this.matchListSort);

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
