import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { SignUpComponent } from './components/pages/sign-up/sign-up.component';
import { SignInComponent } from './components/pages/sign-in/sign-in.component';

export const routes: Routes = [
        { path: '', pathMatch: 'full', redirectTo: 'home' }, // Przekierowanie na /home
        { path: 'home', component: HomeComponent },
        { path: 'sign-up', component: SignUpComponent },
        { path: 'sign-in', component: SignInComponent },
          // { path: 'sign-in', component: SignInComponent },
        //   { path: '**', component: NotFoundComponent }, // Obsługa 404
    
];
