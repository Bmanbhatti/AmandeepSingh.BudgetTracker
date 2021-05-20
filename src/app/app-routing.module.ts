import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ExpenditureDetailsComponent } from './expenditure-details/expenditure-details.component';
import { IncomeDetailsComponent } from './income-details/income-details.component';
import { UserDetailsComponent } from './user-details/user-details.component';

const routes: Routes = [


  { path: "", component: LoginComponent },
  { path: "userDetails", component: UserDetailsComponent },
  { path: "register", component: RegisterComponent },
  { path: "incomeDetails/:id", component: IncomeDetailsComponent },
  { path: "expenditureDetails/:id", component: ExpenditureDetailsComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
