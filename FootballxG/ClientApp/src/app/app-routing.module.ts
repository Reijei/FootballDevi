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
import { PractisesComponent } from './practises/practises.component';
import { PractiseComponent } from './practises/practise/practise.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'teams', component: TeamsComponent, canActivate: [AuthGuard]},
  {path: 'team', children: [
    {path: '', component: TeamComponent},
    {path: 'edit/:id', component: TeamComponent}
  ], canActivate: [AuthGuard]},
  { path: 'matches', component: MatchesComponent, canActivate: [AuthGuard]},
  {path: 'match', children: [
    {path: '', component: MatchComponent},
    {path: 'edit/:id', component: MatchComponent}
  ], canActivate: [AuthGuard]},
  { path: 'practises', component: PractisesComponent, canActivate: [AuthGuard]},
  {path: 'practise', children: [
    {path: '', component: PractiseComponent},
    {path: 'edit/:id', component: PractiseComponent}
  ], canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
