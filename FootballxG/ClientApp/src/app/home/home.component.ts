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

  PX: number = 0;
  PY: number = 0;

  X: number = 0;
  Y: number = 0;
  Xg: number = 0;
  part: string = '';
  showBall = false;


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
    this.showBall = true;

    var rect = event.target.getBoundingClientRect();
    var x = event.clientX - rect.left;
    var y = event.clientY - rect.top;


    this.PY = y - 10;

    y = this.FieldY - y;
    y = (y / this.OneMeter);
    y = Math.round(y * 10) / 10;
    this.Y = y;

    if(x > this.FieldX) {
      this.PX = x - 10;

      x = x - this.FieldX;
      x = x / this.OneMeter;
      x = Math.round(x * 10) / 10;
      this.X = x;
    } else {
      this.PX = x - 10;

      x = this.FieldX - x;
      x = (x / this.OneMeter);
      x = Math.round(x * 10) / 10;
      this.X = x;
    }


    console.log(this.PX);
    console.log(this.PY);

    this.calculateXg();
  }


  calculateXg() {
    let dist = Math.sqrt(Math.pow(this.X, 2) + Math.pow(this.Y, 2));
    let partMultiplier = 7.1;
    if(this.part == "Head") {
      partMultiplier = 4.4;
    }
    let xg = Math.exp(-dist / partMultiplier);
    xg = Math.round(xg * 1000) / 1000;



    this.Xg = xg;
  }
}
