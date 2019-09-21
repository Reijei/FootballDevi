import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { TeamsComponent } from './teams/teams.component';
import { TeamComponent } from './teams/team/team.component';
import { MatchesComponent } from './matches/matches.component';
import { MatchComponent } from './matches/match/match.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
  {path: 'teams', component: TeamsComponent},
  {path: 'team', children: [
    {path: '', component: TeamComponent},
    {path: 'edit/:id', component: TeamComponent}
  ]},
  {path: 'matches', component: MatchesComponent},
  {path: 'match', children: [
    {path: '', component: MatchComponent},
    {path: 'edit/:id', component: MatchComponent}
  ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
