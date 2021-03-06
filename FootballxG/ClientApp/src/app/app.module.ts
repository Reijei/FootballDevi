import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import {MatDialogModule} from '@angular/material/dialog';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { TeamsComponent } from './teams/teams.component';
import { TeamComponent } from './teams/team/team.component';
import { PlayerComponent } from './teams/player/player.component';
import { MatchesComponent } from './matches/matches.component';
import { MatchComponent } from './matches/match/match.component';
import { ShotComponent } from './matches/shot/shot.component';
import { PractisesComponent } from './practises/practises.component';
import { PractiseComponent } from './practises/practise/practise.component';
import { PractiseShotComponent } from './practises/practise-shot/practise-shot.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { DigitOnlyModule } from '@uiowa/digit-only';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    TeamsComponent,
    TeamComponent,
    PlayerComponent,
    MatchesComponent,
    MatchComponent,
    ShotComponent,
    PractisesComponent,
    PractiseComponent,
    PractiseShotComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatDialogModule,
    Ng2SearchPipeModule,
    BrowserAnimationsModule,
    DigitOnlyModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    FormsModule
  ],
  entryComponents: [PlayerComponent, ShotComponent, PractiseShotComponent],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
