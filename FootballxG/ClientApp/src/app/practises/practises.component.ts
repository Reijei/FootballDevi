import { PractiseService } from './../shared/practise.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-practises',
  templateUrl: './practises.component.html',
  styleUrls: ['./practises.component.css']
})
export class PractisesComponent implements OnInit {
  practiseList;
  searchText;



  constructor(private service: PractiseService,
    private router: Router,
    private toaster: ToastrService) { }
  ngOnInit() {
    this.refreshList();
  }

  refreshList() {
    this.service.getPractiseList().then(res => this.practiseList = res);

  }



  openForEdit(PractiseID: number) {
    this.router.navigate(['/practise/edit/' + PractiseID]);
  }

  onPractiseDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deletePractise(id).then(res => {
        this.refreshList();
        this.toaster.warning("Deleted Successfully", "Football xG.");
      });
    }
  }
}
