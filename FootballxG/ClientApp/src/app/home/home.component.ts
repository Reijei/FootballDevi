import { UserService } from './../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userDetails;
  OneMeter: number = 9.545;
  FieldY: number = 542;
  FieldX: number = 430;

  X: number = 0;
  Y: number = 0;

  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      },
    );
  }


  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }

  getpos(event) {

    var rect = event.target.getBoundingClientRect();
    var x = event.clientX - rect.left;
    var y = event.clientY - rect.top;
    console.log(x);

    y = this.FieldY - y;
    y = (y / this.OneMeter);
    y = Math.round(y * 100) / 100;
    this.Y = y;

    if(x > this.FieldX) {
      x = x - this.FieldX;
      x = x / this.OneMeter;
      x = Math.round(x * 100) / 100;
      this.X = x;
    } else {
      x = this.FieldX - x;
      x = (x / this.OneMeter);
      x = Math.round(x * 100) / 100;
      this.X = x;
    }

  }
}
