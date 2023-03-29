import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnlyUnauthorizedGuard } from '../../core/guards/only-unauthorized.guard';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
	{
		path: 'login',
		component: LoginComponent,
		canActivate: [OnlyUnauthorizedGuard],
	},
	{
		path: 'register',
		component: RegisterComponent,
		canActivate: [OnlyUnauthorizedGuard],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class AuthRouting {}
